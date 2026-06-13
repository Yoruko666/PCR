using UnityEngine;
using Spine;
using Spine.Unity;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using TMPro;

public class BaseUnit
{
    public SkeletonAnimation spine;

    public UnitData Data;
    public UnitSkillData SkillData;
    public int UnitId;
    public CampType CampType;
    public int Number;
    public float LogicX;
    public int XDir => CampType == CampType.Friend ? 1 : -1;

    protected StateMachine stateMachine;

    private GameObject gameObject;

    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int TP { get; private set; }
    public int MaxTP { get; private set; }
    public int PhysicalAttack { get; private set; }
    public int MagicAttack { get; private set; }
    public int SkillLevel { get; set; }
    public int Rarity { get; set; } = 1;
    public int Level { get; set; } = 300;
    public float AttackRange { get; private set; }
    public int MotionType { get; private set; }
    public readonly float HitRange = 112;

    public SkillManager Skill { get; private set; }
    public bool IsPaused { get; set; }
    private AudioSource audioSource;
    private Dictionary<string, AudioClip> soundCache = new();

    private static GameObject bubblePrefab;
    private GameObject bubbleInstance;
    private Spine.Bone headBone;
    private const string BubblePrefabKey = "fx_skill_bubble";

    public BaseUnit(int unitId, CampType campType)
    {
        UnitId = unitId;
        Data = ConfigManager.Instance.GetUnitData(unitId);
        if (Data == null)
        {
            Debug.LogError($"[BaseUnit] 找不到角色数据: {unitId}");
            return;
        }

        MotionType = Data.motion_type;
        SkillData = ConfigManager.Instance.GetUnitSkillData(unitId);

        gameObject = new GameObject(Data.unit_name ?? unitId.ToString());
        audioSource = gameObject.AddComponent<AudioSource>();
        spine = gameObject.AddComponent<SkeletonAnimation>();

        string spineKey = $"{unitId}";
        spine.skeletonDataAsset = Addressables.LoadAssetAsync<SkeletonDataAsset>(spineKey).WaitForCompletion();
        spine.Initialize(true);
        headBone = spine.Skeleton.FindBone("head");

        CampType = campType;

        // 从 UnitRarity 读取属性 = 基础值 + 成长 * (等级 - 1)
        var rarityCfg = ConfigManager.Instance.GetUnitRarity(unitId, Rarity);
        if (rarityCfg != null)
        {
            MaxHP = Mathf.RoundToInt(rarityCfg.hp + rarityCfg.hp_growth * (Level - 1));
            HP = MaxHP;
            PhysicalAttack = Mathf.RoundToInt(rarityCfg.atk + rarityCfg.atk_growth * (Level - 1));
            MagicAttack = Mathf.RoundToInt(rarityCfg.magic_str + rarityCfg.magic_str_growth * (Level - 1));
        }
        else
        {
            Debug.LogWarning($"[BaseUnit] 找不到稀有度数据: {unitId}_rarity{Rarity}");
            MaxHP = 1;
            HP = 1;
            PhysicalAttack = 0;
            MagicAttack = 0;
        }

        MaxTP = 1000;
        TP = 0;
        SkillLevel = 1;
        AttackRange = Data.search_area_width;

        stateMachine = new StateMachine(this);
        stateMachine.SetDefaultState(StateType.RunGameStart);

        int ubId = SkillData?.union_burst ?? 0;
        int skill1Id = SkillData?.main_skill_1 ?? 0;
        int skill2Id = SkillData?.main_skill_2 ?? 0;
        Skill = new SkillManager(this, ubId, skill1Id, skill2Id);

        if (bubblePrefab == null)
            bubblePrefab = Addressables.LoadAssetAsync<GameObject>(BubblePrefabKey).WaitForCompletion();
        if (bubblePrefab != null)
        {
            bubbleInstance = Object.Instantiate(bubblePrefab, gameObject.transform);
            bubbleInstance.transform.localScale = new Vector3(XDir, 1, 1);
            bubbleInstance.SetActive(false);
        }
    }

    public void Init(int orderNumber)
    {
        Number = orderNumber;
        InitLogicPosition();
        InitTransform();
    }

    public void Tick()
    {
        if (IsPaused) return;

        if (bubbleInstance != null && bubbleInstance.activeSelf && headBone != null)
            bubbleInstance.transform.position = headBone.GetWorldPosition(spine.transform) + new Vector3(0, 1.2f, -0.01f);

        stateMachine.CheckSwitchState();
        stateMachine.OnTick();
    }

