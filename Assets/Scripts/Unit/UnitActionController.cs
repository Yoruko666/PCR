using System;
using System.Collections;
using System.Collections.Generic;
using Elements.Battle.Core;
using UnityEngine;

namespace Elements 
{ 
	/*
	private sealed class UnitActionController.<>c
	{
		public static readonly UnitActionController.<>c <>9;
		public static Comparison<ActionExecTime> <>9__81_0;
		public static Func<Elements.Data.MasterUnitSkillDataRf.UnitSkillDataRf, int> <>9__81_1;
		public static Comparison<ActionExecTime> <>9__88_1;
		public static Action<UnitCtrl> <>9__93_1;
		public static Action<UnitCtrl> <>9__93_2;
		public static Action<BattleSpineController> <>9__93_3;
		public static Action<BattleSpineController> <>9__93_4;
		public static Comparison<BasePartsData> <>9__107_0;
		public static Comparison<BasePartsData> <>9__107_1;
		public static Predicate<UnitCtrl> <>9__112_0;
		public static Predicate<UnitCtrl> <>9__112_1;
		public static Predicate<UnitCtrl> <>9__112_2;
		public static Predicate<UnitCtrl> <>9__112_3;
		public static Predicate<UnitCtrl> <>9__112_5;
		public static Predicate<BasePartsData> <>9__119_0;
		public static Func<BasePartsData, bool> <>9__119_1;
		public static Predicate<BasePartsData> <>9__119_2;

		private static void .cctor() { }

		public void .ctor() { }

		internal int <Initialize>b__81_0(ActionExecTime a, ActionExecTime b) { }

		internal int <Initialize>b__81_1(Elements.Data.MasterUnitSkillDataRf.UnitSkillDataRf e) { }

		internal int <createActionValue>b__88_1(ActionExecTime a, ActionExecTime b) { }

		internal void <StartActionWithOutCutIn>b__93_1(UnitCtrl _it) { }

		internal void <StartActionWithOutCutIn>b__93_2(UnitCtrl _it) { }

		internal void <StartActionWithOutCutIn>b__93_3(BattleSpineController _fx) { }

		internal void <StartActionWithOutCutIn>b__93_4(BattleSpineController _fx) { }

		internal int <createNormalPrefabWithDelay>b__107_0(BasePartsData a, BasePartsData b) { }

		internal int <createNormalPrefabWithDelay>b__107_1(BasePartsData a, BasePartsData b) { }

		internal bool <searchTargetUnit>b__112_0(UnitCtrl e) { }

		internal bool <searchTargetUnit>b__112_1(UnitCtrl e) { }

		internal bool <searchTargetUnit>b__112_2(UnitCtrl e) { }

		internal bool <searchTargetUnit>b__112_3(UnitCtrl e) { }

		internal bool <searchTargetUnit>b__112_5(UnitCtrl e) { }

		internal bool <filterTargetByFlight>b__119_0(BasePartsData _target) { }

		internal bool <filterTargetByFlight>b__119_1(BasePartsData _target) { }

		internal bool <filterTargetByFlight>b__119_2(BasePartsData _target) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass104_0
	{
		public Dictionary<eValueNumber, double> additionalValue;
		public Dictionary<eValueNumber, double> multipleValue;
		public Dictionary<eValueNumber, double> divideValue;


		public void .ctor() { }

		internal double <ExecAction>b__0(ActionParameter _targetAction, eValueNumber _type) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass109_0
	{
		public UnitActionController <>4__this;
		public NormalSkillEffect _skillEffect;
		public Skill _skill;
		public BasePartsData _firearmEndTarget;


		public void .ctor() { }

		internal void <createNormalEffectPrefab>b__0(FirearmCtrl fctrl) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass110_0
	{
		public Skill skill;
		public BasePartsData target;


		public void .ctor() { }

		internal void <createPrefab>b__0(SkillEffectCtrl obj) { }

		internal void <createPrefab>b__1(SkillEffectCtrl obj) { }

		internal void <createPrefab>b__2(SkillEffectCtrl destroyedEffect) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass112_0
	{
		public eAbnormalState targetAbnormalState;


		public void .ctor() { }

		internal bool <searchTargetUnit>b__6(UnitCtrl e) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass119_0
	{
		public bool isFlightTarget;


		public void .ctor() { }

		internal bool <filterTargetByFlight>b__3(BasePartsData _target) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass140_0
	{
		public Elements.Battle.Core.ExSkillData _exSkillData;
		public UnitActionController <>4__this;
		public Action <>9__0;
		public Elements.Battle.Core.UnitComponentDamageControl.OnDamageDelegate <>9__1;
		public Elements.Battle.Core.UnitComponentDamageControl.OnDamageDelegate <>9__2;


		public void .ctor() { }

		internal void <CreateExSkill>b__0() { }

		internal void <CreateExSkill>b__1(bool byAttack, long damage, bool critical) { }

		internal void <CreateExSkill>b__2(bool byAttack, long damage, bool critical) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass140_1
	{
		public KeyValuePair<Elements.Battle.Core.eExSkillCondition, Elements.Battle.Core.ExConditionPassiveData> kv;
		public UnitActionController.<>c__DisplayClass140_0 CS$<>8__locals1;


		public void .ctor() { }

		internal void <CreateExSkill>b__3(bool byAttack, long damage, bool critical) { }

		internal void <CreateExSkill>b__4(float _limitTime) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass82_0
	{
		public SkillEffectCtrl left;
		public SkillEffectCtrl right;


		public void .ctor() { }

		internal void <setSkillParameter>b__0() { }

		internal void <setSkillParameter>b__1() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass84_0
	{
		public NormalSkillEffect effect;


		public void .ctor() { }

		internal bool <UpdateEffectRunTimeData>b__0(ActionParameter e) { }

		internal bool <UpdateEffectRunTimeData>b__1(ActionParameter e) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass88_0
	{
		public ActionParameter actionParameter;


		public void .ctor() { }

		internal bool <createActionValue>b__0(ActionParameterOnPrefab e) { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<>c__DisplayClass93_0
	{
		public UnitActionController <>4__this;
		public UnitCtrl _unit;
		public Skill skill;


		public void .ctor() { }

		internal void <StartActionWithOutCutIn>b__0() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<ExecActionWithDelayAndTarget>d__103 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public BasePartsData _target;
		public bool _boneCount;
		public ActionParameter _action;
		public bool _first;
		public float _starttime;
		public Skill _skill;
		public UnitActionController <>4__this;
		public bool _ignoreCancel;
		public BasePartsData _protectedTarget;
		private float <time>5__2;
		private long[] <ids>5__3;
		private int <i>5__4;
		private long <actionIndivisualId>5__5;
		private float <waitTime>5__6;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<StartActionWithOutCutIn>d__93 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public UnitActionController <>4__this;
		public UnitCtrl _unit;
		public Action _callback;
		public int _skillId;
		private UnitActionController.<>c__DisplayClass93_0 <>8__1;
		private BattleSpineController <unitSpineController>5__2;
		private TrackEntry <entry>5__3;
		private float <deltaTimeAccumulated>5__4;
		private BattleHeaderController <battleHeaderController>5__5;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<StartAnnihilationSkillAnimation>d__94 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public UnitActionController <>4__this;
		public int _annihilationId;
		private BattleSpineController <unitSpineController>5__2;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<StartShakeWithDelay>d__122 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public bool _first;
		public ShakeEffect _shake;
		public Skill _skill;
		public UnitActionController <>4__this;
		private float <time>5__2;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<UpdateBranchMotion>d__135 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public Skill _skill;
		public UnitActionController <>4__this;
		private BattleSpineController <unitSpineController>5__2;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<createNormalPrefabWithDelay>d__107 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public bool _first;
		public Skill _skill;
		public UnitActionController <>4__this;
		public NormalSkillEffect _skilleffect;
		public bool _skipCutIn;
		public bool _isFirearmEndEffect;
		public bool _modeChangeEndEffect;
		private float <time>5__2;
		private int <generateEffectCount>5__3;
		private float[] <execTime>5__4;
		private bool[] <execed>5__5;
		private int <execTimeIndex>5__6;
		private float <waitTime>5__7;
		private float <startTime>5__8;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<createNormalPrefabWithDelayAndTarget>d__108 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public bool _first;
		public Skill _skill;
		public float _delay;
		public UnitActionController <>4__this;
		public NormalSkillEffect _skilleffect;
		public BasePartsData _target;
		private float <time>5__2;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<foregroundActiveWithDelay>d__95 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public float _time;
		public UnitActionController <>4__this;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private object System.Collections.IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<startBlurWithDelay>d__124 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public bool _first;
		public BlurEffect.BlurEffectData _blurData;
		public Skill _skill;
		public UnitActionController <>4__this;
		private float <time>5__2;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void IEnumerator.Reset() { }

		[DebuggerHidden]
		private object IEnumerator.get_Current() { }
	}

	[CompilerGenerated]
	private sealed class UnitActionController.<updateCoroutineWithOutCutIn>d__99 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int <>1__state;
		private object <>2__current;
		public IEnumerator _coroutine;
		public UnitActionController <>4__this;
		private float <deltaTimeAccumulated>5__2;

		private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
		private object System.Collections.IEnumerator.Current { get; }


		[DebuggerHidden]
		public void .ctor(int <>1__state) { }

		[DebuggerHidden]
		private void System.IDisposable.Dispose() { }

		private bool MoveNext() { }

		[DebuggerHidden]
		private object IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private void IEnumerator.Reset() { }

		[DebuggerHidden]
		private object IEnumerator.get_Current() { }
	}

	*/

