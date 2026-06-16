using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BattleSpineController : BattleUnitBaseSpineController, ISingletonField
{
    private bool wasSetChildObjectShader;
    private Shader[] currentChildObjectShader;
    private MeshRenderer[] childObjectMeshRender;
    private Material[][] copyChildObjectMaterials;
    private int startedCoroutineId;
    private bool isStone;
    private bool isPauseAction;
    private const eShader stoneShader = eShader.VertexColorSepareteGrayScale;
    private const eShader pauseActionShader = eShader.VertexColorSepareteGrayScale;
    private bool isIndependentBattleSync;
//  private static StaticSingletonTree<BattleSpineController> staticSingletonTree;
//  private static IBattleManagerForBattleSpineController staticBattleManager;

    // Properties
    public UnitCtrl Owner { get; set; }
    public bool IsStopState { get; set; }
    public bool IsPlayAnimeBattle { get; set; }
    public float StopStateTime { get; set; }
    private Action stopStateEvent { get; set; }
    public float DropTreasureBoxTime { get; set; }
    public bool IsConstantVelocity { get; set; }
    public bool IsAlphaZero { get; set; }
//  private IBattleManagerForBattleSpineController battleManager { get; }
    public bool IsIndependentBattleSync { get; set; }
    public bool IsColorStone { get; set; }
    public bool IsColorPauseAction { get; set; }
    private void changeShaderToAllMaterial(eShader _shader) { }
    private void changeDefaultShaderToAllMaterial() { }
    private void setChildObjectShader(Shader _shader) { }
//  public bool HasSpecialSleepAnimatilon(int _motionPrefix) { }
//  public bool CheckPlaySpecialSleepAnimeExceptRelease(int _motionPrefix) { }
    private void initChileObjectMaterialnfo() { }
    public void SetCurColor(Color _color) { }
    public static void StaticRelease() { }
    public static void LoadCreate(eSpineType _spineType, int _unitId, int _rarity, int _prefabId, Transform _transform, Action<BattleSpineController> _callback, int _enemyColor = 0) { }
//  public static BattleSpineController LoadCreateImmidiateBySkinId(eSpineType _spineType, int _skinId, int _trgIdx0, int _trgIdx1, Transform _transform, Action<BattleSpineController> _callback) { }
//  public static BattleSpineController LoadCreateImmidiate(eSpineType _spineType, int _unitId, int _rarity, Transform _transform, Action<BattleSpineController> _callback) { }
//  public override void Create(SpineResourceSet _resourceSpineSet) { }
//  public override void OnDestroy() { }
//  public override void Update() { }
    public void UpdateIndependentBattleSync() { }
    public void LateUpdateIndependentBattleSync() { }
    public void LightUpdate(float deltaTime) { }
    public void RealUpdate() { }
    public override void LateUpdate() { }
    public void RealLateUpdate() { }
    private void updateChildObjectShader() { }
    public void PlayAnime(eSpineCharacterAnimeId _animeId, bool _playLoop = true) { }
    public void PlayAnime(eSpineCharacterAnimeId _animeId, int _index1, bool _playLoop = true) { }
    public void PlayAnime(string _playAnimeName, bool _playLoop, float _startTime = 0, bool _ignoreBlackout = false) { }
    public void RestartPlayAnimeCoroutine(float _startTime, eSpineCharacterAnimeId _animeId, int _index, int _prefix) { }
    public override void PlayAnime(string _playAnimeName, bool _playLoop = true) { }
    public void PlayAnimeNoOverlap(eSpineCharacterAnimeId _animeId, int _index1, bool _playLoop = true) { }
    public void PlayAnimeNoOverlap(eSpineCharacterAnimeId _animeId, int _index1, int _ndex2, int _index3, bool _playLoop = true) { }
    public void SetAnimeEventDelegateForBattle(Action _callBack, int _motionPrefix = -1) { }
    public void SetDropTreasureBoxTime() { }
    public void PlayAnime(eSpineCharacterAnimeId _animeId, int _index1, int _index2, int _index3, bool _playLoop = true, float _startTime = 0, bool _ignoreBlackout = false) { }
    private void setUpdateAnime(float _startTime, float _endTime, bool _ignoreBlackout = false) { }
//  private IEnumerator updateAnime(float _startTime, float _endTime, int _thisId) { }
//  private float getDeltaTimeForPause() { }
    public BattleSpineController() { }
}