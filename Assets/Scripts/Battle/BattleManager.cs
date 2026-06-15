using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    public static float TickTime => 1 / 60f;

    public List<int> FriendUnitsId = new();
    public List<int> EnemyUnitsId = new();

    private int tick = 0;
    private float timer = 0;

    private List<UnitCtrl> friendUnits = new();
    private List<UnitCtrl> enemyUnits = new();

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

    public void ShakeCamera()
    {
        float dir = Random.value > 0.5f ? -1f : 1f;
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

    public void ShowDamagePopup(Vector3 worldPosition, int damage, int popupIndex)
    {
        if (damagePopupPrefab == null)
            damagePopupPrefab = Addressables.LoadAssetAsync<GameObject>(DamagePopupKey).WaitForCompletion();
        if (damagePopupPrefab == null) return;

        var canvas = GetOrCreateDamageWorldCanvas();
        var popup = Object.Instantiate(damagePopupPrefab, canvas.transform);

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

        Object.Destroy(popup);
    }

    private void Start()
    {
        for (int i = 0; i < FriendUnitsId.Count; i++)
            friendUnits.Add(new UnitCtrl(FriendUnitsId[i], CampType.Friend));

        for (int i = 0; i < EnemyUnitsId.Count; i++)
            enemyUnits.Add(new UnitCtrl(EnemyUnitsId[i], CampType.Enemy));

        friendUnits.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));
        enemyUnits.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));

        for (int i = 0; i < friendUnits.Count; i++)
            friendUnits[i].Init(i);
        for (int i = 0; i < enemyUnits.Count; i++)
            enemyUnits[i].Init(i);
    }

    private void Update()
    {
        UpdateSpringShake();

        timer += Time.deltaTime;
        while (timer > TickTime)
        {
            timer -= TickTime;
            tick++;
            Tick();
        }
    }

    private void Tick()
    {
        foreach (var unit in friendUnits)
            unit.Tick();
        foreach (var unit in enemyUnits)
            unit.Tick();
    }

    public List<UnitCtrl> GetOppositeUnits(CampType campType)
    {
        return campType == CampType.Friend ? enemyUnits : friendUnits;
    }

    public List<UnitCtrl> GetAllies(CampType campType)
    {
        return campType == CampType.Friend ? friendUnits : enemyUnits;
    }

    public void PauseAllExcept(UnitCtrl activeUnit)
    {
        foreach (var u in friendUnits)
            if (u != activeUnit) u.IsPaused = true;
        foreach (var u in enemyUnits)
            if (u != activeUnit) u.IsPaused = true;
    }

    public void ResumeAll()
    {
        foreach (var u in friendUnits) u.IsPaused = false;
        foreach (var u in enemyUnits) u.IsPaused = false;
    }
}