    public void PlayAnim(string animName, bool loop)
    {
        if (spine.Skeleton.Data.FindAnimation(animName) == null)
        {
            Debug.LogWarning($"[BaseUnit] 找不到动画 '{animName}' (角色: {Data?.unit_name ?? UnitId.ToString()})");
            return;
        }
        spine.AnimationState.SetAnimation(0, animName, loop);
    }

    public string GetAnimName(string animKey)
    {
        string prefix = MotionType.ToString("00");
        string unitPrefix = UnitId.ToString();
        return animKey switch
        {
            "run_game_start"    => $"{prefix}_run_gamestart",
            "stand_by"          => $"{prefix}_standBy",
            "run"               => $"{prefix}_run",
            "idle"              => $"{prefix}_idle",
            "attack"            => $"{Data.se_type:D2}_attack",
            _                   => animKey
        };
    }

    public Vector3 GetPosition() => gameObject.transform.position;

    public void Move()
    {
        LogicX += 7.5f * XDir;
        SetLogicPosition(LogicX);
    }

    public void SetLogicPosition(float x)
    {
        this.LogicX = x;
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = new Vector3((x + 200) * 15 / 1160, position.y, position.z);
    }

    public void InitLogicPosition()
    {
        float spawnX = -(660 + 200 * Number) * XDir - 100;
        SetLogicPosition(spawnX);
    }

    public void InitTransform()
    {
        gameObject.transform.localScale = new Vector3(XDir, 1, 1);
        float offset = Random.Range(-1.5f, 1.5f);
        gameObject.transform.Translate(0, offset, offset);
    }

    public bool Detect()
    {
        List<BaseUnit> targets = BattleManager.Instance.GetOppositeUnits(CampType);
        foreach (BaseUnit enemy in targets)
        {
            float distance = Mathf.Abs(enemy.LogicX - LogicX);
            if (AttackRange >= distance - HitRange / 2) return true;
        }
        return false;
    }

    public void PlaySound(string soundKey)
    {
        if (string.IsNullOrEmpty(soundKey)) return;

        if (!soundCache.TryGetValue(soundKey, out var clip))
        {
            clip = Addressables.LoadAssetAsync<AudioClip>(soundKey).WaitForCompletion();
            if (clip != null)
                soundCache[soundKey] = clip;
        }

        if (clip != null)
            audioSource.PlayOneShot(clip);
        else
            Debug.LogWarning($"[BaseUnit] 找不到语音 '{soundKey}' (角色: {Data?.unit_name ?? UnitId.ToString()})");
    }

    private const float BubblePadding = 0.5f;

    public void ShowBubble(string skillName)
    {
        if (bubbleInstance == null) return;

        var text = bubbleInstance.GetComponentInChildren<TMPro.TextMeshPro>();
        if (text != null)
        {
            text.text = skillName;
            float textWidth = text.GetPreferredValues().x;
            var sr = bubbleInstance.GetComponent<SpriteRenderer>();
            if (sr != null && sr.drawMode == SpriteDrawMode.Tiled)
                sr.size = new Vector2(textWidth + BubblePadding, sr.size.y);
        }

        bubbleInstance.SetActive(true);
        BattleManager.Instance.StartCoroutine(HideBubble());
    }

    private System.Collections.IEnumerator HideBubble()
    {
        yield return new UnityEngine.WaitForSeconds(1f);
        if (bubbleInstance != null)
            bubbleInstance.SetActive(false);
    }

    public void TakeDamage(int damage, int popupIndex, bool showVisual = true)
    {
        HP = Mathf.Max(0, HP - damage);
        Skill?.OnHit();

        if (showVisual)
        {
            Vector3 popupPos = new Vector3(
                (LogicX + 200) * 15 / 1160,
                gameObject.transform.position.y + 1.8f,
                gameObject.transform.position.z
            );
            BattleManager.Instance.ShowDamagePopup(popupPos, damage, popupIndex);
            BattleManager.Instance.ShakeCamera();
        }
    }

    public void Heal(int amount)
    {
        HP = Mathf.Min(MaxHP, HP + amount);
    }

    public void AddTP(int amount)
    {
        TP = Mathf.Min(MaxTP, TP + amount);
    }

    public void SpendTP(int amount)
    {
        TP = Mathf.Max(0, TP - amount);
    }
}
