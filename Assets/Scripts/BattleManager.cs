using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using TMPro;

public class BattleManager: MonoBehaviour
{
    public static BattleManager Instance;
    public static float TickTime => 1 / 60f;

    public List<string> FriendUnitsId = new();
    public List<string> EnemyUnitsId = new();

    private int tick = 0;
    private float timer = 0;

    private List<BaseUnit> friendUnits = new();
    private List<BaseUnit> enemyUnits = new();

    private Canvas uiCanvas;
    private static GameObject damagePopupPrefab;
    private const string DamagePopupKey = "DamagePopup";

    // ============ 弹簧阻尼相机震动 ============
    private float shakeVelocity;
    private float shakeDisplacement;
    private Vector3 cameraOrigin;
    private bool cameraOriginInited;

    // 震动频率
    private const float SpringStiffness = 800f; 
    // 衰减速率
    private const float SpringDamping = 20f;   
    // 受击冲量（振幅）    
    private const float ShakeImpulse = 10f;         

    /// <summary>造成伤害时镜头上下震动（弹簧阻尼模型，多段自然叠加）</summary>
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

    /// <summary>在受击位置显示伤害数字弹出</summary>
    public void ShowDamagePopup(Vector3 worldPosition, int damage, int popupIndex)
    {
        if (uiCanvas == null)
        {
            var canvasGo = GameObject.Find("UICanvas");
            if (canvasGo != null)
                uiCanvas = canvasGo.GetComponent<Canvas>();
        }
        if (uiCanvas == null) return;

        // 通过 Addressables 加载 DamagePopup 预制体（缓存）
        if (damagePopupPrefab == null)
            damagePopupPrefab = Addressables.LoadAssetAsync<GameObject>(DamagePopupKey).WaitForCompletion();
        if (damagePopupPrefab == null) return;

        var popup = Object.Instantiate(damagePopupPrefab, uiCanvas.transform);

        // 将伤害数字的每一位转为 <sprite index=X> 格式
        string damageStr = damage.ToString();
        string spriteText = "";
        foreach (char c in damageStr)
            spriteText += $"<sprite index={c}>";

        var tmp = popup.GetComponent<TMP_Text>();
        if (tmp != null)
            tmp.text = spriteText;

        // 将世界坐标转换到屏幕坐标，定位弹出位置
        var rt = popup.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        rt.anchoredPosition = new Vector2(
            screenPos.x - Screen.width * 0.5f,
            screenPos.y - Screen.height * 0.5f + popupIndex * 80f  // 多段伤害递增上移
        );

        // 上浮 + 淡出动画后自动销毁
        StartCoroutine(AnimateDamagePopup(popup));
    }

    private IEnumerator AnimateDamagePopup(GameObject popup)
    {
        float duration = 1.0f;
        float elapsed = 0f;
        Vector3 startPos = popup.transform.position;
        Vector3 endPos = startPos + Vector3.up * 1.5f;

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
        {
            friendUnits.Add(new BaseUnit(FriendUnitsId[i], CampType.Friend));
        }
        for (int i = 0; i < EnemyUnitsId.Count; i++)
        {
            enemyUnits.Add(new BaseUnit(EnemyUnitsId[i], CampType.Enemy));
        }

        friendUnits.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));
        enemyUnits.Sort((x, y) => x.AttackRange.CompareTo(y.AttackRange));

        for (int i = 0; i < friendUnits.Count; i++)
        {
            friendUnits[i].Init(i);
        }
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            enemyUnits[i].Init(i);
        }
    }

    private void Update()
    {
        UpdateSpringShake();

        timer += Time.deltaTime;
        while(timer > TickTime)
        {
            timer -= TickTime;
            tick++;
            Tick();
        }
    }

    private void Tick()
    {
        for(int i = 0;i < friendUnits.Count; i++)
        {
            BaseUnit unit = friendUnits[i];
            unit.Tick();
        }
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            BaseUnit unit = enemyUnits[i];
            unit.Tick();
        }
    }

    public List<BaseUnit> GetOppositeUnits(CampType campType)
    {
        return campType == CampType.Friend ? enemyUnits : friendUnits;
    }

    public List<BaseUnit> GetAllies(CampType campType)
    {
        return campType == CampType.Friend ? friendUnits : enemyUnits;
    }

    /// <summary>暂停除 activeUnit 外的所有单位</summary>
    public void PauseAllExcept(BaseUnit activeUnit)
    {
        foreach (var u in friendUnits)
            if (u != activeUnit) u.IsPaused = true;
        foreach (var u in enemyUnits)
            if (u != activeUnit) u.IsPaused = true;
    }

    /// <summary>恢复所有单位</summary>
    public void ResumeAll()
    {
        foreach (var u in friendUnits) u.IsPaused = false;
        foreach (var u in enemyUnits) u.IsPaused = false;
    }
}
