using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class DamageEffectCtrlBase : MonoBehaviour, ISingletonField // TypeDefIndex: 1061
    {
        // Fields
        [SerializeField]
        private UIPanel uiPanel; // 0x18
        [SerializeField]
        private Animation serializedAnimation; // 0x20
        [SerializeField]
        private CriAtomSource seSource; // 0x28
        private float defaultScale; // 0x30
        private static readonly Dictionary<DamageData.eDamageSoundType, string> SOUND_SURFIX_DIC; // 0x0
        private static StaticSingletonTree<DamageEffectCtrlBase> staticSingletonTree; // 0x8
        private static IBattleManagerForDamageEffectCtrlBase staticBattleManager; // 0x10
        private static IBattleCameraEffectForDamageEffectCtrl staticBattleCameraEffect; // 0x18
        private static IBattleTimeScaleForDamageEffectCtrlBase staticBattleTimeScale; // 0x20

        // Properties
        private Vector3 offset { get; set; }
        public bool IsPlaying { get; set; }
        private bool isPause { get; set; }
        private float timescale { get; set; }
        private int dummySortingOrder { get; set; }
        public UnitCtrl Source { get; set; }
        protected IBattleManagerForDamageEffectCtrlBase battleManager { get; }
        protected IBattleCameraEffectForDamageEffectCtrl battleCameraEffect { get; }
        protected IBattleTimeScaleForDamageEffectCtrlBase battleTimeScale { get; }

        // RVA: 0x1D34E10 Offset: 0x1D34E10 VA: 0x1D34E10
        protected IBattleManagerForDamageEffectCtrlBase get_battleManager() { }

        // RVA: 0x1D34E6C Offset: 0x1D34E6C VA: 0x1D34E6C
        protected IBattleCameraEffectForDamageEffectCtrl get_battleCameraEffect() { }

        // RVA: 0x1D34EC8 Offset: 0x1D34EC8 VA: 0x1D34EC8
        protected IBattleTimeScaleForDamageEffectCtrlBase get_battleTimeScale() { }

        // RVA: 0x1D34F24 Offset: 0x1D34F24 VA: 0x1D34F24
        public static void StaticRelease() { }

        // RVA: 0x1D34FC0 Offset: 0x1D34FC0 VA: 0x1D34FC0
        private void Awake() { }

        // RVA: 0x1D35144 Offset: 0x1D35144 VA: 0x1D35144
        private void OnDestroy() { }

        // RVA: 0x1D34570 Offset: 0x1D34570 VA: 0x1D34570 Slot: 4
        protected virtual void onDestroy() { }

        // RVA: 0x1D34624 Offset: 0x1D34624 VA: 0x1D34624 Slot: 5
        public virtual void ResetParameter(GameObject prefab) { }

        [IteratorStateMachine(typeof(DamageEffectCtrlBase.<updateAnimation>d__44))]
        // RVA: 0x1D35198 Offset: 0x1D35198 VA: 0x1D35198
        private IEnumerator updateAnimation() { }

        // RVA: 0x1D35244 Offset: 0x1D35244 VA: 0x1D35244
        public void SetPosition(BasePartsData _unitctrl, Vector3 _offset, float _scale) { }

        [IteratorStateMachine(typeof(DamageEffectCtrlBase.<updateStability>d__46))]
        // RVA: 0x1D3527C Offset: 0x1D3527C VA: 0x1D3527C
        private IEnumerator updateStability(BasePartsData _unitctrl, float _scale) { }

        // RVA: 0x1D3534C Offset: 0x1D3534C VA: 0x1D3534C
        public void SetSortOrder(int order) { }

        // RVA: 0x1D35384 Offset: 0x1D35384 VA: 0x1D35384
        public void DestroySelf() { }

        // RVA: 0x1D353B0 Offset: 0x1D353B0 VA: 0x1D353B0
        public void PlaySe(Skill _skill, UnitCtrl _source, DamageData.eDamageSoundType _damageSoundType) { }

        // RVA: 0x1D3561C Offset: 0x1D3561C VA: 0x1D3561C
        public void SetSource(UnitCtrl _source) { }

        // RVA: 0x1D34D98 Offset: 0x1D34D98 VA: 0x1D34D98
        public DamageEffectCtrlBase() { }

        static DamageEffectCtrlBase() { }

        [CompilerGenerated]
        // RVA: 0x1D357B4 Offset: 0x1D357B4 VA: 0x1D357B4
        private bool <updateAnimation>b__44_0() { }
    }

}