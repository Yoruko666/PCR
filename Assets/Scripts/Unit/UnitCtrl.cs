using Spine;
using Spine.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UnitCtrl
{
    public int Id { get; private set; }
    public int SeType { get; private set; }

    public SkeletonAnimation spine;

    public UnitDataConfig DataConfig;
    public int Number;
    public float LogicX;
    public bool IsFriend => battleManager.GetMyUnitList().Contains(this);
    public int XDir => IsFriend ? 1 : -1;

    protected StateMachine stateMachine;

    private GameObject gameObject;

    public GameObject GameObject => gameObject;
    public Transform Transform => gameObject.transform;

    public long HP { get; private set; }
    public long MaxHP { get; private set; }
    public bool IsDead => HP <= 0;
    public bool IsAlive => HP > 0;
    public int TP { get; private set; }
    public int MaxTP { get; private set; }
    public int PhysicalAttack { get; private set; }
    public int MagicAttack { get; private set; }
    public int SkillLevel { get; set; }
    public int Level { get; set; } = 300;
    public float AttackRange { get; private set; }
    public readonly float HitRange = 112;

    public SkillManager Skill { get; private set; }
    public UnitActionController ActionController { get; private set; }
    public bool IsPaused { get; set; }
    private AudioSource audioSource;
    private Dictionary<string, AudioClip> soundCache = new();

    private static GameObject bubblePrefab;
    private GameObject bubbleInstance;
    private Spine.Bone headBone;
    private const string BubblePrefabKey = "fx_skill_bubble";

    private const float START_CAST_TIME = 0.3f;
    private const float START_CAST_TIME_STAND_BY = 2.5f;

    [SerializeField]
    private List<ShakeEffect> gameStartShakes;
    [SerializeField]
    private List<PrefabWithTime> gameStartEffects;
    [SerializeField]
    private List<PrefabWithTime> dieEffects;
    [SerializeField]
    private List<ShakeEffect> dieShakes;
    [SerializeField]
    private List<PrefabWithTime> damageEffects;
    [SerializeField]
    private List<ShakeEffect> damageShakes;
    public List<PrefabWithTime> SummonEffects;
    [SerializeField]
    private List<PrefabWithTime> idleEffects;
    [SerializeField]
    private List<PrefabWithTime> auraEffects;
    public float ShowTitleDelay;
    public float UnitAppearDelay;
    public float BossAppearDelay;
    public float BattleCameraSize;
    public float Scale;
    public float BossDeltaX;
    public float BossDeltaY;
    public float AllUnitCenter;
    public float BossBodyWidthOffset;
    public string SummonTargetAttachmentName;
    public string SummonAppliedAttachmentName;
    public bool IsGameStartDepthBack;
    public bool BossSortIsBack;
    public bool DisableFlash;
//  public List<AttachmentChangeData> SortFrontDiappearAttachmentChangeDataList;
    public bool IsForceLeftDir;
//  public List<PartsData> BossPartsList;
    public bool UseTargetCursorOver;
    public bool OneRemainingDisableEffect;
    public float OverCursorSize;
    [SerializeField]
    private bool damageNumCenterBone;
    public bool UseUbVoice3and4;
    public List<SkillEffectCtrl> HideOtherAuraEffect;
    /*
    public VoiceTimingGroup UnionBurstPlusTimingWithCutin;
    public VoiceTimingGroup UnionBurstPlusTimingNoCutin;
    public List<VoiceDelayAndEnable> SpeedUpSkillNameVoiceDelayWithCutIn;
    public List<VoiceDelayAndEnable> NormalSkillNameVoiceDelay;
    public List<VoiceDelayAndEnable> NormalSkillNameVoiceDelayWithCutIn;
    public List<VoiceDelayAndEnable> SpeedUpSkillNameVoiceDelay;
    public List<VoiceDelayAndEnable> NormalSkillVoiceDelay;
    public List<VoiceDelayAndEnable> NormalSkillVoiceDelayWithCutIn;
    public List<VoiceDelayAndEnable> SpeedUpSkillVoiceDelay;
    public List<VoiceDelayAndEnable> SpeedUpSkillVoiceDelayWithCutIn;
    public List<VoiceDelayAndEnable> NormalSkillVoice3Delay;
    public List<VoiceDelayAndEnable> NormalSkillVoice3DelayWithCutIn;
    public List<VoiceDelayAndEnable> SpeedUpSkillVoice3Delay;
    public List<VoiceDelayAndEnable> SpeedUpSkillVoice3DelayWithCutIn;
    public List<VoiceDelayAndEnable> NormalSkillVoice4Delay;
    public List<VoiceDelayAndEnable> NormalSkillVoice4DelayWithCutIn;
    public List<VoiceDelayAndEnable> SpeedUpSkillVoice4Delay;
    public List<VoiceDelayAndEnable> SpeedUpSkillVoice4DelayWithCutIn;
    public List<VoiceDelayAndEnable> SpeedUpCutInVoiceDelay;
    public List<VoiceDelayAndEnable> NormalCutInVoiceDelay;
    public List<VoiceDelayAndEnable> SpeedUpCutInVoiceDelayWithCutIn;
    public List<VoiceDelayAndEnable> NormalCutInVoiceDelayWithCutIn;
    private static StaticSingletonTree<UnitCtrl> staticSingletonTree;
    private static IBattleLog staticBattleLog;
    private static IBattleCameraEffectForUnitCtrl staticBattleCameraEffect;
    private static IBattleEffectPool staticBattleEffectPool;
    private static IBattleTimeScaleForUnitCtrl staticBattleTimeScale;
    private bool <IsMoveSpeedForceZero>k__BackingField;
    */

	private static BattleManager staticBattleManager;
    public UnitActionController UnitActionController { get; set; }
    /*
    public PrincessFormProcessor PrincessFormProcessor { get; set; }
    public IComponentAbnormal ComponentAbnormal { get; set; }
    public IComponentActionPattern ComponentActionPattern { get; set; }
    public IComponentAnimation ComponentAnimation { get; set; }
    public IComponentAnnihilation ComponentAnnihilation { get; set; }
    public IComponentBattleResult ComponentBattleResult { get; set; }
    public IComponentColor ComponentColor { get; set; }
    public IComponentCompare ComponentCompare { get; set; }
    public IComponentDamageControl ComponentDamageControl { get; set; }
    public IComponentLog ComponentLog { get; set; }
    public IComponentMultiPartsBoss ComponentMultiPartsBoss { get; set; }
    public IComponentParameter ComponentParameter { get; set; }
    public IComponentParameterClamped ComponentParameterClamped { get; set; }
    public IComponentPassiveSkill ComponentPassiveSkill { get; set; }
    public IComponentScaleChange ComponentScaleChange { get; set; }
    public IComponentSearchArea ComponentSearchArea { get; set; }
    public IComponentSortOrder ComponentSortOrder { get; set; }
    public IComponentSound ComponentSound { get; set; }
    public IComponentState ComponentState { get; set; }
    public IComponentUnionBurst ComponentUnionBurst { get; set; }
    */
    public Bone StateBone { get; set; }
    public Bone StateBoneModeChange { get; set; }
    public Bone CenterBone { get; set; }
    public Bone CenterBoneModeChange { get; set; }
    public List<SkillEffectCtrl> RepeatEffectList { get; set; }
    public List<SkillEffectCtrl> AuraEffectList { get; set; }
    public Dictionary<int, List<ValueTuple<SkillEffectCtrl, string>>> DamagedHpEffectDictionary { get; set; }
    public float BodyWidth { get; set; }
//  public SystemIdDefine.eWeaponSeType WeaponSeType { get; set; }
//  public SystemIdDefine.eWeaponMotionType WeaponMotionType { get; set; }
    public BattleSpineController UnitSpineCtrl { get; set; }
    public SkeletonRenderSeparator SkeletonRenderSeparator { get; set; }
    public BattleSpineController UnitSpineCtrlModeChange { get; set; }
//  public List<UnitUnionBurstTimeline> UnitUnionBurstTimelineList { get; set; }
//  public List<CircleEffectController> CircleEffectList { get; set; }
    public bool IsRecreated { get; set; }
    public bool MainSkill1Evolved { get; set; }
    public float DeltaTimeForPause { get; }
    public int PrefabId { get; set; }
    public int UnitInstanceId { get; set; }
    public bool TimeToDie { get; set; }
    public bool IsLeftDir { get; set; }
    public eUnitRespawnPos RespawnPos { get; set; }
    public eUnitRespawnPos SummonRespawnPos { get; set; }
    public UnitParameter UnitParameter { get; set; }
    public bool IsOther { get; set; }
    public bool IsBonusEnemy { get; set; }
    public bool IsPlayerUnit { get; }
//  public OOHFDGDNJCE.IMDMLLPFLAD SummonType { get; set; }
    public bool IsSummonOrPhantom { get; }
    public bool IsGuest { get; set; }
    public bool IsGuestFadeout { get; set; }
    public bool IsDivision { get; }
    public bool IsDivisionSourceForDamage { get; set; }
    public bool IsDivisionSourceForDie { get; set; }
    public bool IsPhantom { get; }
    public bool IsShadow { get; set; }
    public float OverlapPosX { get; set; }
    public List<long> ActionsTargetOnMe { get; set; }
//  public List<FirearmCtrl> FirearmCtrlsOnMe { get; set; }
    private int motionPrefix { get; set; }
    public int MotionPrefix { get; set; }
    public int PartsMotionPrefix { get; set; }
    public bool IsBoss { get; set; }
    public bool IsClanBattleOrSekaiEnemy { get; set; }
    public bool IsTrialBattleEnemy { get; set; }
    public bool IsAbyssBossEnemy { get; set; }
    public Dictionary<int, UnitCtrl> SummonUnitDictionary { get; set; }
    public UnitCtrl SummonSource { get; set; }
//  public JPEONCKFNEB CutInFrameSet { get; set; }
    public int SkillEnableFrame { get; set; }
    public Transform RotateCenter { get; set; }
    public Vector3 FixedCenterPos { get; }
    private Vector3 fixedCenterPos { get; set; }
    public Vector3 FixedStatePos { get; set; }
    public Vector3 ColliderCenter { get; set; }
    public Vector3 ColliderSize { get; set; }
    public int CurrentSkillId { get; set; }
    public Action OnIsFrontfalse { get; set; }
    public bool HasDieLoop { get; }
//  public VoiceTimingData SpecialVoiceTimingData { get; set; }
    public bool DisableSortOrderFrontOnBlackoutTarget { get; set; }
    public int SkinRarity { get; set; }
    public List<BattleSpineController> EffectSpineControllerList { get; set; }
    public float BaseX { get; set; }
//  public LifeGaugeController LifeGauge { get; set; }
    public bool IsDepthBack { get; set; }
    public bool IsForceLeftDirOrPartsBoss { get; }
    public float CastTimer { get; set; }
    public double SkillStackValDmg { get; set; }
    public double SkillStackVal { get; set; }
    public float MoveRate { get; set; }
    public bool IsAwakeMotion { get; set; }
    public bool StartDashDone { get; set; }
    public bool IsStartSkillExeced { get; set; }
//  public PrefabWithTime.eEffectDifficulty EffectDifficulty { get; set; }
    public Action<UnitCtrl> OnInitCallbackForUi { get; set; }
    public bool IsDamageNumCenterBoneEnable { get; }
    private Transform bottomTransform { get; set; }
    private bool isPaused { get; set; }
    private Vector2 leftDirScale { get; set; }
    private Vector2 rightDirScale { get; set; }
//  protected StaticSingletonTree<UnitCtrl> singletonTree { get; }
//  protected IBattleLog battleLog { get; }
//  protected IBattleCameraEffectForUnitCtrl battleCameraEffect { get; }
//  protected IBattleEffectPool battleEffectPool { get; }
//  protected IBattleTimeScaleForUnitCtrl battleTimeScale { get; }
    private float unionBurstSkillAreaWidth { get; set; }
    private Dictionary<int, float> castTimeDictionary { get; set; }
    public int Index { get; set; }
    public int IdentifyNum { get; set; }
    public int UnitId { get; set; }
    public int CharacterUnitId { get; set; }
    public int OriginalUnitId { get; set; }
    public int SDSkin { get; set; }
    public int IconSkin { get; set; }
    public int Rarity { get; set; }
    public int BattleRarity { get; set; }
    public ePromotionLevel PromotionLevel { get; set; }
    public int AtkType { get; set; }
    public float AtkRecastTime { get; set; }
    public int UnionBurstSkillId { get; set; }
    public List<int> LevelFixedSpSkillIdList { get; set; }
    public int Rupee { get; set; }
    public int RewardCount { get; set; }
    public List<int> TalentIds { get; set; }
    public float StartHpPercent { get; set; }
    public bool IsMoveSpeedForceZero { get; set; }
    public Dictionary<int, int> SkillLevels { get; set; }
    public Dictionary<int, eSpineCharacterAnimeId> AnimeIdDictionary { get; set; }
    public List<int> MainSkillIdList { get; set; }
    public List<int> SpecialSkillIdList { get; set; }
    public List<int> MainSkillEvolutionIdList { get; set; }
    public List<int> SpecialSkillEvolutionIdList { get; set; }
    public List<int> SubUnionBurstIdList { get; set; }
    public List<eSpineCharacterAnimeId> TreasureAnimeIdList { get; set; }
    public bool IsDeadBySetCurrentHp { get; set; }
    private BattleManager battleManager { get; }
    public Transform BottomTransform { get; }
    public bool Pause { get; set; }
    public bool IsPartsBoss { get; }

    public UnitCtrl(int id)
    {
        battleManager = BattleManager.Instance;

        Id = id;
        DataConfig = ConfigManager.Instance.GetUnitDataConfig(id);
        if (DataConfig == null)
        {
            Debug.LogError($"[UnitCtrl] 找不到角色数据: unit_id={id}");
            return;
        }
        SeType = DataConfig.se_type;

        gameObject = new GameObject(DataConfig.unit_name ?? id.ToString());
        audioSource = gameObject.AddComponent<AudioSource>();
        spine = gameObject.AddComponent<SkeletonAnimation>();
        spine.skeletonDataAsset = Addressables.LoadAssetAsync<SkeletonDataAsset>("spine_" + Id.ToString()).WaitForCompletion();
        spine.Initialize(true);
        headBone = spine.Skeleton.FindBone("head");

        int actualRarity = DataConfig.rarity;
        Rarity = actualRarity;
        var rarityConfig = ConfigManager.Instance.GetUnitRarityConfig(id, actualRarity);
        if (rarityConfig != null)
        {
            MaxHP = 99999999;
            HP = MaxHP;
            PhysicalAttack = Mathf.FloorToInt(rarityConfig.atk + rarityConfig.atk_growth * (Level - 1));
            MagicAttack = Mathf.FloorToInt(rarityConfig.magic_str + rarityConfig.magic_str_growth * (Level - 1));
        }
        else
        {
            Debug.LogWarning($"[UnitCtrl] 找不到稀有度数据: unit_id={id} rarity={actualRarity}");
            MaxHP = 1; 
            HP = 1;
            PhysicalAttack = 0; 
            MagicAttack = 0;
        }

        MaxTP = 1000;
        TP = 0;
        SkillLevel = 1;
        AttackRange = DataConfig.search_area_width;

        var skillMap = ConfigManager.Instance.GetUnitSkillData(id);

        stateMachine = new StateMachine(this);
        stateMachine.SetDefaultState(StateType.RunGameStart);
        Skill = new SkillManager(this, skillMap);

        ActionController = UnitActionJsonLoader.LoadAndPopulate(id.ToString(), gameObject);
        if (ActionController != null)
        {
            ActionController.Owner = this;
            Skill.MergeJsonData(ActionController);
        }

        if (bubblePrefab == null)
            bubblePrefab = Addressables.LoadAssetAsync<GameObject>(BubblePrefabKey).WaitForCompletion();
        if (bubblePrefab != null)
        {
            bubbleInstance = GameObject.Instantiate(bubblePrefab, gameObject.transform);
            bubbleInstance.SetActive(false);
        }

        Debug.Log($"完成初始化 Id={Id}, HP={HP}, PhysicalAttack={PhysicalAttack}, MagicAttack={MagicAttack}");
    }

    public void Init(int orderNumber)
    {
        Number = orderNumber;
        InitLogicPosition();
        InitTransform();
    }

    public void UpdateFrame()
    {
        if (IsPaused || IsDead) return;

        if (bubbleInstance != null && bubbleInstance.activeSelf && headBone != null)
            bubbleInstance.transform.position = headBone.GetWorldPosition(spine.transform) + new Vector3(0, 1.2f, -0.01f);

        stateMachine.CheckSwitchState();
        stateMachine.OnTick();
    }

    public void PlayAnim(string animName, bool loop)
    {
        if (spine.Skeleton.Data.FindAnimation(animName) == null)
        {
            Debug.LogWarning($"[UnitCtrl] 找不到动画 '{animName}' (角色: {DataConfig?.unit_name ?? Id.ToString()})");
            return;
        }
        spine.AnimationState.SetAnimation(0, animName, loop);
    }

    public string GetAnimName(string animKey)
    {
        string se = SeType.ToString("D2");
        return animKey switch
        {
            "run_game_start" => $"{se}_run_gamestart",
            "stand_by"       => $"{se}_standBy",
            "run"            => $"{se}_run",
            "idle"           => $"{se}_idle",
            _                => animKey,
        };
    }

    public string GetStateAnimName(StateType state)
    {
        return state switch
        {
            StateType.RunGameStart => GetAnimName("run_game_start"),
            StateType.StandBy      => GetAnimName("stand_by"),
            StateType.Run          => GetAnimName("run"),
            StateType.Idle         => GetAnimName("idle"),
            StateType.Action       => Skill?.GetSkillAnimName(Skill.PendingSkill),
            StateType.Ub           => Skill?.GetSkillAnimName(Skill.PendingSkill),
            _                      => null,
        };
    }

    public string GetStateSoundName(StateType state)
    {
        return state switch
        {
            StateType.Action => GetSkillSoundName(Skill.PendingSkill),
            StateType.Ub     => GetSkillSoundName(Skill.PendingSkill),
            _                => null,
        };
    }

    public string GetSkillSoundName(Skill skill)
    {
        if (skill == null) return null;

        string prefix = $"vo_btl_{Id:D6}";
        return skill.Slot switch
        {
            1    => $"{prefix}_attack_001",
            1001 => $"{prefix}_skill_100",
            1002 => $"{prefix}_skill_200",
            1000 => UnityEngine.Random.Range(0, 2) == 0 ? $"{prefix}_ub_100" : $"{prefix}_ub_200",
            _    => $"{prefix}_skill_100",
        };
    }

    public void Move()
    {
        LogicX += 7.5f * XDir;
        SetLogicPosition(LogicX);
    }

    public void SetLogicPosition(float x)
    {
        LogicX = x;
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
        float offset = UnityEngine.Random.Range(-1.5f, 1.5f);
        gameObject.transform.Translate(0, offset, offset);
    }

    public bool Detect()
    {
        List<UnitCtrl> targets = GetEnemyList();
        foreach (UnitCtrl enemy in targets)
        {
            if (enemy.IsDead) continue;
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
            Debug.LogWarning($"[UnitCtrl] 找不到语音 '{soundKey}' (角色: {DataConfig?.unit_name ?? Id.ToString()})");
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
        battleManager.StartCoroutine(HideBubble());
    }

    private System.Collections.IEnumerator HideBubble()
    {
        yield return new UnityEngine.WaitForSeconds(1f);
        if (bubbleInstance != null)
            bubbleInstance.SetActive(false);
    }

    public void TakeDamage(long damage, int popupIndex, bool showVisual = true)
    {
        if (IsDead) return;

        HP = Math.Max(0, HP - damage);
        Skill?.OnHit();

        Debug.Log($"TakeDamage:{Id}, HP={HP}");

        if (showVisual)
        {
            Vector3 popupPos = new Vector3(
                (LogicX + 200) * 15 / 1160,
                gameObject.transform.position.y + 1.8f,
                gameObject.transform.position.z
            );
            battleManager.ShowDamagePopup(popupPos, damage, popupIndex);
            battleManager.ShakeCamera();
        }

        if (IsDead)
            OnDeath();
    }

    protected virtual void OnDeath()
    {
        IsPaused = true;
        bubbleInstance?.SetActive(false);
        spine.gameObject.SetActive(false);
    }

    public void Heal(int amount)
    {
        HP = Math.Min(MaxHP, HP + amount);
        Debug.Log($"Heal:{Id}, HP={HP}");
    }

    public void AddTP(int amount)
    {
        TP = Math.Min(MaxTP, TP + amount);
        Debug.Log($"AddTP:{Id}, TP={TP}");
    }

    public void SpendTP(int amount)
    {
        TP = Math.Max(0, TP - amount);
    }

    public void Dispose()
    {
        if (bubbleInstance != null)
        {
            GameObject.Destroy(bubbleInstance);
            bubbleInstance = null;
        }
        if (audioSource != null)
            GameObject.Destroy(audioSource);
        if (spine != null)
            GameObject.Destroy(spine);
        if (gameObject != null)
        {
            GameObject.Destroy(gameObject);
            gameObject = null;
        }
        soundCache.Clear();
        stateMachine = null;
        Skill = null;
    }

    public List<UnitCtrl> GetFriendList() => (battleManager.GetMyUnitList().Contains(this) ? battleManager.GetMyUnitList() : battleManager.GetEnemyUnitList());

    public List<UnitCtrl> GetEnemyList() => (battleManager.GetMyUnitList().Contains(this) ? battleManager.GetEnemyUnitList() :battleManager.GetMyUnitList());
}
