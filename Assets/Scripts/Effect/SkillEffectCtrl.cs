using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillEffectCtrl : MonoBehaviour, ISingletonField
{
    // Fields
    public static readonly eSE[] BattleCommonSeArray;
    [SerializeField]
    protected ParticleSystem particle;
    [SerializeField]
    public Animator[] AnimatorList;
    //[SerializeField]
    //protected CriAtomSource skillSeSource;
    [SerializeField]
    protected bool isRepeat;
    protected UnitCtrl source;
    [SerializeField]
    private bool isCommon;
    //[SerializeField]
    //private eBattleSkillSeType seType;
    //[SerializeField]
    //private List<SkillEffectCtrl.RarityUpTextureChangeDataSet> textureChangeParticles;
    //[SerializeField]
    //private List<SkillEffectCtrl.DefenceModeTextureChange> defenceModeTextureSetting;
    //private List<SkillEffectCtrl.BoneTimeLineData> boneTimeLine;
    private float boneTimeLineStartTime;
    protected bool timeToDie;
    protected bool isPause;
    //private SoundManager soundManager;
    //protected Dictionary<Renderer, SkillEffectCtrl.SortOrderAndOffset> particleRendererDictionary;
    private int currentCoroutineId;
    private static readonly string LAYER_NAME;
    private const int SORT_ORDER_BOUNDARY = 1000;
    //private static StaticSingletonTree<SkillEffectCtrl> staticSingletonTree;
    //private static IBattleManagerForSkillEffectCtrl staticBattleManager;

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
    //protected StaticSingletonTree<SkillEffectCtrl> singletonTree { get; }
    //protected IBattleManagerForSkillEffectCtrl battleManager { get; }
    //public CriAtomSource SeSource { get; set; }

    //protected StaticSingletonTree<SkillEffectCtrl> get_singletonTree() { }
    //protected IBattleManagerForSkillEffectCtrl get_battleManager() { }

    public static void StaticInitSingletonTree() { }

    public static void StaticRelease() { }

    private void Awake() { }

    protected void awakeImpl() { }

    private void OnDestroy() { }

    protected virtual void onDestroy() { }

    private void setLayerName(string value) { }

    public void SetLayerUI() { }

    public virtual void InitializeSort() { }

    public void InitializeSortForWithOutBattle() { }

    public virtual void ExecAppendCoroutine(UnitCtrl _unit, bool _isAbnormal = false) { }

    private void particleRendererDictionaryInitialize() { }

    //public virtual void SetPossitionAppearanceType(NormalSkillEffect _skillEffect, BasePartsData _target, UnitCtrl _owner, Skill _skill) { }

    //public virtual void StartUpdateDisappear(bool _isUnionBurst, BasePartsData _target) { }

    //public IEnumerator TrackTarget(BasePartsData _trans, Vector3 _absolutePosition, bool _followX = true, bool _followY = true, Bone _bone, bool _trackRotation = false, SkillEffectCtrl.eToadTrackType _toadTrackType = 0) { }

    //private IEnumerator updateBoneTimeLine(BasePartsData _partsData, bool _trackRotation) { }

    //public IEnumerator TrackTarget(BattleUnitBaseSpineController _spine, Vector3 _absolutePosition, bool _followX = true, bool _followY = true, Bone _bone, bool _trackRotation = false, Transform _traskScale, float _coefficient = 1, bool _callFromBossDialog = false) { }

    //public IEnumerator TrackTargetSort(UnitCtrl _unit, bool _allowSortOrderFront = true) { }

    //private IEnumerator updateTimer(int _coroutineId) { }

    //private IEnumerator UpdateTimerRepeat() { }

    //public virtual bool _Update() { }

    public virtual void Pause() { }

    protected virtual void resetStartDelay() { }

    public virtual void Resume() { }

    //protected virtual void initTweener(UITweener _tweener) { }

    public virtual void SetSortOrderBack() { }

    public virtual void SetSortOrderFront() { }

    public void SetSortOrderStatus(int offset) { }

    public void SetSortOrderHit(int _offset) { }

    public void SetSortOrderForSummon(int _sortOrder) { }

    //protected void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit) { }

    public void PlaySe(int soundUnitId, bool isEnemySide) { }

    public void PlaySe(eSE se, bool isEnemySide) { }
    //public IEnumerator FadeoutSe(Action _callback, float _fadeSec) { }

    private void pauseSe(bool isPause) { }

    //public CriAtomSource get_SeSource() { }

    //public void set_SeSource(CriAtomSource value) { }

    public void SetSource(UnitCtrl _source) { }

    public virtual void ResetParameter(GameObject _prefab, int _skinID = 0, bool _isShadow = false) { }

    public void RestartTween() { }

    public void SetTimeToDie(bool value) { }
    //public IEnumerator TrackTargetSortForSummon(UnitCtrl _unitCtrl) { }

    public virtual void SetStartTime(float _starttime) { }

    public virtual void OnAwakeWhenSkipCutIn() { }

    public virtual void SetTimeToDieByStartHp(float _hpPercent) { }
}