	public class UnitActionController : MonoBehaviour, ISingletonField
	{
//		public FixedTransformMonoBehavior.FixedTransform transform;
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

//		private static Yggdrasil<UnitActionController> staticSingletonTree;
//		private static IBattleManagerForUnitActionController staticBattleManager;
//		private static IBattleCameraEffectForUnitActionController staticBattleCameraEffect;
//		private static IBattleEffectPool staticBattleEffectPool;
//		private static IBattleTimeScaleForUnitActionController staticBattleTimeScale;
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
//		private IBattleManagerForUnitActionController battleManager { get; }
//		private IBattleCameraEffectForUnitActionController battleCameraEffect { get; }
//		private IBattleEffectPool battleEffectPool { get; }
//		private IBattleTimeScaleForUnitActionController battleTimeScale { get; }

		public static void StaticRelease() { }

		private void OnDestroy() { }

		public void Initialize(UnitCtrl _owner, UnitParameter _unitParameter, bool _initializeAttackOnly = false, UnitCtrl _seOwner) { }

		private void setSkillParameter(Skill _skill, Elements.Data.MasterSkillData.SkillData _skillParameter, int _parentSkillId = -1) { }

		private void dependActionSolve(Skill skill) { }

		public void UpdateEffectRunTimeData(Skill _skill, List<NormalSkillEffect> _skillList, bool _resetflag = true) { }

