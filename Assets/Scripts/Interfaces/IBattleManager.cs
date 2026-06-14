using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elements;

namespace Elements.Battle
{
    public interface IBattleManagerForBaseBattleProcessor
    {
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> BossList { get; set; }
        public abstract bool IsCurtain { get; set; }
        public abstract int GetMiliLimitTime();
        public abstract void CallbackRequestFinishBattle();
        public abstract void ResultApiSendExec(Action _execCallback, Action<int> _errorCallback);
        public abstract Coroutine StartCoroutine(IEnumerator routine);
        public abstract int GetUnitCtrlLength();
        public abstract UnitCtrl GetUnitCtrl(int _idx);
        public abstract int GetEnemyCtrlLength();
        public abstract UnitCtrl GetEnemyCtrl(int _idx);
        public abstract UnitCtrl FindEnemy(int _id);
        public abstract UnitCtrl GetBossUnit();
        public abstract IEnumerator RecreateDeadUnits(Action _callback, eBattleResult _battleResult);
        public abstract void RevivalAtFinishBattle();
        public abstract List<UnitHpInfo> CreateUnitHpInfoList(int _enemyViewerId, int _myViewerId);
        public abstract List<UnitHpInfoForFriendBattle> CreateUnitHpInfoListForFriendBattle(int _enemyViewerId, int _myViewerId);
        public abstract void SetupLosePlayVoiceUnitId();
        public abstract void StartResult();
        public abstract IEnumerator UpdateBossIdleMotion(BattleSpineController _unitSpineController, int _motionPrefix);
        public abstract void TurnOffAllEffects();
        public abstract void OffSkillExeScreen();
        public abstract void ChangeAllUnitDefaultShader();
        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);
    }

    public interface IBattleManagerForOnlyBaseBattleProcessor : IBattleManagerForBaseBattleProcessor
    {

        public abstract float DeltaTime { get; }
        public abstract int FrameRate { get; }
        public abstract bool IsSortBackBossBattle { get; set; }
        public abstract bool CanQuadruple { get; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract int CurrentWave { get; }
        public abstract bool IsActiveUnitTalentFormationBonus { get; }
        public abstract IEnumerator CallTimer(float time, Action onComplete);
        public abstract void PlayPartyUnitJoyMotion();
        public abstract void PlayFlatoutAfterMove(bool _isPlayUnitJoyMotion);
        public abstract IBattleCameraEffectForBattleProcessor GetBattleCameraEffectForBattleProcessor();
        public abstract IBattleTimeScaleForBattleProcessor GetIBattleTimeScaleForBattleProcessor();
        public abstract void GamePause(bool pause, bool _isBlackoutEnd);

        public abstract IEnumerator UpdateZoom(float _scale, float _posY);
        public abstract void OpenResultWinDialog();
        public abstract void ShowResultDialog();
        public abstract void PlayStory(Action _callback, int _storyId, bool _end);
        public abstract void NextWaveProcess();
        public abstract IEnumerator InitializeAndUpdateWalkPlayer(Action _onWalkEnd, bool _isOutOfSystemUpdate);
    }

    public interface IBattleManagerForQuestBattleProcessor : IBattleManagerForBaseBattleProcessor
    {

        public abstract int CurrentWave { get; }
        public abstract int FrameRate { get; }
        public abstract bool IsBossBattle { get; }
        public abstract eBattleClearType GetAutoClearType();
        public abstract void SetBattleResult(eBattleResult result);
    }

    public interface IBattleManagerForQuestReplayBattleProcessor : IBattleManagerForBaseBattleProcessor
    {

        public abstract int CurrentWave { get; }
        public abstract bool IsBossBattle { get; }
        public abstract void DisplayAliveUnitFront();
        public abstract int GetLatestClearStarNum();
        public abstract void GamePause(bool pause, bool _isBlackoutEnd);
        public abstract void StartCameraZoomReset(Action _callback);
    }

    public interface IBattleManagerForTrainingBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract int FrameRate { get; }
        public abstract int CurrentWave { get; }
        public abstract void SetBattleResult(eBattleResult result);
    }

    public interface IBattleManagerForStoryBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract void SetStoryBattleDataPrefab(StoryBattleData _storyBattleDataPrefab);
        public abstract IEnumerator StoryBattleAnimationUpdate();
        public abstract List<int> GetStoryIdListToStoryBattleData();
    }

    public interface IBattleManagerForTutorialBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract int CurrentWave { get; }
        public abstract int FrameRate { get; }
        public abstract float DeltaTime { get; }
        public abstract bool IsStartSkillExec { get; }
        public abstract void SetStartSkillExec(bool flag);
        public abstract UnitCtrl FindUnitForSoundUnitId(int soundUnitId);
        public abstract UnitCtrl FindEnemyForResourceId(int resourceId);
        public abstract void SetPauseTimeLimit(bool _flag);
        public abstract bool IsVoiceDownLoad();
    }

    public interface IBattleManagerForDungeonBattleProcessor : IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect
    {
        public abstract void DisplayAliveUnitFront();
        public abstract void UpdateSkillCounter(ContinuousUnit _continuousUnit, UnitCtrl _unitCtrl);
        public abstract eBattleClearType GetAutoClearType();
    }

    public interface IBattleManagerForDungeonSpecialBattleProcessor : IBattleManagerForDungeonBattleProcessor, IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect
    {
        public abstract void AddTempDataBattleLog();
        public abstract void GamePause(bool _pause, bool _isBlackoutEnd = false);
    }

    public interface IBattleManagerForArenaBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract bool CanQuadruple { get; }
        public abstract float DeltaTime { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract bool IsSuspendLose { get; }
        public abstract void OpenResultWinDialog();
        public abstract void ResetFieldTimeUp();
        public abstract void RemoveAllCoroutines();
    }

    public interface IBattleManagerForArenaReplayBattleProcessor : IBattleManagerForBaseBattleProcessor
    { }

    public interface IBattleManagerForGrandArenaBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract int CurrentWave { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract int PlayVoiceUnitId { get; set; }
        public abstract bool IsSuspendLose { get; }
        public abstract void PlayPartyUnitJoyMotion();
        public abstract IEnumerator CallTimer(float _time, Action _onComplete);
        public abstract List<UnitCtrl> GetAliveUnitList();
        public abstract void ShowResultDialog();
        public abstract void RemoveAllCoroutines();
    }

    public interface IBattleManagerForGrandArenaReplayBattleProcessor : IBattleManagerForBaseBattleProcessor
    { }

    public interface IBattleManagerForHatsuneBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract int CurrentWave { get; }
        public abstract void SetBattleResult(eBattleResult result);
    }

    public interface IBattleManagerForHatsuneBossBattleProcessor : IBattleManagerForBaseBattleProcessor
    {

        public abstract float DeltaTime { get; }
        public abstract long CurrentEnemyPoint { get; }
        public abstract List<int> KillOrder { get; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract void StartCoroutineBossLose();
        public abstract IEnumerator CallTimer(float time, Action onComplete);
        public abstract void AddTempDataBattleLog();
        public abstract void DeterminePositionOrder();
        public abstract eBattleClearType GetAutoClearType();
        public abstract void GamePause(bool _pause, bool _isBlackoutEnd);
    }

    public interface IBattleManagerForUekBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract float DeltaTime { get; }
        public abstract void StartCoroutineBossLose();
        public abstract void UekOnDeadLastUnit(UnitCtrl _unit, int _area);
    }

    public interface IBattleManagerForKaiserSubBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract float DeltaTime { get; }
        
        public abstract void StartCoroutineBossLose();
        public abstract IEnumerator CallTimer(float time, Action onComplete);
        public abstract void AddTempDataBattleLog();
        public abstract void DeterminePositionOrder();
    }

    public interface IBattleManagerForStoryRaidEventSubReplayBattleProcessor : IBattleManagerForKaiserSubBattleProcessor, IBattleManagerForBaseBattleProcessor, IBattleManagerForGeneralReplayBattleProcessor
    { }

    public interface IBattleManagerForClanBattleProcessor : IBattleManagerForBaseBattleProcessor
    {

        public abstract long TotalBossDamage { get; }
        public abstract long SekaiAccumulateDamage { get; }
        public abstract float TimeLimit { get; }
        public abstract void StartCoroutineBossLose();
        public abstract eBattleClearType GetAutoClearType();
        public abstract int GetStartRemainTime();
        public abstract int GetBattleElapsedTime();
        public abstract int GetRoundUpTimeLimit();
    }

    public interface IBattleManagerForReplayClanBattleProcessor : IBattleManagerForGeneralReplayBattleProcessor, IBattleManagerForBaseBattleProcessor
    {
        public abstract float DeltaTime { get; }
        public abstract void StartCoroutineBossLose();
    }

    public interface IBattleManagerForTowerBattleProcessor : IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect
    {

        public abstract float DeltaTime { get; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract int FrameRate { get; }
        public abstract int CurrentWave { get; }
        public abstract eBattleCategory BattleCategory { get; }
        public abstract void DisplayAliveUnitFront();
        public abstract List<TowerQueryUnit> CreateTowerQueryUnitList(bool _isEx, bool _isPlayer);
        public abstract void TowerOnDeadLastUnit(UnitCtrl _unit);
        public abstract void UpdateSkillCounter(ContinuousUnit _continuousUnit, UnitCtrl _unitCtrl);
        public abstract eBattleClearType GetAutoClearType();
        public abstract void PlayFlatoutAfterMove(bool _isPlayUnitJoyMotion);
        public abstract void RetireBattle();
        public abstract IEnumerator SetupPlayerResultPosition(Action _finishCallBack);
    }

    public interface IBattleManagerForTowerExBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {

        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract int FrameRate { get; }
        public abstract bool CanQuadruple { get; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract List<TowerQueryUnit> CreateTowerQueryUnitList(bool _isEx, bool _isPlayer);
        public abstract void DisplayAliveUnitFront();
        public abstract void OpenTowerExResultDialog(bool _isVictory, int _finalWaveIndex, bool _isFirst);
        public abstract void TowerOnDeadLastUnit(UnitCtrl _unit);
        public abstract void ShowResultDialog();
        public abstract eBattleClearType GetAutoClearType();
        public abstract void PlayFlatoutAfterMove(bool _isPlayUnitJoyMotion);
    }

    public interface IBattleManagerForBaseDimensionFaultBattleProcessor : IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect
    {
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract void DisplayAliveUnitFront();
        public abstract eBattleClearType GetAutoClearType();
        public abstract void StartCoroutineBossLose();
    }

    public interface IBattleManagerForDimensionFaultBattleProcessor : IBattleManagerForBaseDimensionFaultBattleProcessor, IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect
    {
        public abstract void UpdateSkillCounter(ContinuousUnit _continuousUnit, UnitCtrl _unitCtrl);
    }

    public interface IBattleManagerForDimensionFaultRehearsalBattleProcessor : IBattleManagerForBaseDimensionFaultBattleProcessor, IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect
    {
        public abstract void UpdateSkillCounter(ContinuousUnit _continuousUnit, UnitCtrl _unitCtrl);
    }

    public interface IBattleManagerForDimensionFaultTreasureBattleProcessor : IBattleManagerForBaseDimensionFaultBattleProcessor, IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect
    { }

    public interface IBattleManagerForGeneralReplayBattleProcessor : IBattleManagerForBaseBattleProcessor
    {

        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract int CurrentWave { get; set; }
        public abstract void DisplayAliveUnitFront();
        public abstract void UpdateSkillCounter(ContinuousUnit _continuousUnit, UnitCtrl _unitCtrl);
        public abstract BaseBattleProcessor CreateBattleProcessorImpl(UekTempData _uekTempData);
        public abstract void PlayFlatoutAfterMove(bool _isPlayUnitJoyMotion);
        public abstract IEnumerator CallTimer(float time, Action onComplete);
        public abstract IEnumerator SetupPlayerResultPosition(Action _finishCallBack);
    }

    public interface IBattleManagerForTowerReplayBattleProcessor : IBattleManagerForGeneralReplayBattleProcessor, IBattleManagerForBaseBattleProcessor 
    {
        public abstract float DeltaTime { get; }
    }

    public interface IBattleManagerForTowerReplayExBattleProcessor : IBattleManagerForGeneralReplayBattleProcessor, IBattleManagerForBaseBattleProcessor
    { }

    public interface IBattleManagerForTowerReplayExSingleBattleProcessor : IBattleManagerForGeneralReplayBattleProcessor, IBattleManagerForBaseBattleProcessor 
    {
        public abstract void OpenTowerExResultDialog(bool _isVictory, int _finalWaveIndex, bool _isFirst);
        public abstract void ShowResultDialog();
        public abstract void SetBattleResult(eBattleResult result);
    }
    public interface IBattleManagerForHighRarityQuestBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract float DeltaTime { get; }
        public abstract void HighRarityOnDeadLastUnit(UnitCtrl _unit, eBattleTreasureBoxType _treasureType);
        public abstract eBattleClearType GetAutoClearType();
    }

    public interface IBattleManagerForTimeUpDeadEffect 
    {
        public abstract void ForceFadeUnitOut();
    }

    public interface IBattleManagerForSpaceBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract float DeltaTime { get; }
        public abstract void StartCoroutineBossLose();
    }

    public interface IBattleManagerForTrialBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract long TotalBossDamage { get; }
        public abstract void StartCoroutineBossLose();
    }

    public interface IBattleManagerForColosseumBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract void SetBattleResult(eBattleResult result);
    }

    public interface IBattleManagerForTalentQuestBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract void DisplayAliveUnitFront();
        public abstract void SetBattleResult(eBattleResult result);
        public abstract eBattleClearType GetAutoClearType();
    }

    public interface IBattleManagerForAbyssBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract void DisplayAliveUnitFront();
        public abstract eBattleClearType GetAutoClearType();
    }

    public interface IBattleManagerForAbyssBossBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract void DisplayAliveUnitFront();
        public abstract eBattleClearType GetAutoClearType();
        public abstract void StartCoroutineBossLose();
    }

    public interface IBattleManagerForDomeBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract void SetBattleResult(eBattleResult result);
    }

    public interface IBattleManagerForBattleLog 
    {
        public abstract int CurrentWave { get; }
        public abstract int FrameCount { get; }
        public abstract int FrameRate { get; }
        public abstract bool IsSpecialBattle { get; }
        public abstract int GetSystemId();
        public abstract int GetCurrentWaveOffset();
    }

    public interface IBattleManagerForCameraEffect 
    {
        public abstract float DeltaTime { get; }
        public abstract Vector3 PlayCameraPos0 { get; }
        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);
        public abstract IEnumerator CallFade(float _from, float _to, float _duration, Action<float> _setFade, Action _onFinish);
        public abstract int GetBlackoutUnitTargetLength();
        public abstract UnitCtrl GetBlackoutUnitTarget(int _idx);
        public abstract void StartCoroutineIgnoreFps(IEnumerator _enumerator);
    }

    public interface IBattleManagerForBattleTimeScale 
    {
        public abstract float DeltaTime { get; }
        
        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);
        public abstract void StartCoroutineIgnoreFps(IEnumerator cr);
    }

    public interface IBattleManagerForDamageEffectCtrlBase
    {
        public abstract bool IsPauseFrameCount { get; }
        public abstract List<UnitCtrl> BlackoutUnitTargetList { get; }
        public abstract bool IsDefenseReplayMode { get; }
        public abstract bool HideDamageNumFlag { get; }
        public abstract eBattleGameState GameState { get; }
        public abstract bool IsPrincessSkillMovieRunning { get; set; }
        public abstract bool IsPrincessSkillMovieFirstHalfRunning { get; }
        public abstract bool CanPlaySe();
    }

    public interface IBattleManagerForSkillEffectCtrl 
    {
        public abstract bool IsValid { get; }
        public abstract float DeltaTime { get; }
        public abstract bool IsHatsuneBoss { get; }
        public abstract bool IsSpecialBattle { get; }
        public abstract bool IsTowerContent { get; }
        public abstract bool IsHighRarityQuest { get; }
        public abstract List<UnitCtrl> BlackOutUnitList { get; }
        public abstract List<UnitCtrl> BlackoutUnitTargetList { get; }
        public abstract bool IsDefenseReplayMode { get; }
        public abstract bool IsSortBackBossBattle { get; }
        public abstract eChargeSkillTurn ChargeSkillTurn { get; set; }
        public abstract long AbsorberValue { get; set; }
        public abstract void AppendEffect(SkillEffectCtrl _skillEffectCtrl, UnitCtrl _unit, bool _isAbnormal);
        public abstract void AddEffectToUpdateList(SkillEffectCtrl ef);
        public abstract void RemoveEffectToUpdateList(SkillEffectCtrl ef);
        public abstract Coroutine StartCoroutine(IEnumerator _routine);
        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);
        public abstract UnitCtrl GetBossUnit();
        public abstract void GamePause(bool _pause, bool _isBlackoutEnd = false);
        public abstract void SetSkillExeScreen(UnitCtrl _source, float blackoutTime, Color blackoutColor, bool _endWithMotion);
        public abstract float GetRespawnPos(eUnitRespawnPos _unitRespawnPos);
        public abstract bool CanPlaySe();
    }

    public interface IBattleManagerForBattleVoiceUtility 
    {

        public abstract BattleVoiceFlagManager BattleVoiceFlagMgr { get; }
        public abstract int PlayVoiceUnitId { get; set; }
        public abstract int PlayVoiceIndex { get; set; }
        public abstract bool PlayVoiceUnitIsRarity6 { get; set; }
        public abstract int PlayVoiceGroupId { get; set; }
        public abstract int PlayVoiceGroupUnitId { get; set; }
        public abstract bool IsDefenseReplayMode { get; set; }
        public abstract int FrameCount { get; }
    }

    public interface IBattleManagerForAbromalStateIconController
    {

        public abstract Coroutine StartCoroutine(IEnumerator _routine);

        public abstract void StopCoroutine(IEnumerator _routine);

        public abstract void OpenBonusDetailDialog();
    }

    public interface IBattleManagerForBattleHeaderController
    {

        public abstract bool IsClanBattle { get; }
        public abstract bool IsTowerContent { get; }
        public abstract bool IsTowerReplayContent { get; }
        public abstract bool IsDispTotalDamageBattle { get; }
        public abstract eBattleCategory BattleCategory { get; }
        public abstract bool IsStartSkillExec { get; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract CoroutineManager CoroutineManager { get; }
        public abstract bool IsSpecialBattle { get; }
        public abstract bool IsEndlessBattle { get; }
        public abstract bool IsDefenseBattle { get; }
        public abstract bool IsDefenseBattleInMode { get; }
        public abstract bool IsShowBossGauge { get; }
        public abstract long CurrentEnemyPoint { get; }
        public abstract float StartLimitTimeForDefense { get; }
        public abstract bool IsPlayingPauseEffect { get; }
        public abstract bool IsPlayingNoCutInMotion { get; set; }
        public abstract bool IsNoCutInMotionRightAfter { get; set; }
        public abstract bool CanReserveSkill { get; }
        public abstract long StartBattleUnixTime { get; }
        public abstract eBattleGameState GameState { get; }
        public abstract void GamePause(bool _pause, bool _isBlackoutEnd);
        public abstract void TutorialOpenFocusDialog();
        public abstract void ResumeAbnormalEffect();
        public abstract void RetireBattle();
        public abstract void PauseAbnormalEffect();
        public abstract int GetCurrentWaveOffset();
        public abstract eHatsuneSpecialPurpose GetPurpose();
        public abstract long GetPurposeCount();
        public abstract void InstantiatePointCounter(Transform _transform, ref PartsHastunePointCounter _counter);
        public abstract void InstantiateDefenseTimeGauge(Transform _transform, ref PartsHatsuneDefenseTimeGauge _gauge);
        public abstract void InstantiateSpeicalBattleModeWithoutGauge(Transform _parent, ref PartsSpecialBattleMode _specialBattleMode);
        public abstract bool GetIsPlayCutin();
        public abstract UnitCtrl GetBossUnit();
        public abstract bool IsQuestAutoProgressing();
        public abstract bool IsLocalReplay();
        public abstract int GetEnvironmentId(bool _isEnemy);
    }

    public interface IBattleManagerForPartsBossGauge 
    {
        public abstract bool IsDispTotalDamageBattle { get; }
        public abstract bool IsHatsuneBoss { get; }
        public abstract bool IsSpecialBattle { get; }
        public abstract bool IsAcnUnknownBattle { get; }
        public abstract bool IsTowerContent { get; }
        public abstract bool IsTowerReplayContent { get; }
        public abstract int GetCurrentWaveOffset();
        public abstract bool GetBossGaugeColorChange();
        public abstract float GetBossGaugeValue(long _currentHp);
        public abstract void SetSpecialBattleGaugeColor(UIProgressBar _gauge);
        public abstract bool IsDisplayBossHpUi();
    }

    public interface IBattleManagerForUnitUiCtrl
    {
        public abstract bool IsDefenseReplayMode { get; }
        public abstract float DeltaTime { get; }
        public abstract int FrameCount { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract int ServerDeadFrame { get; }
        public abstract eChargeSkillTurn ChargeSkillTurn { get; set; }
        public abstract List<UnitCtrl> BlackOutUnitList { get; }
        public abstract bool IsPauseFrameCount { get; }
        public abstract eBattleGameState GameState { get; }
        public abstract float TimeLimit { get; }
        public abstract bool CanQuadruple { get; }
        public abstract bool IsPrincessSkillRunning { get; }
        public abstract bool IsPrincessSkillMovieRunning { get; }
        public abstract bool IsGuestCutinPlaying { get; }
        public abstract bool IsPlayingNoCutInMotionForPSkill { get; }
        public abstract bool IsPlayingNoCutInMotion { get; }
        public abstract bool CanReserveSkill { get; }
        public abstract bool IsDefenseBattle { get; }
        public abstract bool IsTowerContent { get; }
        public abstract bool CanAllSetMode { get; }
        public abstract bool IsReplayContents { get; }
        public abstract bool IsTalentBonusEffectPlaying { get; }
        public abstract bool IsReleasedKnightEnhance { get; }
        public abstract void InitializePassiveSkillUnitList(List<UnitParameter> _unitList, ePassiveInitType _passiveInitType, int _waveNumber);
        public abstract void CreateUnit(int _unitId, Action<UnitCtrl> _callback, bool _addUnitList);
        public abstract void InitOnlyAutoClearFlag(bool _isUseAllSet);
        public abstract void DisableAutoClear();
        public abstract void CreateUnitSpine(UnitCtrl _unit, eUnitRespawnPos _respawnPos, UnitParameter _pParam, Action<UnitCtrl> _callback, bool _isOther);
        public abstract void GamePause(bool pause, bool _isBlackoutEnd);
        public abstract void TutorialSkillExec(GameObject _focus);
        public abstract void FadeOutAllVoices(float _fadeSec);
        public abstract void FadeOutAllSe(float _fadeSec);
        public abstract bool CanSkipBattle();
        public abstract bool IsQuestAutoProgressing();
        public abstract bool IsLocalReplay();
        public abstract void ExecuteSkipProcess(Action _callback);
        public abstract bool CanCreateBattleEffect();
        public abstract bool IsShowEffectiveIcon(int _unitId);
    }

    public interface IBattleManagerForLifeGaugeController
    {

        public abstract bool IsDefenseReplayMode { get; }
        public abstract float DeltaTime { get; }
        public abstract List<UnitCtrl> BlackOutUnitList { get; }
        public abstract bool IsColosseumBattle { get; }
        public abstract bool IsDomeBattle { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract Coroutine StartCoroutine(IEnumerator _routine);
        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);
    }

    public interface IBattleManagerForActionParameter
    {

        public abstract float TimeLimit { get; }
        public abstract int ChangeSpeedOverwriteFieldCounter { get; }
        public abstract float DeltaTime { get; }
        public abstract eBattleCategory BattleCategory { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract eChargeSkillTurn ChargeSkillTurn { get; set; }
        public abstract List<UnitCtrl> BlackOutUnitList { get; }
        public abstract eBattleGameState GameState { get; }
        public abstract bool CancelByAwake { get; set; }
        public abstract bool IsBossBattle { get; }
        public abstract long CurrentEnemyPoint { get; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract long AbsorberValue { get; }
        public abstract double DodgeTPRecoverRatio { get; }
        public abstract bool IsReleaseSkillHasteLogic { get; }
        public abstract void ExecField(FieldData _fieldData, int _actionId);
        public abstract void ExecEnvironment(EnvironmentData _environmentData, bool _isEnemySide);
        public abstract void ExecAllUnitSealDamageCut(GMAIPANNDLH _data, bool _enemySide);
        public abstract void StopField(int _actionId, eTargetAssignment _targetAssignment, bool _isOther);
        public abstract bool ExistsField(int _actionId, bool _isOther);
        public abstract void AddChangeSpeedOverwriteFieldCounter();
        public abstract void CallbackActionEnd(long actionId);
        public abstract void SetBlackoutTimeZero();
        public abstract UnitCtrl Summon(SummonData _summonData);
        public abstract void GamePause(bool pause, bool _isBlackoutEnd);
        public abstract void SetSkillExeScreen(UnitCtrl _cc, float _exeTime, Color _color, bool _endWithMotion);
        public abstract void CallbackDead(UnitCtrl _unit);
        public abstract void CheckAcnLosingBattleFinish();
        public abstract void CallbackFadeOutDone(UnitCtrl unit);
        public abstract void CallbackIdleOnlyDone(UnitCtrl unit);
        public abstract Coroutine StartCoroutine(IEnumerator routine);
        public abstract UnitCtrl GetBossUnit();
        public abstract void SubstructEnemyPoint(long _enemyPoint);
        public abstract void SetSkillEffectSortOrderBack();
        public abstract int GetBlackOutUnitLength();
        public abstract void DeleteBonusIcon(int _bonusId);
        public abstract bool ExistsEnvironment(int _id);
    }

    public interface IBattleManagerForFieldDataBase
    {

        public abstract int FieldIndex { get; set; }
        public abstract float DeltaTime { get; }
        public abstract eBattleGameState GameState { get; }
        public abstract Dictionary<int, int> EnvironmentCounterDic { get; set; }
        public abstract int CurrentEnvironmentId { get; set; }
        public abstract bool IsReleaseSkillHasteLogic { get; }

        public abstract void AppendEffect(SkillEffectCtrl _skillEffectCtrl, UnitCtrl _unit, bool _isAbnormal);

        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);

        public abstract int GetBlackOutUnitLength();

        public abstract float GetRespawnPos(eUnitRespawnPos _unitRespawnPos);

        public abstract void SubstructEnemyPoint(long _point);

        public abstract void DeleteBonusIcon(int _bonusId);

        public abstract void SetEnvironmentResume(bool _isEnemy);

    }

    public interface IBattleManagerForUbAbnormalData
    {

        public abstract float DeltaTime { get; }

        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);

    }

    public interface IBattleManagerForUnitActionController
    {

        public abstract UnitCtrl DecoyUnit { get; }
        public abstract UnitCtrl DecoyOther { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract CoroutineManager CoroutineManager { get; }
        public abstract List<UnitCtrl> BlackoutUnitTargetList { get; }
        public abstract float DeltaTime { get; }
        public abstract List<long> ExecutedActionList { get; }
        public abstract Dictionary<string, GameObject> ReActionEffectDictionary { get; }
        public abstract bool IsDefenseReplayMode { get; }
        public abstract bool IsNoCutInMotionRightAfter { set; }
        public abstract long AbsorberValue { get; }
        public abstract eChargeSkillTurn ChargeSkillTurn { get; }

        public abstract void SetSkillExeScreen(UnitCtrl _cc, float _exeTime, Color _color, bool _endWithMotion);

        public abstract void StartBackgroundSpineAnimation(int _skillId, float _skipTime);

        public abstract void AddBlackOutTarget(UnitCtrl _source, UnitCtrl _target, BasePartsData _parts);

        public abstract void SetSkillExeScreenActive(UnitCtrl _unit, Color _color);

        public abstract void CallbackActionEnd(long actionId);

        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);

        public abstract Coroutine StartCoroutine(IEnumerator routine);

        public abstract void StartChangeScale(Skill _skill, float _startTime);

        public abstract void SetForegroundEnable(bool _enable);

        public abstract bool IsSkipping();

        public abstract bool CanCreateBattleEffect();

    }

    public interface IBattleManagerForSocketIOManager
    {

        public abstract eBattleGameState GameState { get; }

        public abstract void GamePause(bool pause, bool _isBlackoutEnd);
    }

    public interface IBattleManagerForViewManager
    {

        public abstract eBattleCategory BattleCategory { get; }

        public abstract void GamePause(bool pause, bool _isBlackoutEnd);
    }

    public interface IBattleManagerForTrainingQuestFinishSequence
    {

        public abstract eBattleResult BattleResult { get; }

    }

    public interface IBattleManagerForHatsuneTask
    {

        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> EnemyList { get; }

        public abstract UnitCtrl FindEnemy(int _id);

        public abstract UnitCtrl GetBossUnit();
    }

    public interface IBattleManagerForBattleSpineController 
    {
        public abstract float DeltaTime { get; }
        public abstract bool IsPausingEffectSkippedInThisFrame { get; }
        public abstract void AddUnitSpineControllerList(BattleSpineController _unitSpineController);
        
        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);
        public abstract void RemoveUnitSpineControllerList(BattleSpineController _unitSpineController);
        public abstract bool IsSkipping();
    }
    public interface IBattleManagerForDialogBossResult
    {
        public abstract eBattleCategory BattleCategory { get; }
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract eBattleClearType GetAutoClearType();
        public abstract UnitCtrl GetBossUnit();
        public abstract int GetStartRemainTime();
        public abstract int GetBattleElapsedTime();
    }

    public interface IBattleManagerForDialogTrialBattleResult
    {
        public abstract eBattleCategory BattleCategory { get; }
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract eBattleClearType GetAutoClearType();
        public abstract UnitCtrl GetBossUnit();
        public abstract bool IsBossInfinityHpMode();
    }

    public interface IBattleManagerForDialogHatsuneBossResult 
    {
        public abstract eBattleCategory BattleCategory { get; }
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract long CurrentEnemyPoint { get; }
        public abstract bool IsSpecialBattle { get; }
        public abstract bool IsDefenseBattle { get; }
        public abstract float TimeLimit { get; }
        public abstract float TakeOverTimeForDefense { get; }
        public abstract float StartLimitTimeForDefense { get; }
        public abstract bool IsShowBossGauge { get; }
        public abstract bool IsHatsuneBattle { get; }
        public abstract eBattleClearType GetAutoClearType();
        public abstract void RunOutBattleResult();
        public abstract eHatsuneSpecialPurpose GetPurpose();
        public abstract long GetPurposeCount();
        public abstract void SetDamageGoldModeMaxHpAttackNum(ref long _damage, ref int _gold, ref int _mode, ref long _maxHp, ref int _attackNum);
        public abstract int GetCurrentWaveOffset();
        public abstract bool GetBossGaugeColorChange();
        public abstract void InstantiatePointCounter(Transform _transform, ref PartsHastunePointCounter _counter);
        public abstract void SetSpecialBattleGaugeColor(UIProgressBar _gauge);
        public abstract float GetBossGaugeValue(long _currentHp);
        public abstract void InstantiateDefenseTimeGauge(Transform parent, ref PartsHatsuneDefenseTimeGauge localTimeGauge);
        public abstract ValueTuple<long, long> GetTotalBossHp();
    }

    public interface IBattleManagerForDialogQuestFailed 
    {
        public abstract int PlayVoiceUnitId { get; }
        public abstract int PlayVoiceIndex { get; }
        public abstract int PlayVoiceGroupId { get; }
        public abstract int PlayVoiceGroupUnitId { get; set; }
        public abstract eBattleCategory BattleCategory { get; }
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract int CurrentWave { get; set; }
        public abstract bool IsTowerContent { get; }
        public abstract bool IsTowerReplayContent { get; }
        public abstract eBattleClearType GetAutoClearType();
        public abstract bool IsQuestAutoProgressing();
        public abstract bool IsLocalReplay();
    }

    public interface IBattleManagerForDialogQuestResultWin
    {

        public abstract eBattleCategory BattleCategory { get; }
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract Dictionary<int, int> PlayerHpDic { get; }
        public abstract Dictionary<int, int> EnemyHpDic { get; }
        public abstract bool IsTowerReplayContent { get; }
        public abstract eBattleClearType GetAutoClearType();
        public abstract bool IsQuestAutoProgressing();
        public abstract bool IsLocalReplay();
    }

    public interface IBattleManagerForDialogNormalArenaResult 
    {
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract Dictionary<int, int> PlayerHpDic { get; }
        public abstract Dictionary<int, int> EnemyHpDic { get; }
    }

    public interface IBattleManagerForDialogGrandArenaResult 
    {
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
    }

    public interface IBattleManagerForDialogTowerExResult
    {

        public abstract eBattleCategory BattleCategory { get; }

        public abstract void RunOutBattleResult();

        public abstract eBattleClearType GetAutoClearType();

    }

    public interface IBattleManagerForPartsQuestResultLater
    {

        public abstract eBattleCategory BattleCategory { get; }
        public abstract bool IsTowerContent { get; }
        public abstract bool IsTowerReplayContent { get; }
        public abstract bool IsHighRarityQuest { get; }
        public abstract List<RewardData> RewardList { get; }
        public abstract bool IsHatsuneBoss { get; }
        public abstract bool IsHatsuneBattle { get; }
        public abstract bool IsSpecialBattle { get; }

        public abstract bool IsQuestAutoProgressing();
    }

    public interface IBattleManagerForPartsQuestResultFormer
    {

        public abstract eBattleCategory BattleCategory { get; }
        public abstract eBattleResult BattleResult { get; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract bool IsTowerContent { get; }
        public abstract bool IsTowerReplayContent { get; }
        public abstract int CurrentDefeatCount { get; }

        public abstract void RunOutBattleResult();

        public abstract eBattleClearType GetAutoClearType();

        public abstract bool IsEnableQuestAutoProgress();

        public abstract bool IsQuestAutoProgressing();

        public abstract bool IsLocalReplay();

    }

    public interface IBattleManagerForDialogManager 
    {
        public abstract eBattleCategory BattleCategory { get; }
        public abstract bool CanReserveSkill { get; }
        public abstract bool IsShowEffectiveIcon(int _unitId);
    }

    public interface IBattleManagerForBattleUnionBurstController 
    {
        public abstract eChargeSkillTurn ChargeSkillTurn { get; set; }
        public abstract UnitCtrl UnionBurstUseUnit { get; set; }
        public abstract UnitUiCtrl UnitUiCtrl { get; }
        public abstract bool IsDefenseReplayMode { get; }
        public abstract eBattleGameState GameState { get; }
        public abstract int GetEnemyCtrlLength();
        public abstract UnitCtrl GetEnemyCtrl(int _idx);
        public abstract bool GetIsPlayCutin();
        public abstract int GetUnitCtrlLength();
        public abstract UnitCtrl GetUnitCtrl(int _idx);
    }

    public interface IBattleManagerForAutoLogic 
    {
        public abstract float TimeLimit { get; }
        public abstract int GetUnitCtrlLength();
        public abstract UnitCtrl GetUnitCtrl(int _idx);
        public abstract int GetEnemyCtrlLength();
        public abstract UnitCtrl GetEnemyCtrl(int _idx);
    }

    public interface IBattleManagerForBywayQuestBattleProcessor : IBattleManagerForQuestBattleProcessor, IBattleManagerForBaseBattleProcessor 
    {
        public abstract bool IsQuestAutoProgressing();
    }

    public interface IBattleManagerForBywayQuestReplayBattleProcessor : IBattleManagerForGeneralReplayBattleProcessor, IBattleManagerForBaseBattleProcessor 
    {
        public abstract bool IsBossBattle { get; }
        public abstract int GetLatestClearStarNum();
        public abstract void GamePause(bool pause, bool _isBlackoutEnd);
    }

    public interface IBattleManagerForAcnEndlessBattleProcessor : IBattleManagerForBaseBattleProcessor
    {

        public abstract float DeltaTime { get; }
        public abstract List<UnitCtrl> UnitList { get; }
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract int CurrentDefeatCount { get; }
        public abstract List<UnitCtrl> FadeOutUnitList { get; }
        public abstract void ResetFieldTimeUp();
        public abstract IEnumerator CallTimer(float time, Action onComplete);
        public abstract void PlayFlatoutAfterMove(bool _isPlayUnitJoyMotion);
        public abstract void GamePause(bool _pause, bool _isBlackoutEnd = false);
        public abstract void OpenResultWinDialog();
        public abstract IEnumerator InitializeAndUpdateWalkPlayer(Action _onWalkEnd, bool _isOutOfSystemUpdate);
        public abstract void ShowResultDialogCoroutine(bool _isWin);
    }
    public interface IBattleManagerForAcnBossBattleProcessor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract List<UnitCtrl> EnemyList { get; }
        public abstract void StartCoroutineBossLose();
    }

    public interface IBattleManagerForAcnSpecialBattleProcessor : IBattleManagerForBaseBattleProcessor
    {
        public abstract long CurrentEnemyPoint { get; }
        public abstract List<int> KillOrder { get; }
        public abstract void AddTempDataBattleLog();
        public abstract void GamePause(bool _pause, bool _isBlackoutEnd = false);
        public abstract void StartCoroutineBossLose();
    }
    public interface IBattleManagerForAcnUnknownBattleProcesssor : IBattleManagerForBaseBattleProcessor 
    {
        public abstract void StartCoroutineBossLose();
    }
}
