using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Elements.Battle.Core;

namespace Elements
{ 
    public class UnitCtrl : FixedTransformMonoBehavior, ISingletonField, IUnitComponentContainer
    {
        public int UnitId { get; set; }

        private const float START_CAST_TIME = 0.3f;
        private const float START_CAST_TIME_STAND_BY = 2.5f;

	    public Dictionary<int, int> SkillUseCount; 
        public int CurrentRotateCoroutineId; 
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
        public List<AttachmentChangeData> SortFrontDiappearAttachmentChangeDataList; 
        public bool IsForceLeftDir; 
        public List<PartsData> BossPartsList; 
        public bool UseTargetCursorOver; 
        public bool OneRemainingDisableEffect; 
        public float OverCursorSize; 
        [SerializeField]
        private bool damageNumCenterBone; 
        public bool UseUbVoice3and4; 
        public List<SkillEffectCtrl> HideOtherAuraEffect; 
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
        private static Yggdrasil<UnitCtrl> staticSingletonTree; 
        private static IBattleCameraEffectForUnitCtrl staticBattleCameraEffect; 
        private static IBattleEffectPool staticBattleEffectPool; 
        private static IBattleTimeScaleForUnitCtrl staticBattleTimeScale; 
	    private static BattleManager staticBattleManager; 
    
        public UnitActionController UnitActionController { get; set; }
        public Elements.Battle.Core.PrincessFormProcessor PrincessFormProcessor { get; set; }
        public Elements.Battle.Core.UnitComponentAbnormal ComponentAbnormal { get; set; }
        public UnitComponentActionPattern ComponentActionPattern { get; set; }
        public UnitComponentAnimation ComponentAnimation { get; set; }
        public Elements.Battle.Core.UnitComponentAnnihilation ComponentAnnihilation { get; set; }
        public Elements.Battle.Core.UnitComponentBattleResult ComponentBattleResult { get; set; }
        public Elements.Battle.Core.UnitComponentColor ComponentColor { get; set; }
        public Elements.Battle.Core.UnitComponentCompare ComponentCompare { get; set; }
        public Elements.Battle.Core.UnitComponentDamageControl ComponentDamageControl { get; set; }
        public Elements.Battle.Core.UnitComponentMultiPartsBoss ComponentMultiPartsBoss { get; set; }
        public UnitComponentParameter ComponentParameter { get; set; }
        public Elements.Battle.Core.UnitComponentParameterClamped ComponentParameterClamped { get; set; }
        public Elements.Battle.Core.UnitComponentPassiveSkill ComponentPassiveSkill { get; set; }
        public Elements.Battle.Core.UnitComponentChangeScale ComponentScaleChange { get; set; }
        public UnitComponentSearchArea ComponentSearchArea { get; set; }
        public Elements.Battle.Core.UnitComponentSortOrder ComponentSortOrder { get; set; }
        public UnitComponentSound ComponentSound { get; set; }
        public UnitComponentState ComponentState { get; set; }
        public UnitComponentUnionBurst ComponentUnionBurst { get; set; }
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
//      public Elements.Battle.Core.SummonAction.eSummonType SummonType { get; set; }
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
        public Elements.Battle.Core.CutInFrameData CutInFrameSet { get; set; }
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
        public float CastTimer { get; set; }
        public double SkillStackValDmg { get; set; }
        public double SkillStackVal { get; set; }
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
        protected IBattleCameraEffectForUnitCtrl battleCameraEffect { get; }
        protected IBattleEffectPool battleEffectPool { get; }
        protected IBattleTimeScaleForUnitCtrl battleTimeScale { get; }
        private float unionBurstSkillAreaWidth { get; set; }
        private Dictionary<int, float> castTimeDictionary { get; set; }
        public int Index { get; set; }
        public int IdentifyNum { get; set; }
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
        
        private void Awake() { }
        
        public void Initialize(UnitParameter _data, bool _isOther, bool _isFirstWave, bool _isGaugeAlwaysVisible, Dictionary<int, int> _talentLevelParameter, Dictionary<int, Dictionary<eParamType, int>> _talentBuffParameter, BattleSpineController _battleSpineController, Elements.Battle.Core.SummonAction.eSummonType _summonType = 0)
        {

        }
    
