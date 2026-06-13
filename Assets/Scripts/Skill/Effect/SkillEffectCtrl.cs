public class SkillEffectCtrl : MonoBehaviour, ISingletonField // TypeDefIndex: 1099
{
	// Fields
	public static readonly eSE[] BattleCommonSeArray; // 0x0
	[SerializeField]
	protected ParticleSystem particle; // 0x18
	[SerializeField]
	public TweenPosition[] TweenerList; // 0x20
	[SerializeField]
	public TweenRotation[] TweenRotList; // 0x28
	[SerializeField]
	public Animator[] AnimatorList; // 0x30
	[SerializeField]
	protected CriAtomSource skillSeSource; // 0x40
	[SerializeField]
	protected bool isRepeat; // 0x48
	protected UnitCtrl source; // 0x50
	[SerializeField]
	private bool isCommon; // 0x58
	[SerializeField]
	private eBattleSkillSeType seType; // 0x5C
	[SerializeField]
	private List<SkillEffectCtrl.RarityUpTextureChangeDataSet> textureChangeParticles; // 0x60
	[SerializeField]
	private List<SkillEffectCtrl.DefenceModeTextureChange> defenceModeTextureSetting; // 0x68
	private List<SkillEffectCtrl.BoneTimeLineData> boneTimeLine; // 0x70
	private float boneTimeLineStartTime; // 0x78
	[CompilerGenerated]
	private UnitCtrl <Target>k__BackingField; // 0x90
	protected bool timeToDie; // 0xA0
	protected bool isPause; // 0xA1
	private SoundManager soundManager; // 0xA8
	protected Dictionary<Renderer, SkillEffectCtrl.SortOrderAndOffset> particleRendererDictionary; // 0xB0
	private int currentCoroutineId; // 0xD4
	private static readonly string LAYER_NAME; // 0x8
	private const int SORT_ORDER_BOUNDARY = 1000;
	private static Yggdrasil<SkillEffectCtrl> staticSingletonTree; // 0x10
	private static IBattleManagerForSkillEffectCtrl staticBattleManager; // 0x18

	// Properties
	public bool IsAura { get; set; }
	public bool IsCommon { get; set; }
	public Action<SkillEffectCtrl> OnEffectEnd { get; set; }
	public UnitCtrl SortTarget { get; set; }
	public UnitCtrl Target { get; set; }
	public bool IsRepeat { get; set; }
	public bool IsPlaying { get; set; }
	private int trackTargetCoroutinueId { get; set; }
	public bool IsFront { get; set; }
	protected ParticleSystem[] particles { get; set; }
	private Dictionary<ParticleSystem, float> particleStartDelayDictionary { get; set; }
	private float resumeTime { get; set; }
	protected Yggdrasil<SkillEffectCtrl> singletonTree { get; }
	protected IBattleManagerForSkillEffectCtrl battleManager { get; }
	public CriAtomSource SeSource { get; set; }

	// RVA: 0x1D3B164 Offset: 0x1D3B164 VA: 0x1D3B164
	protected Yggdrasil<SkillEffectCtrl> get_singletonTree() { }

	// RVA: 0x1D3B1C0 Offset: 0x1D3B1C0 VA: 0x1D3B1C0
	protected IBattleManagerForSkillEffectCtrl get_battleManager() { }

	// RVA: 0x1D3B21C Offset: 0x1D3B21C VA: 0x1D3B21C
	public static void StaticInitSingletonTree() { }

	// RVA: 0x1D3B27C Offset: 0x1D3B27C VA: 0x1D3B27C
	public static void StaticRelease() { }

	// RVA: 0x1D3B2F0 Offset: 0x1D3B2F0 VA: 0x1D3B2F0
	private void Awake() { }

	// RVA: 0x1D3B2F4 Offset: 0x1D3B2F4 VA: 0x1D3B2F4
	protected void awakeImpl() { }

	// RVA: 0x1D3B3F8 Offset: 0x1D3B3F8 VA: 0x1D3B3F8
	private void OnDestroy() { }

	// RVA: 0x1D2F018 Offset: 0x1D2F018 VA: 0x1D2F018 Slot: 4
	protected virtual void onDestroy() { }

	// RVA: 0x1D3B688 Offset: 0x1D3B688 VA: 0x1D3B688
	private void setLayerName(string value) { }

	// RVA: 0x1D3B7DC Offset: 0x1D3B7DC VA: 0x1D3B7DC
	public void SetLayerUI() { }

	// RVA: 0x1D33A50 Offset: 0x1D33A50 VA: 0x1D33A50 Slot: 5
	public virtual void InitializeSort() { }

	// RVA: 0x1D3BBC8 Offset: 0x1D3BBC8 VA: 0x1D3BBC8
	public void InitializeSortForWithOutBattle() { }

	// RVA: 0x1D32CE8 Offset: 0x1D32CE8 VA: 0x1D32CE8 Slot: 6
	public virtual void ExecAppendCoroutine(UnitCtrl _unit, bool _isAbnormal = false) { }

	// RVA: 0x1D3B860 Offset: 0x1D3B860 VA: 0x1D3B860
	private void particleRendererDictionaryInitialize() { }

	// RVA: 0x1D2F8F0 Offset: 0x1D2F8F0 VA: 0x1D2F8F0 Slot: 7
	public virtual void SetPossitionAppearanceType(NormalSkillEffect _skillEffect, BasePartsData _target, UnitCtrl _owner, Skill _skill) { }

	// RVA: 0x1D3BEEC Offset: 0x1D3BEEC VA: 0x1D3BEEC Slot: 8
	public virtual void StartUpdateDisappear(bool _isUnionBurst, BasePartsData _target) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<TrackTarget>d__92))]
	// RVA: 0x1D3BD44 Offset: 0x1D3BD44 VA: 0x1D3BD44
	public IEnumerator TrackTarget(BasePartsData _trans, Vector3 _absolutePosition, bool _followX = true, bool _followY = true, Bone _bone, bool _trackRotation = false, SkillEffectCtrl.eToadTrackType _toadTrackType = 0) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<updateBoneTimeLine>d__93))]
	// RVA: 0x1D3BE48 Offset: 0x1D3BE48 VA: 0x1D3BE48
	private IEnumerator updateBoneTimeLine(BasePartsData _partsData, bool _trackRotation) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<TrackTarget>d__94))]
	// RVA: 0x1D3BF48 Offset: 0x1D3BF48 VA: 0x1D3BF48
	public IEnumerator TrackTarget(BattleUnitBaseSpineController _spine, Vector3 _absolutePosition, bool _followX = true, bool _followY = true, Bone _bone, bool _trackRotation = false, Transform _traskScale, float _coefficient = 1, bool _callFromBossDialog = false) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<TrackTargetSort>d__95))]
	// RVA: 0x1D3C094 Offset: 0x1D3C094 VA: 0x1D3C094
	public IEnumerator TrackTargetSort(UnitCtrl _unit, bool _allowSortOrderFront = true) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<updateTimer>d__96))]
	// RVA: 0x1D3BC3C Offset: 0x1D3BC3C VA: 0x1D3BC3C
	private IEnumerator updateTimer(int _coroutineId) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<UpdateTimerRepeat>d__97))]
	// RVA: 0x1D3BCC4 Offset: 0x1D3BCC4 VA: 0x1D3BCC4
	private IEnumerator UpdateTimerRepeat() { }

	// RVA: 0x1D3C1BC Offset: 0x1D3C1BC VA: 0x1D3C1BC Slot: 9
	public virtual bool _Update() { }

	// RVA: 0x1D33230 Offset: 0x1D33230 VA: 0x1D33230 Slot: 10
	public virtual void Pause() { }

	// RVA: 0x1D3C2C4 Offset: 0x1D3C2C4 VA: 0x1D3C2C4 Slot: 11
	protected virtual void resetStartDelay() { }

	// RVA: 0x1D33460 Offset: 0x1D33460 VA: 0x1D33460 Slot: 12
	public virtual void Resume() { }

	// RVA: 0x1D3C3BC Offset: 0x1D3C3BC VA: 0x1D3C3BC Slot: 13
	protected virtual void initTweener(UITweener _tweener) { }

	// RVA: 0x1D396D0 Offset: 0x1D396D0 VA: 0x1D396D0 Slot: 14
	public virtual void SetSortOrderBack() { }

	// RVA: 0x1D39B08 Offset: 0x1D39B08 VA: 0x1D39B08 Slot: 15
	public virtual void SetSortOrderFront() { }

	// RVA: 0x1D3C3F4 Offset: 0x1D3C3F4 VA: 0x1D3C3F4
	public void SetSortOrderStatus(int offset) { }

	// RVA: 0x1D3C66C Offset: 0x1D3C66C VA: 0x1D3C66C
	public void SetSortOrderHit(int _offset) { }

	// RVA: 0x1D3C8C0 Offset: 0x1D3C8C0 VA: 0x1D3C8C0
	public void SetSortOrderForSummon(int _sortOrder) { }

	// RVA: 0x1D3044C Offset: 0x1D3044C VA: 0x1D3044C
	protected void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit) { }

	// RVA: 0x1D3CAC4 Offset: 0x1D3CAC4 VA: 0x1D3CAC4
	public void PlaySe(int soundUnitId, bool isEnemySide) { }

	// RVA: 0x1D3CE38 Offset: 0x1D3CE38 VA: 0x1D3CE38
	public void PlaySe(eSE se, bool isEnemySide) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<FadeoutSe>d__111))]
	// RVA: 0x1D3CF98 Offset: 0x1D3CF98 VA: 0x1D3CF98
	public IEnumerator FadeoutSe(Action _callback, float _fadeSec) { }

	// RVA: 0x1D3C228 Offset: 0x1D3C228 VA: 0x1D3C228
	private void pauseSe(bool isPause) { }

	// RVA: 0x1D3D068 Offset: 0x1D3D068 VA: 0x1D3D068
	public CriAtomSource get_SeSource() { }

	// RVA: 0x1D3D070 Offset: 0x1D3D070 VA: 0x1D3D070
	public void set_SeSource(CriAtomSource value) { }

	// RVA: 0x1D3D078 Offset: 0x1D3D078 VA: 0x1D3D078
	public void SetSource(UnitCtrl _source) { }

	// RVA: 0x1D2F118 Offset: 0x1D2F118 VA: 0x1D2F118 Slot: 16
	public virtual void ResetParameter(GameObject _prefab, int _skinID = 0, bool _isShadow = false) { }

	// RVA: 0x1D3D088 Offset: 0x1D3D088 VA: 0x1D3D088
	public void RestartTween() { }

	// RVA: 0x1D3D180 Offset: 0x1D3D180 VA: 0x1D3D180
	public void SetTimeToDie(bool value) { }

	[IteratorStateMachine(typeof(SkillEffectCtrl.<TrackTargetSortForSummon>d__120))]
	// RVA: 0x1D3D188 Offset: 0x1D3D188 VA: 0x1D3D188
	public IEnumerator TrackTargetSortForSummon(UnitCtrl _unitCtrl) { }

	// RVA: 0x1D3D248 Offset: 0x1D3D248 VA: 0x1D3D248 Slot: 17
	public virtual void SetStartTime(float _starttime) { }

	// RVA: 0x1D3D588 Offset: 0x1D3D588 VA: 0x1D3D588 Slot: 18
	public virtual void OnAwakeWhenSkipCutIn() { }

    // RVA: 0x1D3D58C Offset: 0x1D3D58C VA: 0x1D3D58C Slot: 19
    public virtual void SetTimeToDieByStartHp(float _hpPercent) { }
}
