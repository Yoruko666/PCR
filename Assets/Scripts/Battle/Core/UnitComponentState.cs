using System;
using System.Collections;
using System.Collections.Generic;

namespace Elements.Battle.Core
{
    public class UnitComponentState : UnitComponentBase, IUnitComponent
    {
        private const int DIE_MOTION1 = 1;
        private const int SUMMON_INDEX_INVALID_VALUE = -1;
        private const int MULTI_TARGET_CURSOR_DEPTH = 100;

        private float resumeTime;
        private bool resumeIsStopState;
        private bool animeLoop;
        private string animeName;
        private SkillEffectCtrl runSmokeEffect;
        public Action<UnitCtrl> OnDieForZeroHp;
        public Action<UnitCtrl> OnDieFadeOutEnd;

        public delegate void OnDeadDelegate(UnitCtrl owner);
        public OnDeadDelegate OnDeadForRevival { get; set; }

        private BattleManager battleManager { get; set; }
        private SoundManager soundManager { get; set; }
        private Elements.Battle.Core.UnitComponentAbnormal componentAbnormal { get; set; }
        private Elements.Battle.Core.UnitComponentAnimation componentAnimation { get; set; }
        private Elements.Battle.Core.UnitComponentActionPattern componentAttackPattern { get; set; }
        private Elements.Battle.Core.UnitComponentColor componentColor { get; set; }
        private Elements.Battle.Core.UnitComponentMultiPartsBoss componentMultiPartsBoss { get; set; }
        private Elements.Battle.Core.UnitComponentDamageControl componentDamageControl { get; set; }
        private UnitComponentParameter componentParameter { get; set; }
        private Elements.Battle.Core.UnitComponentPassiveSkill componentPassiveSkill { get; set; }
        private Elements.Battle.Core.UnitComponentSearchArea componentSearchArea { get; set; }
        private Elements.Battle.Core.UnitComponentSortOrder componentSortOrder { get; set; }
        private Elements.Battle.Core.UnitComponentSound componentSound { get; set; }
        private Elements.Battle.Core.UnitComponentUnionBurst componentUnionBurst { get; set; }
        private Elements.Battle.Core.PresetBattleEffectData battleEffectData { get; set; }
        public Elements.Battle.Core.ActionState CurrentState { get; set; }

        public bool IdleOnly { get; set; }
        public bool IsDead { get; set; }
        public bool StartStateIsWalk { get; set; }
        public bool StandByDone { get; set; }
        public bool WaveStartIdle { get; set; }
        public bool HasUnDeadTime { get; set; }
        public int UnDeadTimeHitCount { get; set; }
        public bool HasEndUnionBurstAnimeForIfAction { get; set; }
        public bool IsSubUnionBurstMode { get; set; }
        public bool IsStartVoicePlay { get; set; }
        public bool IsModeChangeEnd { get; set; }
        public bool CancelByConvert { get; set; }
        public bool CancelByToad { get; set; }
        public bool ToadRelease { get; set; }
        public bool ToadReleaseDamage { get; set; }
        public bool DieInToad { get; set; }
        public bool IdleStartAfterWaitFrame { get; set; }
        public bool CancelByAwake { get; set; }
        public int CurrentTriggerSkillId { get; set; }
        public bool GameStartDone { get; set; }
        public bool IsStartActionForExtraEffect { get; set; }
        private int dieCoroutineId { get; set; }
        public bool IsOnBreakAllCallWhenGameStartDone { get; set; }
        private int damageCoroutineId { get; set; }
        private int walkCoroutineId { get; set; }
        public bool EnemyPointDone { get; set; }
        public bool WasDefeatCount { get; set; }
        public bool RevivalFlagForEnvironment { get; set; }
        public int EnemyPoint { get; set; }
        public long SpecialBattlePurposeHp { get; set; }
        public int PositionOrder { get; set; }
        public bool MultiTargetDone { get; set; }
        public bool ModeChangeUnableStateBarrier { get; set; }
        public bool MultiTargetByTime { get; set; }
        public int SpecialIdleMotionId { get; set; }
        private bool isRunForCatchUp { get; set; }
        public CutinVoiceStatus CutinVoiceStatus { get; set; }
        public bool HasSetStateCalled { get; set; }
        public bool IsNotPartsBossReady { get; set; }
        private List<SkillEffectCtrl> idleEffectsObjs { get; set; }
        private Dictionary<int, VoiceTypeAndSkillNumber> voiceTypeDictionary { get; set; }
        public Action<float> OnUpdateWhenIdle { get; set; }
        public Action OnBreakAll { get; set; }
        public Action OnMotionPrefixChanged { get; set; }

        public UnitComponentState(UnitCtrl _unitCtrl, BattleManager _battleManager, Elements.Battle.Core.PresetBattleEffectData _battleEffectData)
        {

        }

        public void SetState(ActionState _state, int _nextSkillId = 0, int _skillId = 0, bool _quiet = false)
        {
            MultiTargetCursor cursor;
            //internal void <SetState>b__0() { }
        }

        public IEnumerator SetStateWithDelayForRevival(float delay, Elements.Battle.Core.ActionState state, int nextSkillId = 0, int skillId = 0)
        {
            float time = 0;
        }

        private void setStateWalk() => SetState(ActionState.Walk);

        private void setStateAttack() => SetState(ActionState.Attack);

        private void setStateSkill(int skillId) => SetState(ActionState.Skill, _skillId: skillId);

        private void setStateUnionBurst()
        {
            SetState(ActionState.UnionBurst);
            // int unionBurstSkillId; 
            // internal bool <setStateUnionBurst>b__0(Skill e) { }
        }

