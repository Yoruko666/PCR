using System.Collections.Generic;
using UnityEngine;

public class UnitCtrl : FixedTransformMonoBehavior, ISingletonField, IUnitComponentContainer 
{
	// Fields
	private const float START_CAST_TIME = 0.3;
	private const float START_CAST_TIME_STAND_BY = 2.5;
	
	[SerializeField]
	private List<ShakeEffect> gameStartShakes; // 0x2A0
	[SerializeField]
	private List<PrefabWithTime> gameStartEffects; // 0x2A8
	[SerializeField]
	private List<PrefabWithTime> dieEffects; // 0x2B0
	[SerializeField]
	private List<ShakeEffect> dieShakes; // 0x2B8
	[SerializeField]
	private List<PrefabWithTime> damageEffects; // 0x2C0
	[SerializeField]
	private List<ShakeEffect> damageShakes; // 0x2C8
	public List<PrefabWithTime> SummonEffects; // 0x2D0
	[SerializeField]
	private List<PrefabWithTime> idleEffects; // 0x2D8
	[SerializeField]
	private List<PrefabWithTime> auraEffects; // 0x2E0
	[SerializeField]
	public float ShowTitleDelay; // 0x2E8
	[SerializeField]
	public float UnitAppearDelay; // 0x2EC
	[SerializeField]
	public float BossAppearDelay; // 0x2F0
	[SerializeField]
	public float BattleCameraSize; // 0x2F4
	public float Scale; // 0x2F8
	public float BossDeltaX; // 0x2FC
	public float BossDeltaY; // 0x300
	public float AllUnitCenter; // 0x304
	public float BossBodyWidthOffset; // 0x308
	public string SummonTargetAttachmentName; // 0x310
	public string SummonAppliedAttachmentName; // 0x318
	public bool IsGameStartDepthBack; // 0x320
	public bool BossSortIsBack; // 0x321
	public bool DisableFlash; // 0x322
	public List<AttachmentChangeData> SortFrontDiappearAttachmentChangeDataList; // 0x328
	public bool IsForceLeftDir; // 0x330
	public List<PartsData> BossPartsList; // 0x338
	public bool UseTargetCursorOver; // 0x340
	public bool OneRemainingDisableEffect; // 0x341
	public float OverCursorSize; // 0x344
	[SerializeField]
	private bool damageNumCenterBone; // 0x348
	public bool UseUbVoice3and4; // 0x349
	public List<SkillEffectCtrl> HideOtherAuraEffect; // 0x350
	public VoiceTimingGroup UnionBurstPlusTimingWithCutin; // 0x358
	public VoiceTimingGroup UnionBurstPlusTimingNoCutin; // 0x360
	public List<VoiceDelayAndEnable> SpeedUpSkillNameVoiceDelayWithCutIn; // 0x368
	public List<VoiceDelayAndEnable> NormalSkillNameVoiceDelay; // 0x370
	public List<VoiceDelayAndEnable> NormalSkillNameVoiceDelayWithCutIn; // 0x378
	public List<VoiceDelayAndEnable> SpeedUpSkillNameVoiceDelay; // 0x380
	public List<VoiceDelayAndEnable> NormalSkillVoiceDelay; // 0x388
	public List<VoiceDelayAndEnable> NormalSkillVoiceDelayWithCutIn; // 0x390
	public List<VoiceDelayAndEnable> SpeedUpSkillVoiceDelay; // 0x398
	public List<VoiceDelayAndEnable> SpeedUpSkillVoiceDelayWithCutIn; // 0x3A0
	public List<VoiceDelayAndEnable> NormalSkillVoice3Delay; // 0x3A8
	public List<VoiceDelayAndEnable> NormalSkillVoice3DelayWithCutIn; // 0x3B0
	public List<VoiceDelayAndEnable> SpeedUpSkillVoice3Delay; // 0x3B8
	public List<VoiceDelayAndEnable> SpeedUpSkillVoice3DelayWithCutIn; // 0x3C0
	public List<VoiceDelayAndEnable> NormalSkillVoice4Delay; // 0x3C8
	public List<VoiceDelayAndEnable> NormalSkillVoice4DelayWithCutIn; // 0x3D0
	public List<VoiceDelayAndEnable> SpeedUpSkillVoice4Delay; // 0x3D8
	public List<VoiceDelayAndEnable> SpeedUpSkillVoice4DelayWithCutIn; // 0x3E0
	public List<VoiceDelayAndEnable> SpeedUpCutInVoiceDelay; // 0x3E8
	public List<VoiceDelayAndEnable> NormalCutInVoiceDelay; // 0x3F0
	public List<VoiceDelayAndEnable> SpeedUpCutInVoiceDelayWithCutIn; // 0x3F8
	public List<VoiceDelayAndEnable> NormalCutInVoiceDelayWithCutIn; // 0x400
	private static Yggdrasil<UnitCtrl> staticSingletonTree; // 0x0
	private static IBattleLog staticBattleLog; // 0x8
	private static IBattleCameraEffectForUnitCtrl staticBattleCameraEffect; // 0x10
	private static IBattleEffectPool staticBattleEffectPool; // 0x18
	private static IBattleTimeScaleForUnitCtrl staticBattleTimeScale; // 0x20
	private ObscuredBool <IsMoveSpeedForceZero>k__BackingField; // 0x494
	private static BattleManager staticBattleManager; // 0x28

