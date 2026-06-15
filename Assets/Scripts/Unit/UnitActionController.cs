using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class UnitActionController : MonoBehaviour, ISingletonField
{
//  public FixedTransformMonoBehavior.FixedTransform transform; 
    public ActionParameterOnPrefabDetail AttackDetail;
    public bool UseDefaultDelay; 
    public Skill Attack;
    public List<Skill> UnionBurstList;
    public List<Skill> MainSkillList;
    public List<Skill> SpecialSkillList; 
    public List<Skill> SpecialSkillEvolutionList;
    public List<Skill> UnionBurstEvolutionList;
    public List<Skill> MainSkillEvolutionList; 
    public List<Skill> SubUnionBurstList; 
    public Skill Annihilation; 

//  private static StaticSingletonTree<UnitActionController> staticSingletonTree; 
//  private static IBattleManagerForUnitActionController staticBattleManager;
//  private static IBattleCameraEffectForUnitActionController staticBattleCameraEffect; 
//  private static IBattleEffectPool staticBattleEffectPool; 
//  private static IBattleTimeScaleForUnitActionController staticBattleTimeScale; 
    public const long ACTION_ID_OFFSET = 100;
    private const int ACTION_ID_OFFSET_FOR_CHARA_ID = 10000;
    private const int DEFAULT_MOTION_NUMBER = 0;
    private const int LOOP_MOTION_NUMBER = 1;
    private const int FIRST_TARGET_INDEX = 0;

    public UnitCtrl Owner { get; set; }
    public bool UnionBurstIsChargeTime { get; set; }
    public bool UnionBurstCharging { get; set; }
    public bool DisableUBByModeChange { get; set; }
    public bool ModeChanging { get; set; }
    public bool StopModeChangeEndEffectCalled { get; set; }
    public bool IsCancelModeChangeByTrigger { get; set; }
    public bool MoveEnd { get; set; }
    private Dictionary<int, Skill> skillDictionary { get; set; }
    public bool ContinuousActionEndDone { get; set; }
    private bool isUnionBurstOnlyOwner { get; set; }
    private bool updateBranchMotionRunning { get; set; }
//  private IBattleManagerForUnitActionController battleManager { get; }
//  private IBattleCameraEffectForUnitActionController battleCameraEffect { get; }
//  private IBattleEffectPool battleEffectPool { get; }
//  private IBattleTimeScaleForUnitActionController battleTimeScale { get; }

    public static void StaticRelease() { }

    private void OnDestroy() { }

//  public void Initialize(UnitCtrl _owner, UnitParameter _unitParameter, bool _initializeAttackOnly = false, UnitCtrl _seOwner) { }

//  private void setSkillParameter(Skill _skill, CEPNIIGEBLD.KBBMDFBGAIP _skillParameter, int _parentSkillId = -1) { }

    private void dependActionSolve(Skill skill) { }

//  public void UpdateEffectRunTimeData(Skill _skill, List<NormalSkillEffect> _skillList, bool _resetflag = true) { }

    private void execActionOnStart(Skill _skill) { }

    private void execActionOnWaveStart(Skill _skill) { }

    private void initializeAction(Skill _skill) { }

    /*

    private void createActionValue(CEPNIIGEBLD.KBBMDFBGAIP skillParameter, PDBLHMLEOHA.FHHCALPOPAK actionParam, Skill skill, Dictionary<CIGIMFALOOB, int> actionCounter) { }

    public bool StartAction(int skillId) { }

    private void actionStartFirstProcess(Skill _skill, out bool _hasNoTarget) { }

    private void searchAndSortTarget(Skill _skill, ActionParameter _action, Vector3 _basePosition, bool _quiet = false, bool _considerBodyWidth = true) { }

    private void setCutInSkipTimeForPrincessForm(int _skillId) { }
    public IEnumerator StartActionWithOutCutIn(UnitCtrl _unit, int _skillId, Action _callback) { }

    public IEnumerator StartAnnihilationSkillAnimation(int _annihilationId) { }

    private IEnumerator foregroundActiveWithDelay(float _time) { }

    public void StopSlowEffect() { }

    public void AddBlackoutTarget(int _skillId) { }

    public void SearchTargetByAction(int _skillId) { }

    private IEnumerator updateCoroutineWithOutCutIn(IEnumerator _coroutine) { }

    public void CreateNormalPrefabWithTargetMotion(Skill _skill, int _targetmotion, bool _first, bool _useStartCoroutine = false, bool _modechangeEndEffect = false) { }

    public void ExecUnitActionWithDelay(ActionParameter _action, Skill _skill, bool _first, bool _boneCount, bool _ignoreCancel = false) { }

    public void ExecUnitActionNoDelay(ActionParameter _action, Skill _skill) { }

    public IEnumerator ExecActionWithDelayAndTarget(ActionParameter _action, Skill _skill, BasePartsData _target, float _starttime, bool _first = false, bool _boneCount = true, bool _ignoreCancel = false, BasePartsData _protectedTarget) { }

    public void ExecAction(ActionParameter _action, Skill _skill, BasePartsData _target, int _num, float _starttime, bool _execChildNoFrame = false, BasePartsData _protectedTarget, bool _ignoreProtect = false) { }

    public void ExecChildrenAction(ActionParameter _action, Skill _skill, BasePartsData _target, int _num, float _starttime, Dictionary<int, bool> _enabledChildAction, bool _execNoFrame, BasePartsData _protectedTarget) { }

    private void initWhenNoTarget(ActionParameter _action, Skill _skill) { }

    private IEnumerator createNormalPrefabWithDelay(NormalSkillEffect _skilleffect, Skill _skill, bool _first = false, bool _skipCutIn = false, bool _isFirearmEndEffect = false, bool _modeChangeEndEffect = false) { }

    private IEnumerator createNormalPrefabWithDelayAndTarget(NormalSkillEffect _skilleffect, Skill _skill, float _delay, BasePartsData _target, bool _first) { }

    private void createNormalEffectPrefab(NormalSkillEffect _skillEffect, Skill _skill, BasePartsData _target, BasePartsData _firearmEndTarget, bool actionStart, float _starttime, bool _skipCutIn, int execTimeIndex = 0, bool _modeChangeEndEffect = false) { }

    private SkillEffectCtrl createPrefab(NormalSkillEffect skillEffect, Skill skill, BasePartsData target, ref GameObject prefab) { }

    private void onFirearmHit(FirearmCtrl firearmCtrl) { }

    private void searchTargetUnit(ActionParameter actionParameter, Vector3 basePosition, Skill skill, bool _considerBodyWidth) { }

    private bool isInActionTargetArea(Skill _skill, ActionParameter _action, Vector3 _basePosition, bool _considerBodyWidth, BasePartsData _checkUnitCtrl) { }

    private bool judgeIsInTargetArea(ActionParameter _actionParameter, Vector3 _basePosition, bool _considerBodyWidth, float _parentLossyScale, float _start, float _end, BasePartsData _unitCtrl) { }

    private bool judgeIsTarget(UnitCtrl _unitCtrl, ActionParameter _actionParameter) { }

    public static int GetAttackSide(eAttackSide _direction, UnitCtrl _owner) { }

    private eTargetType convertPriorityPattern(eTargetType _pattern) { }

    private void sortTargetListByTargetPattern(ActionParameter _actionParameter, Transform _baseTransform, bool _quiet) { }

    private void filterTargetByFlight(ActionParameter _actionParameter) { }

    private void sortTargetPosition(List<BasePartsData> _targetList, bool _isForwardPattern, Comparison<BasePartsData> _forwardComparison, Comparison<BasePartsData> _backComparison) { }

    public void CancelAction(int skillId) { }
    public IEnumerator StartShakeWithDelay(ShakeEffect _shake, Skill _skill, bool _first = false) { }

    private void startBlurEffects(Skill _skill, bool _first = false) { }

    private IEnumerator startBlurWithDelay(BlurEffect.BlurEffectData _blurData, Skill _skill, bool _first) { }

    public void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit) { }

    public bool HasNextAnime(int skillId) { }

    public bool IsLoopMotionPlaying(int _skillId) { }

    public eSkillMotionType GetSkillMotionType(int _skillId) { }

    public int GetSkillNum(int _skillId) { }

    public eSpineCharacterAnimeId GetAnimeId(int _skillId) { }

    public bool IsModeChange(int _skillId) { }

    public void SetBonusId(int _skillId, int _bonusId) { }
    public void ExecActionOnStart() { }

    public void ExecActionOnWaveStart() { }

    public IEnumerator UpdateBranchMotion(ActionParameter _action, Skill _skill) { }

    private bool actionCancelAndGetCancel(int _skillId) { }

    public bool GetForceCutinOff(int _skillId) { }

    public bool GetIsSkillPrincessForm(int _skillId) { }

    public List<PrincessSkillMovieData> GetPrincessFormMovieData(int _skillId) { }

    public Skill CreateExSkill(int _id, ExSkillScriptable _exSkillScriptable, OHLDJNKCCDO _exSkillData) { }

    public void ExecExSkill(Skill _skill) { }

    public void ExecSkillWithTargetId(Skill _skill, int _actionId) { }

    public void ExecSkillWithTargetPartsAndActionList(Skill _skill, BasePartsData _targetParts, List<ActionParameter> _actionList) { }

    public void ExecSkillWithTargetParts(Skill _skill, BasePartsData _parts) { }

    private ActionParameter createActionParameter(PDBLHMLEOHA.FHHCALPOPAK _action, ExSkillScriptable _exSkillScriptable, OHLDJNKCCDO _exSkillData) { }

    */
}