        private void setStateDie() => SetState(ActionState.Die);


        private IEnumerator updateGameStart()
        {
            float time = 0;
            bool[] shakeStarted = new bool[4];
        }

        private IEnumerator updateGameStartMotionIdle()
        {
            float endTime = 0;
        }

        private IEnumerator updateStandBy() { }

        private IEnumerator updateWalk(int coroutineId)
        {

            // internal bool <updateWalk>b__294_0(UnitCtrl e) { }

            // internal bool <updateWalk>b__294_1(UnitCtrl e) { }
        }

        private IEnumerator updateIdle()
        {
            float fAlpha = 0;
        }

        private IEnumerator updateAttack(UnitActionController _actionController)
        {
            float alpha = 0;
        }

        private IEnumerator updateSkill(int skillId)
        {
            UnitActionController actionController;
        }

        private IEnumerator updateDamage(int _thisId)
        {
            float time = 0;
            bool isInitPause = false;
        }

        private IEnumerator updateDamageWhenIdle(bool _damageMotionWhenUnionBurst)
        {
            bool blackoutUnitContained = false;
        }

        private IEnumerator updateUnionBurst()
        {
            UnitActionController actionController;
            int unionBurstSkillId;
        }
        private IEnumerator updateDie(int _thisId)
        {
            float falpha = 0;
        }

        public void TryPlaySkillVoice(int _skillId) { }

        private IEnumerator updateUndoDivision() { }

        public bool IsCancelActionState(bool _isUnionBurst, int _skillId = -1) { }

        public IEnumerator CreatePrefabWithTime(List<PrefabWithTime> _data, bool _isIdle = false, int _summonIndex = -1, bool _isAura = false, bool _isShieldEffect = false, bool _ignorePause = false, int _damagedTriggerActionId = -1, bool _useTimeDelta = false)
        {
            float time = 0;
            bool[] effectCreated = new bool[_data.Count];


            // internal bool <CreatePrefabWithTime>b__308_1(PrefabWithTime e) { }
        }

        private IEnumerator updateDivisionDisappear() { }

        private IEnumerator updateModeChange() { }


        private IEnumerator waitBlackOutEndAndPlayLose() { }

        private bool isResumeSpecialSleepAnime() { }


        private void resumeSpineWithTime() { }

        private void playSubUbVoiceWithDelay(Skill _skill) { }


        private void playUbVoice3WithDelay() { }


        public void DisappearForDivision(bool _fadeOut, bool _useCoroutine) { }

        private bool judgeStateIsWalk()
        {
            return CurrentState == ActionState.Walk;
        }

        private bool isMultiBossDestructionTarget(int _enemyId) { }


        private void playUbVoice4WithDelay() { }

        private IEnumerator waitUndoMotionEnd(Action _callback, bool _isTimeOver) 
        {
            float deltaTimeAccumulated = 0;
        }

        private void playUbNameVoiceWithDelay() { }

        public void AddVoiceTypeAndSkillNumber(int _key, Elements.Battle.Core.VoiceTypeAndSkillNumber _data) { }

        public void PlayDamageWhenIdle(bool _damageMotionWhenUnionBurst = False, bool _pauseStopState = False) { }

        private bool judgeWalkEnd(int _coroutineId) { }

        public void DeleteDamagedHpAuraEffect(int _actionId) { }

        public void PlayDieEffect() { }

        private IEnumerator playUbVoiceWithDelay(VoiceDelayAndEnable _data, int _index, Skill _skill, int _skillNum, bool _isSubUnionBurst) 
        {
            float time = 0;
            float delay = 0;
        }

        public void PlayAndSetUpMultiTarget(bool _isFirst) 
        {
            //public BlockLayerManager blockLayerManager; 
            //public Elements.Battle.Core.UnitComponentState <>4__this; 
            //internal void <PlayAndSetUpMultiTarget>b__1() { }
            
            //public MultiTargetCursor cursor; 
            //public Elements.Battle.Core.UnitComponentState <>4__this; 
            //internal void <PlayAndSetUpMultiTarget>b__2() { }

            // internal bool <PlayAndSetUpMultiTarget>b__264_0(PartsData e) { }
        }

        public void StartLoseMotion() { }

        public void RegisterComponentSet(Elements.Battle.Core.IUnitComponentContainer _container) { }

        private bool isPauseDamageMotion() { }

        public IEnumerator PlayCutInVoiceWithDelay(VoiceDelayAndEnable _data, int _voiceId, bool _withCutin) 
        {
            float time = 0;
        }

        public void StartUndoDivision(Action _callback, bool _isTimeOver) { }

        private void playUbVoiceWithDelay() { }

        private IEnumerator startShakeWithDelay(ShakeEffect shake, bool _ignorePause = False) 
        {
            float time = 0;
        }

        private void playVoiceDataList(List<VoiceDelayAndEnable> _dataList, int _id, int _skillNum = 0) 
        {
            // int unionBurstSkillId; 
            //internal bool <playVoiceDataList>b__0(Skill e) { }
        }

        public void SkillEndProcess() { }

        public void CreateRunSmoke() { }

        private bool isResumeDamageAnimationFromStopStateTime() { }

        private bool judgePlayVoice(string _voiceName, int _maxNum, bool _isSkill, float _voiceOffsetRate) 
        {
            //public string _voiceName; 
            //public int counter; 
            //public int _maxNum; 
            //public bool playVoice; 

            //internal void <judgePlayVoice>b__0(List<UnitCtrl> list) { }
        }
        private void tryPlayMultiBossAppear()
        {
            //internal bool <tryPlayMultiBossAppear>b__265_0(UnitCtrl e) { }
        }
    }
}