	public UnitActionController UnitActionController { get; set; }
	public IBKNOJIGFLJ PrincessFormProcessor { get; set; }
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
	public Bone StateBone { get; set; }
	public Bone StateBoneModeChange { get; set; }
	public Bone CenterBone { get; set; }
	public Bone CenterBoneModeChange { get; set; }
	public List<SkillEffectCtrl> RepeatEffectList { get; set; }
	public List<SkillEffectCtrl> AuraEffectList { get; set; }
	[TupleElementNames(new[] { "effect", "boneName" })]
	public Dictionary<int, List<ValueTuple<SkillEffectCtrl, string>>> DamagedHpEffectDictionary { get; set; }
	public float BodyWidth { get; set; }
	public SystemIdDefine.eWeaponSeType WeaponSeType { get; set; }
	public SystemIdDefine.eWeaponMotionType WeaponMotionType { get; set; }
	public BattleSpineController UnitSpineCtrl { get; set; }
	public SkeletonRenderSeparator SkeletonRenderSeparator { get; set; }
	public BattleSpineController UnitSpineCtrlModeChange { get; set; }
	public List<UnitUnionBurstTimeline> UnitUnionBurstTimelineList { get; set; }
	public List<CircleEffectController> CircleEffectList { get; set; }
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
	public OOHFDGDNJCE.IMDMLLPFLAD SummonType { get; set; }
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
	public List<FirearmCtrl> FirearmCtrlsOnMe { get; set; }
	private int motionPrefix { get; set; }
	public int MotionPrefix { get; set; }
	public int PartsMotionPrefix { get; set; }
	public bool IsBoss { get; set; }
	public bool IsClanBattleOrSekaiEnemy { get; set; }
	public bool IsTrialBattleEnemy { get; set; }
	public bool IsAbyssBossEnemy { get; set; }
	public Dictionary<int, UnitCtrl> SummonUnitDictionary { get; set; }
	public UnitCtrl SummonSource { get; set; }
	public JPEONCKFNEB CutInFrameSet { get; set; }
	public int SkillEnableFrame { get; set; }
	public Transform RotateCenter { get; set; }
	public Vector3 FixedCenterPos { get; }
	private Vector3 fixedCenterPos { get; set; }
	public Vector3 FixedStatePos { get; set; }
	public Vector3 ColliderCenter { get; set; }
	public Vector3 ColliderSize { get; set; }
	public int CurrentSkillId { get; set; }
	public Action OnIsFrontFalse { get; set; }
	public bool HasDieLoop { get; }
	public VoiceTimingData SpecialVoiceTimingData { get; set; }
	public bool DisableSortOrderFrontOnBlackoutTarget { get; set; }
	public int SkinRarity { get; set; }
	public List<BattleSpineController> EffectSpineControllerList { get; set; }
	public float BaseX { get; set; }
	public LifeGaugeController LifeGauge { get; set; }
	public bool IsDepthBack { get; set; }
	public bool IsForceLeftDirOrPartsBoss { get; }
	public ObscuredFloat CastTimer { get; set; }
	public ObscuredDouble SkillStackValDmg { get; set; }
	public ObscuredDouble SkillStackVal { get; set; }
	public float MoveRate { get; set; }
	public bool IsAwakeMotion { get; set; }
	public bool StartDashDone { get; set; }
	public bool IsStartSkillExeced { get; set; }
	public PrefabWithTime.eEffectDifficulty EffectDifficulty { get; set; }
	public Action<UnitCtrl> OnInitCallbackForUi { get; set; }
	public bool IsDamageNumCenterBoneEnable { get; }
	private Transform bottomTransform { get; set; }
	private bool isPaused { get; set; }
	private Vector2 leftDirScale { get; set; }
	private Vector2 rightDirScale { get; set; }
	protected Yggdrasil<UnitCtrl> singletonTree { get; }
	protected IBattleLog battleLog { get; }
	protected IBattleCameraEffectForUnitCtrl battleCameraEffect { get; }
	protected IBattleEffectPool battleEffectPool { get; }
	protected IBattleTimeScaleForUnitCtrl battleTimeScale { get; }
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
	public ObscuredInt Rupee { get; set; }
	public ObscuredInt RewardCount { get; set; }
	public List<int> TalentIds { get; set; }
	public float StartHpPercent { get; set; }
	public ObscuredBool IsMoveSpeedForceZero { get; set; }
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