		private void execActionOnStart(Skill _skill) { }

		private void execActionOnWaveStart(Skill _skill) { }

		private void initializeAction(Skill _skill) { }

		private void createActionValue(Elements.Data.MasterSkillData.SkillData skillParameter, Elements.Data.MasterSkillAction.SkillAction actionParam, Skill skill, Dictionary<Elements.Battle.Core.eActionType, int> actionCounter) { }

		public bool StartAction(int skillId) { }

		private void actionStartFirstProcess(Skill _skill, out bool _hasNoTarget) { }

		private void searchAndSortTarget(Skill _skill, ActionParameter _action, Vector3 _basePosition, bool _quiet = false, bool _considerBodyWidth = false) { }

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

		private void createNormalEffectPrefab(NormalSkillEffect _skillEffect, Skill _skill, BasePartsData _target, BasePartsData _firearmEndTarget, bool actionStart, float _starttime, bool _skipCutIn, int execTimeIndex = 0, bool _modeChangeEndEffect = False) { }

		private SkillEffectCtrl createPrefab(NormalSkillEffect skillEffect, Skill skill, BasePartsData target, ref GameObject prefab) { }

		private void onFirearmHit(FirearmCtrl firearmCtrl) { }

		private void searchTargetUnit(ActionParameter actionParameter, Vector3 basePosition, Skill skill, bool _considerBodyWidth) { }

		private bool isInActionTargetArea(Skill _skill, ActionParameter _action, Vector3 _basePosition, bool _considerBodyWidth, BasePartsData _checkUnitCtrl) { }

		private bool judgeIsInTargetArea(ActionParameter _actionParameter, Vector3 _basePosition, bool _considerBodyWidth, float _parentLossyScale, float _start, float _end, BasePartsData _unitCtrl) { }

		private bool judgeIsTarget(UnitCtrl _unitCtrl, ActionParameter _actionParameter) { }

		public static int GetAttackSide(DirectionType _direction, UnitCtrl _owner) { }

		private PriorityPattern convertPriorityPattern(PriorityPattern _pattern) { }

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

		public Elements.Battle.Core.SkillMotionType GetSkillMotionType(int _skillId) { }

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

		public Skill CreateExSkill(int _id, ExSkillScriptable _exSkillScriptable, Elements.Battle.Core.ExSkillData _exSkillData) { }

		public void ExecExSkill(Skill _skill) { }

		public void ExecSkillWithTargetId(Skill _skill, int _actionId) { }

		public void ExecSkillWithTargetPartsAndActionList(Skill _skill, BasePartsData _targetParts, List<Elements.Battle.Core.ActionParameter> _actionList) { }

		public void ExecSkillWithTargetParts(Skill _skill, BasePartsData _parts) { }

		private ActionParameter createActionParameter(Elements.Data.MasterSkillAction.SkillAction _action, ExSkillScriptable _exSkillScriptable, Elements.Battle.Core.ExSkillData _exSkillData) { }

		public UnitActionController() { }
	}
}