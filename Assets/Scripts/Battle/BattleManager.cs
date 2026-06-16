using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BattleManager : MonoBehaviour, IBattleManagerForBaseBattleProcessor
{
    public static BattleManager Instance;

    private static int LogicFrameRate = 60;
    public static float TimePerFrame => 1f / LogicFrameRate;

    public List<int> FriendUnitsId = new();
    public List<int> EnemyUnitsId = new();

    private int tick = 0;
    private float timer = 0;

    public UnitCtrl BossUnit;

    public List<UnitCtrl> UnitList { get; set; } = new();
    private List<UnitCtrl> EnemyList { get; set; } = new();
    public eBattleResult BattleResult { get; }
    public float TimeLimit { get; set; }

    private Canvas uiCanvas;
    private Canvas damageWorldCanvas;
    private static GameObject damagePopupPrefab;
    private const string DamagePopupKey = "DamagePopup";
    private const float DamagePopupWorldScale = 0.01f;
    private const float DamageStackOffset = 1f;
    private const float DamageFloatUp = 1.0f;

    private float shakeVelocity;
    private float shakeDisplacement;
    private Vector3 cameraOrigin;
    private bool cameraOriginInited;

    private const float SpringStiffness = 800f;
    private const float SpringDamping = 20f;
    private const float ShakeImpulse = 10f;

    public void CreateUnit(int _unitId, Action<UnitCtrl> _callback, bool _addUnitList = true)
    {

    }

    public void ShakeCamera()
    {
        float dir = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        shakeVelocity += ShakeImpulse * dir;
    }

    private void UpdateSpringShake()
    {
        var cam = Camera.main;
        if (cam == null) return;

        if (!cameraOriginInited)
        {
            cameraOrigin = cam.transform.position;
            cameraOriginInited = true;
        }

        if (Mathf.Abs(shakeDisplacement) < 0.001f && Mathf.Abs(shakeVelocity) < 0.001f)
        {
            shakeDisplacement = 0f;
            shakeVelocity = 0f;
            return;
        }

        float dt = Time.deltaTime;
        float force = -SpringStiffness * shakeDisplacement - SpringDamping * shakeVelocity;
        shakeVelocity += force * dt;
        shakeDisplacement += shakeVelocity * dt;

        cam.transform.position = new Vector3(cameraOrigin.x, cameraOrigin.y + shakeDisplacement, cameraOrigin.z);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < FriendUnitsId.Count; i++)
            UnitList.Add(new UnitCtrl(FriendUnitsId[i]));

        for (int i = 0; i < EnemyUnitsId.Count; i++)
            EnemyList.Add(new UnitCtrl(EnemyUnitsId[i]));

        UnitList.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));
        EnemyList.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));

        for (int i = 0; i < UnitList.Count; i++)
            UnitList[i].Init(i);
        for (int i = 0; i < EnemyList.Count; i++)
            EnemyList[i].Init(i);
    }

    private void Update()
    {
        UpdateSpringShake();

        timer += Time.deltaTime;
        while (timer > TimePerFrame)
        {
            timer -= TimePerFrame;
            tick++;
            UpdateFrame();
        }
    }

    private void UpdateFrame()
    {
        foreach (var unit in UnitList)
            unit.UpdateFrame();
        foreach (var unit in EnemyList)
            unit.UpdateFrame();
    }


    private Canvas GetOrCreateDamageWorldCanvas()
    {
        if (damageWorldCanvas != null) return damageWorldCanvas;
        var go = new GameObject("DamageWorldCanvas");
        damageWorldCanvas = go.AddComponent<Canvas>();
        damageWorldCanvas.renderMode = RenderMode.WorldSpace;
        damageWorldCanvas.worldCamera = Camera.main;
        damageWorldCanvas.sortingOrder = 9999;
        damageWorldCanvas.transform.position = Vector3.zero;
        damageWorldCanvas.transform.rotation = Quaternion.identity;
        return damageWorldCanvas;
    }

    public void ShowDamagePopup(Vector3 worldPosition, long damage, int popupIndex)
    {
        if (damagePopupPrefab == null)
            damagePopupPrefab = Addressables.LoadAssetAsync<GameObject>(DamagePopupKey).WaitForCompletion();
        if (damagePopupPrefab == null) return;

        var canvas = GetOrCreateDamageWorldCanvas();
        var popup = GameObject.Instantiate(damagePopupPrefab, canvas.transform);

        string damageStr = damage.ToString();
        string spriteText = "";
        foreach (char c in damageStr)
            spriteText += $"<sprite index={c}>";

        var tmp = popup.GetComponent<TMP_Text>();
        if (tmp != null)
            tmp.text = spriteText;

        popup.transform.position = worldPosition + Vector3.up * (popupIndex * DamageStackOffset);
        popup.transform.localScale = Vector3.one * DamagePopupWorldScale;

        StartCoroutine(AnimateDamagePopup(popup));
    }

    private IEnumerator AnimateDamagePopup(GameObject popup)
    {
        float duration = 1.0f;
        float elapsed = 0f;
        Vector3 startPos = popup.transform.position;
        Vector3 endPos = startPos + Vector3.up * DamageFloatUp;

        var tmp = popup.GetComponent<TMP_Text>();
        Color startColor = tmp != null ? tmp.color : Color.white;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            popup.transform.position = Vector3.Lerp(startPos, endPos, t);
            if (tmp != null)
                tmp.color = new Color(startColor.r, startColor.g, startColor.b, 1f - t);
            yield return null;
        }

        GameObject.Destroy(popup);
    }

    public void PauseAllExcept(UnitCtrl activeUnit)
    {
        foreach (var u in UnitList)
            if (u != activeUnit) u.IsPaused = true;
        foreach (var u in EnemyList)
            if (u != activeUnit) u.IsPaused = true;
    }

    public void ResumeAll()
    {
        foreach (var u in UnitList) u.IsPaused = false;
        foreach (var u in EnemyList) u.IsPaused = false;
    }
    public List<UnitCtrl> BossList { get; set; }

    public bool IsCurtain { get; set; }

    public int GetMiliLimitTime() => (int)(TimeLimit * 1000);

    public void CallbackRequestFinishBattle() { }

    public void ResultApiSendExec(Action _execCallback, Action<int> _errorCallback) { }

    public int GetUnitCtrlLength()
    {
        if (UnitList == null) return -1;
        return UnitList.Count;
    }
    public List<UnitCtrl> GetMyUnitList() => UnitList;

    public UnitCtrl GetUnitCtrl(int _idx)
    {
        if (UnitList == null) return null;
        if (_idx < 0 || _idx >= UnitList.Count) return null;
        return UnitList[_idx];
    }

    public UnitCtrl FindUnit(int _id)
    {
        if (UnitList == null) return null;
        return UnitList.FirstOrDefault(unit => unit.Id == _id);
    }

    public int GetEnemyCtrlLength()
    {
        if (EnemyList == null) return -1;
        return EnemyList.Count;
    }

    public List<UnitCtrl> GetEnemyUnitList() => EnemyList;

    public UnitCtrl GetEnemyCtrl(int _idx)
    {
        if (EnemyList == null) return null;
        if (_idx < 0 || _idx >= EnemyList.Count) return null;
        return EnemyList[_idx];
    }

    public UnitCtrl FindEnemy(int _id)
    {
        if (EnemyList == null) return null;
        return EnemyList.FirstOrDefault(enemy => enemy.Id == _id);
    }

    public UnitCtrl GetBossUnit() => BossUnit;
    public IEnumerator RecreateDeadUnits(Action _callback, eBattleResult _battleResult)
    {
        return null;
    }
    public void RevivalAtFinishBattle() { }
    public List<UnitHpInfo> CreateUnitHpInfoList(int _enemyViewerId, int _myViewerId)
    {
        return new List<UnitHpInfo>();
    }
    public List<UnitHpInfoForFriendBattle> CreateUnitHpInfoListForFriendBattle(int _enemyViewerId, int _myViewerId)
    {
        return new List<UnitHpInfoForFriendBattle>();
    }
    public void SetupLosePlayVoiceUnitId() { }
    public void StartResult() { }
    public IEnumerator UpdateBossIdleMotion(BattleSpineController _unitSpineController, int _motionPrefix)
    {
        return null;
    }
    public void TurnOffAllEffects() { }
    public void OffSkillExeScreen() { }
    public void ChangeAllUnitDefaultShader() { }
    public void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit) { }
}
