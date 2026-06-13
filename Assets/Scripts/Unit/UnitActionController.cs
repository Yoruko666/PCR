using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class UnitActionController : MonoBehaviour, ISingletonField
{
	public FixedTransformMonoBehavior.FixedTransform transform; // 0x18
	public ActionParameterOnPrefabDetail AttackDetail; // 0x20
	public bool UseDefaultDelay; // 0x28
	public Skill Attack; // 0x30
	public List<Skill> UnionBurstList; // 0x38
	public List<Skill> MainSkillList; // 0x40
	public List<Skill> SpecialSkillList; // 0x48
	public List<Skill> SpecialSkillEvolutionList; // 0x50
	public List<Skill> UnionBurstEvolutionList; // 0x58
	public List<Skill> MainSkillEvolutionList; // 0x60
	public List<Skill> SubUnionBurstList; // 0x68
	public Skill Annihilation; // 0x70
	
	private static Yggdrasil<UnitActionController> staticSingletonTree; // 0x0
	private static IBattleManagerForUnitActionController staticBattleManager; // 0x8
	private static IBattleCameraEffectForUnitActionController staticBattleCameraEffect; // 0x10
	private static IBattleEffectPool staticBattleEffectPool; // 0x18
	private static IBattleTimeScaleForUnitActionController staticBattleTimeScale; // 0x20
	public const long ACTION_ID_OFFSET = 100;
	private const int ACTION_ID_OFFSET_FOR_CHARA_ID = 10000;
	private const int DEFAULT_MOTION_NUMBER = 0;
	private const int LOOP_MOTION_NUMBER = 1;
	private const int FIRST_TARGET_INDEX = 0;

	// Properties
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
	private IBattleManagerForUnitActionController battleManager { get; }
	private IBattleCameraEffectForUnitActionController battleCameraEffect { get; }
	private IBattleEffectPool battleEffectPool { get; }
	private IBattleTimeScaleForUnitActionController battleTimeScale { get; }

	// RVA: 0x2084734 Offset: 0x2084734 VA: 0x2084734
	public static void StaticRelease() { }

	// RVA: 0x20847DC Offset: 0x20847DC VA: 0x20847DC
	private void OnDestroy() { }

	// RVA: 0x2084870 Offset: 0x2084870 VA: 0x2084870
	public void Initialize(UnitCtrl _owner, UnitParameter _unitParameter, bool _initializeAttackOnly = false, UnitCtrl _seOwner) { }

	// RVA: 0x20866AC Offset: 0x20866AC VA: 0x20866AC
	private void setSkillParameter(Skill _skill, CEPNIIGEBLD.KBBMDFBGAIP _skillParameter, int _parentSkillId = -1) { }

	// RVA: 0x2086110 Offset: 0x2086110 VA: 0x2086110
	private void dependActionSolve(Skill skill) { }

	// RVA: 0x2088354 Offset: 0x2088354 VA: 0x2088354
	public void UpdateEffectRunTimeData(Skill _skill, List<NormalSkillEffect> _skillList, bool _resetflag = true) { }

	// RVA: 0x2086434 Offset: 0x2086434 VA: 0x2086434
	private void execActionOnStart(Skill _skill) { }

	// RVA: 0x2088680 Offset: 0x2088680 VA: 0x2088680
	private void execActionOnWaveStart(Skill _skill) { }

	// RVA: 0x20882AC Offset: 0x20882AC VA: 0x20882AC
	private void initializeAction(Skill _skill) { }

	// RVA: 0x2087320 Offset: 0x2087320 VA: 0x2087320
	private void createActionValue(CEPNIIGEBLD.KBBMDFBGAIP skillParameter, PDBLHMLEOHA.FHHCALPOPAK actionParam, Skill skill, Dictionary<CIGIMFALOOB, int> actionCounter) { }

	// RVA: 0x2088730 Offset: 0x2088730 VA: 0x2088730
	public bool StartAction(int skillId) { }

	// RVA: 0x208953C Offset: 0x208953C VA: 0x208953C
	private void actionStartFirstProcess(Skill _skill, out bool _hasNoTarget) { }

	// RVA: 0x208A2A0 Offset: 0x208A2A0 VA: 0x208A2A0
	private void searchAndSortTarget(Skill _skill, ActionParameter _action, Vector3 _basePosition, bool _quiet = false, bool _considerBodyWidth = true) { }

	// RVA: 0x20872A8 Offset: 0x20872A8 VA: 0x20872A8
	private void setCutInSkipTimeForPrincessForm(int _skillId) { }

	[IteratorStateMachine(typeof(UnitActionController.<StartActionWithOutCutIn>d__93))]
	// RVA: 0x208D334 Offset: 0x208D334 VA: 0x208D334
	public IEnumerator StartActionWithOutCutIn(UnitCtrl _unit, int _skillId, Action _callback) { }

	[IteratorStateMachine(typeof(UnitActionController.<StartAnnihilationSkillAnimation>d__94))]
	// RVA: 0x208D3EC Offset: 0x208D3EC VA: 0x208D3EC
	public IEnumerator StartAnnihilationSkillAnimation(int _annihilationId) { }

	[IteratorStateMachine(typeof(UnitActionController.<foregroundActiveWithDelay>d__95))]
	// RVA: 0x208D474 Offset: 0x208D474 VA: 0x208D474
	private IEnumerator foregroundActiveWithDelay(float _time) { }

	// RVA: 0x208D504 Offset: 0x208D504 VA: 0x208D504
	public void StopSlowEffect() { }

	// RVA: 0x208D5D8 Offset: 0x208D5D8 VA: 0x208D5D8
	public void AddBlackoutTarget(int _skillId) { }

	// RVA: 0x208DCB0 Offset: 0x208DCB0 VA: 0x208DCB0
	public void SearchTargetByAction(int _skillId) { }

	[IteratorStateMachine(typeof(UnitActionController.<updateCoroutineWithOutCutIn>d__99))]
	// RVA: 0x208E078 Offset: 0x208E078 VA: 0x208E078
	private IEnumerator updateCoroutineWithOutCutIn(IEnumerator _coroutine) { }

	// RVA: 0x2089B40 Offset: 0x2089B40 VA: 0x2089B40
	public void CreateNormalPrefabWithTargetMotion(Skill _skill, int _targetmotion, bool _first, bool _useStartCoroutine = false, bool _modechangeEndEffect = false) { }

	// RVA: 0x208A0A4 Offset: 0x208A0A4 VA: 0x208A0A4
	public void ExecUnitActionWithDelay(ActionParameter _action, Skill _skill, bool _first, bool _boneCount, bool _ignoreCancel = false) { }

	// RVA: 0x208E4A4 Offset: 0x208E4A4 VA: 0x208E4A4
	public void ExecUnitActionNoDelay(ActionParameter _action, Skill _skill) { }

	[IteratorStateMachine(typeof(UnitActionController.<ExecActionWithDelayAndTarget>d__103))]
	// RVA: 0x208E394 Offset: 0x208E394 VA: 0x208E394
	public IEnumerator ExecActionWithDelayAndTarget(ActionParameter _action, Skill _skill, BasePartsData _target, float _starttime, bool _first = false, bool _boneCount = true, bool _ignoreCancel = false, BasePartsData _protectedTarget) { }

	// RVA: 0x208E5A4 Offset: 0x208E5A4 VA: 0x208E5A4
	public void ExecAction(ActionParameter _action, Skill _skill, BasePartsData _target, int _num, float _starttime, bool _execChildNoFrame = false, BasePartsData _protectedTarget, bool _ignoreProtect = false) { }

	// RVA: 0x208EEB8 Offset: 0x208EEB8 VA: 0x208EEB8
	public void ExecChildrenAction(ActionParameter _action, Skill _skill, BasePartsData _target, int _num, float _starttime, Dictionary<int, bool> _enabledChildAction, bool _execNoFrame, BasePartsData _protectedTarget) { }

	// RVA: 0x208E1EC Offset: 0x208E1EC VA: 0x208E1EC
	private void initWhenNoTarget(ActionParameter _action, Skill _skill) { }

	[IteratorStateMachine(typeof(UnitActionController.<createNormalPrefabWithDelay>d__107))]
	// RVA: 0x208E10C Offset: 0x208E10C VA: 0x208E10C
	private IEnumerator createNormalPrefabWithDelay(NormalSkillEffect _skilleffect, Skill _skill, bool _first = false, bool _skipCutIn = false, bool _isFirearmEndEffect = false, bool _modeChangeEndEffect = false) { }

	[IteratorStateMachine(typeof(UnitActionController.<createNormalPrefabWithDelayAndTarget>d__108))]
	// RVA: 0x208F438 Offset: 0x208F438 VA: 0x208F438
	private IEnumerator createNormalPrefabWithDelayAndTarget(NormalSkillEffect _skilleffect, Skill _skill, float _delay, BasePartsData _target, bool _first) { }

	// RVA: 0x208F51C Offset: 0x208F51C VA: 0x208F51C
	private void createNormalEffectPrefab(NormalSkillEffect _skillEffect, Skill _skill, BasePartsData _target, BasePartsData _firearmEndTarget, bool actionStart, float _starttime, bool _skipCutIn, int execTimeIndex = 0, bool _modeChangeEndEffect = false) { }

	// RVA: 0x2090158 Offset: 0x2090158 VA: 0x2090158
	private SkillEffectCtrl createPrefab(NormalSkillEffect skillEffect, Skill skill, BasePartsData target, ref GameObject prefab) { }

	// RVA: 0x20907DC Offset: 0x20907DC VA: 0x20907DC
	private void onFirearmHit(FirearmCtrl firearmCtrl) { }

	// RVA: 0x208A9DC Offset: 0x208A9DC VA: 0x208A9DC
	private void searchTargetUnit(ActionParameter actionParameter, Vector3 basePosition, Skill skill, bool _considerBodyWidth) { }

	// RVA: 0x208D1F8 Offset: 0x208D1F8 VA: 0x208D1F8
	private bool isInActionTargetArea(Skill _skill, ActionParameter _action, Vector3 _basePosition, bool _considerBodyWidth, BasePartsData _checkUnitCtrl) { }

	// RVA: 0x2091020 Offset: 0x2091020 VA: 0x2091020
	private bool judgeIsInTargetArea(ActionParameter _actionParameter, Vector3 _basePosition, bool _considerBodyWidth, float _parentLossyScale, float _start, float _end, BasePartsData _unitCtrl) { }

	// RVA: 0x2090B3C Offset: 0x2090B3C VA: 0x2090B3C
	private bool judgeIsTarget(UnitCtrl _unitCtrl, ActionParameter _actionParameter) { }

	// RVA: 0x2090790 Offset: 0x2090790 VA: 0x2090790
	public static int GetAttackSide(GDCIMHECIFP _direction, UnitCtrl _owner) { }

	// RVA: 0x2090B14 Offset: 0x2090B14 VA: 0x2090B14
	private KHNEEEDKBJK convertPriorityPattern(KHNEEEDKBJK _pattern) { }

	// RVA: 0x208BC20 Offset: 0x208BC20 VA: 0x208BC20
	private void sortTargetListByTargetPattern(ActionParameter _actionParameter, Transform _baseTransform, bool _quiet) { }

	// RVA: 0x2090CCC Offset: 0x2090CCC VA: 0x2090CCC
	private void filterTargetByFlight(ActionParameter _actionParameter) { }

	// RVA: 0x2091170 Offset: 0x2091170 VA: 0x2091170
	private void sortTargetPosition(List<BasePartsData> _targetList, bool _isForwardPattern, Comparison<BasePartsData> _forwardComparison, Comparison<BasePartsData> _backComparison) { }

	// RVA: 0x2091220 Offset: 0x2091220 VA: 0x2091220
	public void CancelAction(int skillId) { }

	[IteratorStateMachine(typeof(UnitActionController.<StartShakeWithDelay>d__122))]
	// RVA: 0x2089E14 Offset: 0x2089E14 VA: 0x2089E14
	public IEnumerator StartShakeWithDelay(ShakeEffect _shake, Skill _skill, bool _first = false) { }

	// RVA: 0x2089FC0 Offset: 0x2089FC0 VA: 0x2089FC0
	private void startBlurEffects(Skill _skill, bool _first = false) { }

	[IteratorStateMachine(typeof(UnitActionController.<startBlurWithDelay>d__124))]
	// RVA: 0x2091418 Offset: 0x2091418 VA: 0x2091418
	private IEnumerator startBlurWithDelay(BlurEffect.BlurEffectData _blurData, Skill _skill, bool _first) { }

	// RVA: 0x2089ECC Offset: 0x2089ECC VA: 0x2089ECC
	public void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit) { }

	// RVA: 0x20914D0 Offset: 0x20914D0 VA: 0x20914D0
	public bool HasNextAnime(int skillId) { }

	// RVA: 0x20915AC Offset: 0x20915AC VA: 0x20915AC
	public bool IsLoopMotionPlaying(int _skillId) { }

	// RVA: 0x2091674 Offset: 0x2091674 VA: 0x2091674
	public eSkillMotionType GetSkillMotionType(int _skillId) { }

	// RVA: 0x20916E4 Offset: 0x20916E4 VA: 0x20916E4
	public int GetSkillNum(int _skillId) { }

	// RVA: 0x2091754 Offset: 0x2091754 VA: 0x2091754
	public eSpineCharacterAnimeId GetAnimeId(int _skillId) { }

	// RVA: 0x20917C4 Offset: 0x20917C4 VA: 0x20917C4
	public bool IsModeChange(int _skillId) { }

	// RVA: 0x2091834 Offset: 0x2091834 VA: 0x2091834
	public void SetBonusId(int _skillId, int _bonusId) { }

	// RVA: 0x20918A8 Offset: 0x20918A8 VA: 0x20918A8
	public void ExecActionOnStart() { }

	// RVA: 0x20919E8 Offset: 0x20919E8 VA: 0x20919E8
	public void ExecActionOnWaveStart() { }

	[IteratorStateMachine(typeof(UnitActionController.<UpdateBranchMotion>d__135))]
	// RVA: 0x2091B28 Offset: 0x2091B28 VA: 0x2091B28
	public IEnumerator UpdateBranchMotion(ActionParameter _action, Skill _skill) { }

	// RVA: 0x2091BBC Offset: 0x2091BBC VA: 0x2091BBC
	private bool actionCancelAndGetCancel(int _skillId) { }

	// RVA: 0x2091C5C Offset: 0x2091C5C VA: 0x2091C5C
	public bool GetForceCutinOff(int _skillId) { }

	// RVA: 0x2091CCC Offset: 0x2091CCC VA: 0x2091CCC
	public bool GetIsSkillPrincessForm(int _skillId) { }

	// RVA: 0x2091D3C Offset: 0x2091D3C VA: 0x2091D3C
	public List<PrincessSkillMovieData> GetPrincessFormMovieData(int _skillId) { }

	// RVA: 0x2091DAC Offset: 0x2091DAC VA: 0x2091DAC
	public Skill CreateExSkill(int _id, ExSkillScriptable _exSkillScriptable, OHLDJNKCCDO _exSkillData) { }

	// RVA: 0x2093158 Offset: 0x2093158 VA: 0x2093158
	public void ExecExSkill(Skill _skill) { }

	// RVA: 0x20933F4 Offset: 0x20933F4 VA: 0x20933F4
	public void ExecSkillWithTargetId(Skill _skill, int _actionId) { }

	// RVA: 0x20936A0 Offset: 0x20936A0 VA: 0x20936A0
	public void ExecSkillWithTargetPartsAndActionList(Skill _skill, BasePartsData _targetParts, List<ActionParameter> _actionList) { }

	// RVA: 0x20939C4 Offset: 0x20939C4 VA: 0x20939C4
	public void ExecSkillWithTargetParts(Skill _skill, BasePartsData _parts) { }

	// RVA: 0x20927F8 Offset: 0x20927F8 VA: 0x20927F8
	private ActionParameter createActionParameter(PDBLHMLEOHA.FHHCALPOPAK _action, ExSkillScriptable _exSkillScriptable, OHLDJNKCCDO _exSkillData) { }
}