        public static void StaticRelease() { }

        public bool JudgeIsRarity6() { }
    
        public BattleSpineController GetCurrentSpineCtrl() { }
    
    
        protected override void DestructByOnDestroy() { }

        public void DestroyAndCoroutineRemove() { }

        /*
        private void <instantiateResources>b__597_0(eStateIconType _iconType, bool _enable) { }
        private void <instantiateResources>b__597_1(eStateIconType _iconType, int _num) { }
        private void <instantiateResources>b__597_2(eStateIconType _iconType, bool _enable) { }
        */
        private void instantiateResources() { }

        /*
        [Serializable]
        private sealed class UnitCtrl.<> c 
        {
    
            public static readonly UnitCtrl.<> c<>9; 
            public static Predicate<PrefabWithTime> <> 9__598_0; 
            public static Predicate<Slot> <> 9__598_1; 

            private static void .cctor() { }

            public void .ctor() { }

            internal bool < Initialize > b__598_0(PrefabWithTime e) { }

            internal bool < Initialize > b__598_1(Slot e) { }
        }
        
        [CompilerGenerated]
        private sealed class UnitCtrl.<> c__DisplayClass598_0 
        {
    
            public UnitCtrl<> 4__this; 
            public Elements.Data.MasterSkillData masterSkillParameter; 
            public UnitParameter _data; 
            public MasterDataManager masterDataManager; 




            public void .ctor() { }


            internal void < Initialize > b__2(List<int> idList, List < SkillLevelInfo > skillLevelInfoList, eSpineCharacterAnimeId animeId, SoundManager.eVoiceType voiceType) { }
        }


        [CompilerGenerated]
        private sealed class UnitCtrl.<> c__DisplayClass598_1 
        {
    
            public int skillId; 

            public void .ctor() { }

            internal bool < Initialize > b__3(SkillLevelInfo e) { }
        }


        [CompilerGenerated]
        private sealed class UnitCtrl.<> c__DisplayClass598_2 
        {
    
            public Elements.Data.MasterUnitSkillDataRf.UnitSkillDataRf skillRf; 

            public void .ctor() { }


            internal bool < Initialize > b__4(SkillLevelInfo e) { }
        }


        [CompilerGenerated]
        private sealed class UnitCtrl.<> c__DisplayClass598_3 
        {
    
            public AttachmentChangeData data; 

            public void .ctor() { }


            internal bool < Initialize > b__5(Slot e) { }


            internal bool < Initialize > b__6(Slot e) { }
        }

        */

        private void registerAllComponentSet() { }

        /*
        [CompilerGenerated]
        private sealed class UnitCtrl.<> c__DisplayClass600_0 
        {
    
            public int _baseSkillId; 

            public void .ctor() { }


            internal bool < searchSpSkillLevel > b__0(int _skillId) { }


            internal bool < searchSpSkillLevel > b__1(int _skillId) { }


            internal bool < searchSpSkillLevel > b__2(int _skillId) { }
        }
        */

        private int searchSpSkillLevel(int _baseSkillId, UnitParameter _unitParameter) { }

        private SkillEffectCtrl initializeCharaAuraEffect(GameObject _effectPrefab, string _targetBoneName, bool _isTrackRotation) { }

        public void HideLifeGauge() { }

        public void ExecActionOnStartAndDetermineInstanceID() { }

        public void BattleStartProcess(eUnitRespawnPos respawnPos) { }

        private IEnumerator updateAttackTarget()
        {
        }

        public void WaveStartProcess(bool _first) { }

        private void setIdleCastTime() { }
    
        public void ResetCastTime()
        {
            CastTimer = 0;
        }

        public void SetRecastTime(int _skillId) { }

        public void ResetPosForUserUnit(int index) { }

    
        private void resetPosForEnemyUnit(eUnitRespawnPos pos) { }
    
        private IEnumerator waitShadowAppear(float _oldMoveSpeed) 
        {
            float time = 0;
            float appearTime = 0;
            float actionTime = 0;
        }

    
        public void SetInitialOrder(int _order) { }