	private BattleManager get_battleManager()
    {
        return battleManager;
    }

	public Transform get_BottomTransform()
    {
        return bottomTransform;
    }

	public static void StaticRelease() { }

	public bool JudgeIsRarity6()
    {
        return Rarity == 6;
    }

	// RVA: 0x2173F5C Offset: 0x2173F5C VA: 0x2173F5C
	public BattleSpineController GetCurrentSpineCtrl() { }

	// RVA: 0x217A260 Offset: 0x217A260 VA: 0x217A260
	private void Awake() { }

	// RVA: 0x217A438 Offset: 0x217A438 VA: 0x217A438 Slot: 4
	protected override void DestructByOnDestroy() { }

	// RVA: 0x217A7D8 Offset: 0x217A7D8 VA: 0x217A7D8
	public void DestroyAndCoroutineRemove() { }

	// RVA: 0x217A88C Offset: 0x217A88C VA: 0x217A88C
	private void instantiateResources() { }

	// RVA: 0x217AB3C Offset: 0x217AB3C VA: 0x217AB3C
	public void Initialize(UnitParameter _data, bool _isOther, bool _isFirstWave, bool _isGaugeAlwaysVisible, Dictionary<int, int> _talentLevelParameter, Dictionary<int, Dictionary<eParamType, int>> _talentBuffParameter, BattleSpineController _battleSpineController, OOHFDGDNJCE.IMDMLLPFLAD _summonType = 0) { }

	// RVA: 0x2180B90 Offset: 0x2180B90 VA: 0x2180B90
	private void registerAllComponentSet() { }

	// RVA: 0x2180D28 Offset: 0x2180D28 VA: 0x2180D28
	private int searchSpSkillLevel(int _baseSkillId, UnitParameter _unitParameter) { }

	// RVA: 0x2180FD0 Offset: 0x2180FD0 VA: 0x2180FD0
	private SkillEffectCtrl initializeCharaAuraEffect(GameObject _effectPrefab, string _targetBoneName, bool _isTrackRotation) { }

	// RVA: 0x21814D0 Offset: 0x21814D0 VA: 0x21814D0
	public void HideLifeGauge() { }

	// RVA: 0x218153C Offset: 0x218153C VA: 0x218153C
	public void ExecActionOnStartAndDetermineInstanceID() { }

	// RVA: 0x21815B0 Offset: 0x21815B0 VA: 0x21815B0
	public void BattleStartProcess(eUnitRespawnPos respawnPos) { }

	[IteratorStateMachine(typeof(UnitCtrl.<updateAttackTarget>d__605))]
	// RVA: 0x21817E4 Offset: 0x21817E4 VA: 0x21817E4
	private IEnumerator updateAttackTarget() { }

	// RVA: 0x21818DC Offset: 0x21818DC VA: 0x21818DC
	public void WaveStartProcess(bool _first) { }

	// RVA: 0x2181C68 Offset: 0x2181C68 VA: 0x2181C68
	public void ResetCastTime() { }

	// RVA: 0x2182310 Offset: 0x2182310 VA: 0x2182310
	public void ResetPosForUserUnit(int index) { }

	// RVA: 0x2181DB8 Offset: 0x2181DB8 VA: 0x2181DB8
	private void resetPosForEnemyUnit(eUnitRespawnPos pos) { }

	[IteratorStateMachine(typeof(UnitCtrl.<waitShadowAppear>d__610))]
	// RVA: 0x218257C Offset: 0x218257C VA: 0x218257C
	private IEnumerator waitShadowAppear(float _oldMoveSpeed) { }

	// RVA: 0x218268C Offset: 0x218268C VA: 0x218268C
	public void SetInitialOrder(int _order) { }

	[IteratorStateMachine(typeof(UnitCtrl.<waitBossMotionEnd>d__612))]
	// RVA: 0x218260C Offset: 0x218260C VA: 0x218260C
	private IEnumerator waitBossMotionEnd() { }

	// RVA: 0x2182A3C Offset: 0x2182A3C VA: 0x2182A3C
	public void SetOverlapPos(float overlapPosX) { }

