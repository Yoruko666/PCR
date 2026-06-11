using UnityEngine;
using Spine;
using Spine.Unity;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using TMPro;

public class BaseUnit
{
    public SkeletonAnimation spine;

    public UnitConfig Config;
    public string Id => Config.Id;
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
    public int AttackPower { get; private set; }
    public float AttackRange { get; private set; }
    public readonly float HitRange = 112;

    public SkillManager Skill { get; private set; }
    public bool IsPaused { get; set; }
    private AudioSource audioSource;
    private Dictionary<string, AudioClip> soundCache = new();

    private static GameObject bubblePrefab;
    private GameObject bubbleInstance;
    private Spine.Bone headBone;
    private const string BubblePrefabKey = "fx_skill_bubble";

    public BaseUnit(string id, CampType campType)
    {
        Config = ConfigManager.Instance.GetConfig(id);
        if (Config == null)
        {
            Debug.LogError($"[BaseUnit] 找不到角色配置: {id}");
            return;
        }

        gameObject = new GameObject(Config.Name ?? id);
        audioSource = gameObject.AddComponent<AudioSource>();
        spine = gameObject.AddComponent<SkeletonAnimation>();
        spine.skeletonDataAsset = Addressables.LoadAssetAsync<SkeletonDataAsset>(Config.SpineId).WaitForCompletion();
        spine.Initialize(true);
        headBone = spine.Skeleton.FindBone("head");

        CampType = campType;

        MaxHP = Config.MaxHP;
        HP = Config.MaxHP;
        MaxTP = 1000;
        TP = 0;
        AttackPower = Config.AttackPower;
        AttackRange = Config.AttackRange;

        stateMachine = new StateMachine(this);
        stateMachine.SetDefaultState(StateType.RunGameStart);
        Skill = new SkillManager(this, Config.UbSkillId, Config.Skill1Id, Config.Skill2Id);

        // 预创建气泡
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

        // 气泡跟随头部骨骼
        if (bubbleInstance != null && bubbleInstance.activeSelf && headBone != null)
            bubbleInstance.transform.position = headBone.GetWorldPosition(spine.transform) + new Vector3(0, 1.2f, -0.01f);

        Skill.Tick(BattleManager.TickTime);
        stateMachine.CheckSwitchState();
        stateMachine.OnTick();
    }

    public void PlayAnim(string animName, bool loop)
    {
        spine.AnimationState.SetAnimation(0, animName, loop);
    }

    public string GetAnimName(string animKey)
    {
        return animKey switch
        {
            "run_game_start"    => Config.AnimRunGameStart,
            "stand_by"          => Config.AnimStandBy,
            "run"               => Config.AnimRun,
            "attack"            => Config.AnimAttack,
            "idle"              => Config.AnimIdle,
            _                   => animKey
        };
    }

    public void Move()
    {
        LogicX += 7.5f * XDir;
        SetLogicPosition(LogicX);
    }

    // 战斗场景设置x坐标限定为-15~15
    // 逻辑坐标总宽为2320
    // 逻辑坐标限定为-1360~960
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

    public void TakeDamage(int damage, int popupIndex)
    {
        HP = Mathf.Max(0, HP - damage);
        Skill?.OnHit();

        int displayDamage = Random.Range(10000, 100000);
        Vector3 popupPos = new Vector3(
            (LogicX + 200) * 15 / 1160,
            gameObject.transform.position.y + 1.8f,
            gameObject.transform.position.z
        );
        BattleManager.Instance.ShowDamagePopup(popupPos, displayDamage, popupIndex);
        BattleManager.Instance.ShakeCamera();
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

public enum CampType
{
    Friend,
    Enemy
}