        private IEnumerator waitBossMotionEnd() 
        {

        }

    
        public void SetOverlapPos(float overlapPosX) { }

    
        public List<UnitCtrl> GetFriendList()
        {
        }

    
        public List<UnitCtrl> GetEnemyList()
        {

        }

    
        public void _Update() { }

    
        public void BattleRecovery(eBattleCategory _category) { }

    
        public void MoveToNext() { }

        private IEnumerator waitChargeEnergy(double _recoveryRate) { }

    
        public void SetLeftDirection(bool bLeftDir) { }

    
        public void SetDirectionAuto() { }

    
        private bool isNearestEnemyLeft() { }

        public void SetMotionResume() { }

    
        public void SetMotionPause() { }

    
        public void ChangeChargeSkill(int _skillNum, float _limitTime) { }

        private IEnumerator updateChangeSkillNum(int oldChargeSkillNum, float limitTime) 
        {
            float time = 0;
        }

        public IEnumerator UpdateSummon(int _skillNum, eUnitRespawnPos _respawnPos, Elements.Battle.Core.SummonAction.eMoveType _moveType, Vector3 _targetPosition, float _moveSpeed) 
        {
            string currentMotionName = "";
            Vector3 v = new Vector3();
            float duration = 0;
            float time = 0;
        }

    
        public void RestartPlayAnimeCoroutine(float _startTime, eSpineCharacterAnimeId _animeId, int _index, int _prefix) { }

    
        public void AppendCoroutine(IEnumerator _cr, ePauseType _pauseType, UnitCtrl _unit) { }

    
        private void onHpChanged(long _hp) { }

    
        public void SetCurrentHpForTowerTimeUp(long _hp) { }

    
        public void IndicateSkillName(string _skillName) { }

    
        public List<PrefabWithTime> GetDieEffects() { }

    
        public List<PrefabWithTime> GetAuraEffects() { }

    
        public void ExecSkillBySkillId(int _skillId, int _bonusId) { }

    
        public float GetCurrentZoom() { }

    
        public eBattleCategory GetBattleCategory() { }

        public eBattleResult GetBattleResult()
        {
            return battleManager.BattleResult;
        }

        public float GetBattleResultCameraScale() { }

        public float GetBattleDeltaTime() { }

        public int GetBattleFrameCount() { }

        public bool IsAuraRemainBattle() { }

        public void ChangeChildObjectLayer(int _layer) { }

        public bool GetIsPrincessFormUnionBurstRunning() { }

        public int GetSortOrderConsiderBlackout() { }
        public bool GetIsMuteVoice() { }

        public bool JudgeCanPlayVoice(SoundManager.eVoiceType _voiceType, int _enemyVoiceId) { }

        public void FadeoutSe(float _fadeSec) { }

        // private bool <PlayUbChainVoice>b__652_0(UnitCtrl unit) { }

        public void PlayUbChainVoice() { }

        public bool GetPlayNext() { }

        // private bool <SearchContinuousUnit>b__654_0(ContinuousUnit e) { }

        public ContinuousUnit SearchContinuousUnit() { }

        public void UpdateLastRetireVoiceTime() { }

        public void UpdateLastDamageVoiceTime() { }

        public void AppendBreakLog(UnitCtrl _source) { }

    
        public Dictionary<eParamType, PassiveActionValue> GetPassiveDictionaryByEnemy() { }

    
        public Dictionary<eParamType, PassiveActionValue> GetPassiveDictionaryByUnit() { }

    
        public void ResetThanksTargetUnit() { }

    
        public void ResetBattleCameraShakeEffect() { }

    
        public void PreparePrincessFormProcessor() { }

    
        public bool CanBattleManagerPlayCutIn() { }

        public SkillEffectCtrl GetEffect(GameObject _prefab, UnitCtrl _owner) { }

        public void StopZoomEffect() { }

        public void StartShake(ShakeEffect _shake, Skill _skill, UnitCtrl _unit) { }

        public bool GetSpeedUpFlag() { }

        public void SetSpineSortOrder(int _value) { }
    }
}