	// RVA: 0x2182B0C Offset: 0x2182B0C VA: 0x2182B0C
	public List<UnitCtrl> GetFriendList() { }

	// RVA: 0x2182BA8 Offset: 0x2182BA8 VA: 0x2182BA8
	public List<UnitCtrl> GetEnemyList() { }

	// RVA: 0x2182C44 Offset: 0x2182C44 VA: 0x2182C44
	public void _Update() { }

	// RVA: 0x2182D94 Offset: 0x2182D94 VA: 0x2182D94
	public void BattleRecovery(eBattleCategory _category) { }

	// RVA: 0x21834CC Offset: 0x21834CC VA: 0x21834CC
	public void MoveToNext() { }

	[IteratorStateMachine(typeof(UnitCtrl.<waitCargeEnergy>d__619))]
	// RVA: 0x218343C Offset: 0x218343C VA: 0x218343C
	private IEnumerator waitCargeEnergy(double _recoveryRate) { }

	// RVA: 0x21835CC Offset: 0x21835CC VA: 0x21835CC
	public void SetLeftDirection(bool bLeftDir) { }

	// RVA: 0x2183D10 Offset: 0x2183D10 VA: 0x2183D10
	public void SetDirectionAuto() { }

	// RVA: 0x2183D38 Offset: 0x2183D38 VA: 0x2183D38
	private bool isNearestEnemyLeft() { }

	// RVA: 0x21842B4 Offset: 0x21842B4 VA: 0x21842B4
	public bool get_Pause() { }

	// RVA: 0x2177164 Offset: 0x2177164 VA: 0x2177164
	public void set_Pause(bool value) { }

	// RVA: 0x2184418 Offset: 0x2184418 VA: 0x2184418
	public void SetMotionResume() { }

	// RVA: 0x21842BC Offset: 0x21842BC VA: 0x21842BC
	public void SetMotionPause() { }

	// RVA: 0x21844B8 Offset: 0x21844B8 VA: 0x21844B8
	public void ChangeChargeSkill(int _skillNum, float _limitTime) { }

	[IteratorStateMachine(typeof(UnitCtrl.<updateChangeSkillNum>d__629))]
	// RVA: 0x2184504 Offset: 0x2184504 VA: 0x2184504
	private IEnumerator updateChangeSkillNum(int oldChargeSkillNum, float limitTime) { }

	[IteratorStateMachine(typeof(UnitCtrl.<UpdateSummon>d__630))]
	// RVA: 0x218459C Offset: 0x218459C VA: 0x218459C
	public IEnumerator UpdateSummon(int _skillNum, eUnitRespawnPos _respawnPos, OOHFDGDNJCE.LDLJJMEKADE _moveType, Vector3 _targetPosition, float _moveSpeed) { }

	// RVA: 0x2184660 Offset: 0x2184660 VA: 0x2184660
	public void RestartPlayAnimeCoroutine(float _startTime, eSpineCharacterAnimeId _animeId, int _index, int _prefix) { }

	// RVA: 0x2181864 Offset: 0x2181864 VA: 0x2181864
	public void AppendCoroutine(IEnumerator _cr, ePauseType _pauseType, UnitCtrl _unit) { }

	// RVA: 0x21846B8 Offset: 0x21846B8 VA: 0x21846B8
	private void onHpChanged(long _hp) { }

	// RVA: 0x21847E8 Offset: 0x21847E8 VA: 0x21847E8
	public void SetCurrentHpForTowerTimeUp(long _hp) { }

	// RVA: 0x218496C Offset: 0x218496C VA: 0x218496C
	public void IndicateSkillName(string _skillName) { }

	// RVA: 0x218498C Offset: 0x218498C VA: 0x218498C
	public List<PrefabWithTime> GetDieEffects() { }

	// RVA: 0x2184994 Offset: 0x2184994 VA: 0x2184994
	public List<PrefabWithTime> GetAuraEffects() { }

	// RVA: 0x218499C Offset: 0x218499C VA: 0x218499C
	public void ExecSkillBySkillId(int _skillId, int _bonusId) { }

	// RVA: 0x21849F0 Offset: 0x21849F0 VA: 0x21849F0
	public float GetCurrentZoom() { }

	// RVA: 0x2184AC0 Offset: 0x2184AC0 VA: 0x2184AC0
	public eBattleCategory GetBattleCategory() { }

	// RVA: 0x2184B18 Offset: 0x2184B18 VA: 0x2184B18
	public eBattleResult GetBattleResult() { }

