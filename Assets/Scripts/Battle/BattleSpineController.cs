using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elements 
{
    public class BattleSpineController : BattleUnitBaseSpineController, ISingletonField 
    {
        private bool wasSetChildObjectShader;
        private Shader[] currentChildObjectShader;
        private MeshRenderer[] childObjectMeshRender; 
        private Material[][] copyChildObjectMaterials;
	    private int startedCoroutineId; 
	    private bool isStone;
        private bool isPauseAction; 
        private const eShader stoneShader = eShader.VertexColorSeparateGrayScale;
        private const eShader pauseActionShader = eShader.VertexColorSeparateGrayScale;
	    private bool isIndependentBattleSync; 
        private static StaticSingletonTree<BattleSpineController> staticSingletonTree;
        private static IBattleManagerForBattleSpineController staticBattleManager; 

        // Properties
        public UnitCtrl Owner { get; set; }
        public bool IsStopState { get; set; }
        public bool IsPlayAnimeBattle { get; set; }
        public float StopStateTime { get; set; }
        private Action stopStateEvent { get; set; }
        public float DropTreasureBoxTime { get; set; }
        public bool IsConstantVelocity { get; set; }
        public bool IsAlphaZero { get; set; }
        private IBattleManagerForBattleSpineController battleManager { get; }
        public bool IsIndependentBattleSync { get; set; }
        public bool IsColorStone { get; set; }
        public bool IsColorPauseAction { get; set; }

        // RVA: 0x3C548FC Offset: 0x3C548FC VA: 0x3C548FC
        private void changeShaderToAllMaterial(eShader _shader) { }

        // RVA: 0x3C5497C Offset: 0x3C5497C VA: 0x3C5497C
        private void changeDefaultShaderToAllMaterial() { }

        // RVA: 0x3C54A74 Offset: 0x3C54A74 VA: 0x3C54A74
        private void setChildObjectShader(Shader _shader) { }

        // RVA: 0x3C54B1C Offset: 0x3C54B1C VA: 0x3C54B1C
        public bool HasSpecialSleepAnimatilon(int _motionPrefix) { }

        // RVA: 0x3C54B84 Offset: 0x3C54B84 VA: 0x3C54B84
        public bool CheckPlaySpecialSleepAnimeExceptRelease(int _motionPrefix) { }

        // RVA: 0x3C54D00 Offset: 0x3C54D00 VA: 0x3C54D00
        private void initChileObjectMaterialnfo() { }

        // RVA: 0x3C54FF0 Offset: 0x3C54FF0 VA: 0x3C54FF0
        public void SetCurColor(Color _color) { }

        // RVA: 0x3C55008 Offset: 0x3C55008 VA: 0x3C55008
        public static void StaticRelease() { }

        // RVA: 0x3C55074 Offset: 0x3C55074 VA: 0x3C55074
        public static void LoadCreate(eSpineType _spineType, int _unitId, int _rarity, int _prefabId, Transform _transform, Action<BattleSpineController> _callback, int _enemyColor = 0) { }

        // RVA: 0x3C5522C Offset: 0x3C5522C VA: 0x3C5522C
        public static BattleSpineController LoadCreateImmidiateBySkinId(eSpineType _spineType, int _skinId, int _trgIdx0, int _trgIdx1, Transform _transform, Action<BattleSpineController> _callback) { }

        // RVA: 0x3C5531C Offset: 0x3C5531C VA: 0x3C5531C
        public static BattleSpineController LoadCreateImmidiate(eSpineType _spineType, int _unitId, int _rarity, Transform _transform, Action<BattleSpineController> _callback) { }

        [Conditional("UNITY_EDITOR")]
        // RVA: 0x3C55464 Offset: 0x3C55464 VA: 0x3C55464
        private static void checkSpineType(eSpineType _spineType) { }

        // RVA: 0x3C55468 Offset: 0x3C55468 VA: 0x3C55468 Slot: 23
        public override void Create(SpineResourceSet _resourceSpineSet) { }

        // RVA: 0x3C557D8 Offset: 0x3C557D8 VA: 0x3C557D8 Slot: 7
        public override void OnDestroy() { }

        // RVA: 0x3C558BC Offset: 0x3C558BC VA: 0x3C558BC Slot: 20
        public override void Update() { }

        // RVA: 0x3C558C0 Offset: 0x3C558C0 VA: 0x3C558C0
        public void UpdateIndependentBattleSync() { }

        // RVA: 0x3C55B34 Offset: 0x3C55B34 VA: 0x3C55B34
        public void LateUpdateIndependentBattleSync() { }

        // RVA: 0x3C55B98 Offset: 0x3C55B98 VA: 0x3C55B98
        public void LightUpdate(float deltaTime) { }

        // RVA: 0x3C558D0 Offset: 0x3C558D0 VA: 0x3C558D0
        public void RealUpdate() { }

        // RVA: 0x3C55C18 Offset: 0x3C55C18 VA: 0x3C55C18 Slot: 10
        public override void LateUpdate() { }

        // RVA: 0x3C55B44 Offset: 0x3C55B44 VA: 0x3C55B44
        public void RealLateUpdate() { }

        // RVA: 0x3C55C1C Offset: 0x3C55C1C VA: 0x3C55C1C
        private void updateChildObjectShader() { }

        // RVA: 0x3C55D24 Offset: 0x3C55D24 VA: 0x3C55D24
        public void PlayAnime(eSpineCharacterAnimeId _animeId, bool _playLoop = true) { }

        // RVA: 0x3C55E8C Offset: 0x3C55E8C VA: 0x3C55E8C
        public void PlayAnime(eSpineCharacterAnimeId _animeId, int _index1, bool _playLoop = true) { }

        // RVA: 0x3C55D68 Offset: 0x3C55D68 VA: 0x3C55D68
        public void PlayAnime(string _playAnimeName, bool _playLoop, float _startTime = 0, bool _ignoreBlackout = false) { }

        // RVA: 0x3C560B4 Offset: 0x3C560B4 VA: 0x3C560B4
        public void RestartPlayAnimeCoroutine(float _startTime, eSpineCharacterAnimeId _animeId, int _index, int _prefix) { }

        // RVA: 0x3C56130 Offset: 0x3C56130 VA: 0x3C56130 Slot: 24
        public override void PlayAnime(string _playAnimeName, bool _playLoop = true) { }

        // RVA: 0x3C5613C Offset: 0x3C5613C VA: 0x3C5613C
        public void PlayAnimeNoOverlap(eSpineCharacterAnimeId _animeId, int _index1, bool _playLoop = true) { }

        // RVA: 0x3C56178 Offset: 0x3C56178 VA: 0x3C56178
        public void PlayAnimeNoOverlap(eSpineCharacterAnimeId _animeId, int _index1, int _ndex2, int _index3, bool _playLoop = true) { }

        // RVA: 0x3C561AC Offset: 0x3C561AC VA: 0x3C561AC
        public void SetAnimeEventDelegateForBattle(Action _callBack, int _motionPrefix = -1) { }

        // RVA: 0x3C56384 Offset: 0x3C56384 VA: 0x3C56384
        public void SetDropTreasureBoxTime() { }

        // RVA: 0x3C56550 Offset: 0x3C56550 VA: 0x3C56550
        public void PlayAnime(eSpineCharacterAnimeId _animeId, int _index1, int _index2, int _index3, bool _playLoop = true, float _startTime = 0, bool _ignoreBlackout = false) { }

        // RVA: 0x3C55ECC Offset: 0x3C55ECC VA: 0x3C55ECC
        private void setUpdateAnime(float _startTime, float _endTime, bool _ignoreBlackout = false) { }
        private IEnumerator updateAnime(float _startTime, float _endTime, int _thisId) { }
        private float getDeltaTimeForPause() { }
        public BattleSpineController() { }
    }
}