	// RVA: 0x2184B70 Offset: 0x2184B70 VA: 0x2184B70
	public float GetBattleResultCameraScale() { }

	// RVA: 0x2182D3C Offset: 0x2182D3C VA: 0x2182D3C
	public float GetBattleDeltaTime() { }

	// RVA: 0x2184BC8 Offset: 0x2184BC8 VA: 0x2184BC8
	public int GetBattleFrameCount() { }

	// RVA: 0x2184C68 Offset: 0x2184C68 VA: 0x2184C68
	public bool IsAuraRemainBattle() { }

	// RVA: 0x2184CC0 Offset: 0x2184CC0 VA: 0x2184CC0
	public void ChangeChildObjectLayer(int _layer) { }

	// RVA: 0x2184D4C Offset: 0x2184D4C VA: 0x2184D4C
	public bool GetIsPrincessFormUnionBurstRunning() { }

	// RVA: 0x2184DBC Offset: 0x2184DBC VA: 0x2184DBC
	public int GetSortOrderConsiderBlackout() { }

	// RVA: 0x2184E3C Offset: 0x2184E3C VA: 0x2184E3C
	public bool GetIsMuteVoice() { }

	// RVA: 0x2184E94 Offset: 0x2184E94 VA: 0x2184E94
	public bool JudgeCanPlayVoice(SoundManager.eVoiceType _voiceType, int _enemyVoiceId) { }

	// RVA: 0x2185048 Offset: 0x2185048 VA: 0x2185048
	public void FadeoutSe(float _fadeSec) { }

	// RVA: 0x21850EC Offset: 0x21850EC VA: 0x21850EC
	public void PlayUbChainVoice() { }

	// RVA: 0x21853D8 Offset: 0x21853D8 VA: 0x21853D8
	public bool GetPlayNext() { }

	// RVA: 0x2185430 Offset: 0x2185430 VA: 0x2185430
	public ContinuousUnit SearchContinuousUnit() { }

	// RVA: 0x218551C Offset: 0x218551C VA: 0x218551C
	public void UpdateLastRetireVoiceTime() { }

	// RVA: 0x218557C Offset: 0x218557C VA: 0x218557C
	public void UpdateLastDamageVoiceTime() { }

	// RVA: 0x2179AEC Offset: 0x2179AEC VA: 0x2179AEC
	public bool get_IsPartsBoss() { }

	// RVA: 0x21855DC Offset: 0x21855DC VA: 0x21855DC
	public void AppendBreakLog(UnitCtrl _source) { }

	// RVA: 0x21856F4 Offset: 0x21856F4 VA: 0x21856F4
	public Dictionary<eParamType, COOGCCJIDLF> GetPassiveDictionaryByEnemy() { }

	// RVA: 0x2185754 Offset: 0x2185754 VA: 0x2185754
	public Dictionary<eParamType, COOGCCJIDLF> GetPassiveDictionaryByUnit() { }

	// RVA: 0x21857B4 Offset: 0x21857B4 VA: 0x21857B4
	public void ResetThanksTargetUnit() { }

	// RVA: 0x218580C Offset: 0x218580C VA: 0x218580C
	public void ResetBattleCameraShakeEffect() { }

	// RVA: 0x2185934 Offset: 0x2185934 VA: 0x2185934
	public void PreparePrincessFormProcessor() { }

	// RVA: 0x2185954 Offset: 0x2185954 VA: 0x2185954
	public bool CanBattleManagerPlayCutIn() { }

	// RVA: 0x21859AC Offset: 0x21859AC VA: 0x21859AC
	public SkillEffectCtrl GetEffect(GameObject _prefab, UnitCtrl _owner) { }

	// RVA: 0x2185A94 Offset: 0x2185A94 VA: 0x2185A94
	public void StopZoomEffect() { }

	// RVA: 0x2185B70 Offset: 0x2185B70 VA: 0x2185B70
	public void StartShake(ShakeEffect _shake, Skill _skill, UnitCtrl _unit) { }

	// RVA: 0x2185C64 Offset: 0x2185C64 VA: 0x2185C64
	public bool GetSpeedUpFlag() { }

	// RVA: 0x2185D34 Offset: 0x2185D34 VA: 0x2185D34
	public void SetRecastTime(int _skillId) { }

	// RVA: 0x2185E1C Offset: 0x2185E1C VA: 0x2185E1C
	private void setIdleCastTime() { }

	// RVA: 0x2185F44 Offset: 0x2185F44 VA: 0x2185F44
	public void SetSpineSortOrder(int _value) { }

	// RVA: 0x2186080 Offset: 0x2186080 VA: 0x2186080
	public UnitCtrl() { }
}