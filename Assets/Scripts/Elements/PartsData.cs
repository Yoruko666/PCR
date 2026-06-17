using Elements.Battle.Core;
using Spine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elements 
{
    [Serializable]
    public class PartsData : BasePartsData, ISingletonField 
    {
        private const string CENER_BONE = "Center_{0:D2}";
        private const string STATE_BONE = "State_{0:D2}";
        
        private IBattleEffectPool battleEffectPool; 
        
        private long DefForDamagedEnergy; 
        private long MagicDefForDamagedEnergy; 

	    public Action OnBreak { get; set; }
        public Action OnBreakEnd { get; set; }
        public bool IsBreak { get; set; }
        public UnitCtrl BreakSource { get; set; }
        public MultiTargetCursor MultiTargetCursor { get; set; }
        private Bone centerBone { get; set; }
        private Bone stateBone { get; set; }
        private Vector3 fixedCenterPos { get; set; }
        public int Level { get; set; }
        public long Atk { get; set; }
        public long MagicStr { get; set; }
        public long Def { get; set; }
        public long MagicDef { get; set; }
        public long Dodge { get; set; }
        public long Accuracy { get; set; }
        public long PhysicalCritical { get; set; }
        public long MagicCritical { get; set; }
        public long LifeSteal { get; set; }
        public long HpRecoveryRate { get; set; }
        public long StartAtk { get; set; }
        public long StartMagicStr { get; set; }
        public long StartDef { get; set; }
        public long StartMagicDef { get; set; }
        public long StartDodge { get; set; }
        public long StartPhysicalCritical { get; set; }
        public long StartMagicCritical { get; set; }
        public long StartLifeSteal { get; set; }
        public long BreakPoint { get; set; }
        public float BreakTime { get; set; }
        public long MaxBreakPoint { get; set; }
        private Dictionary<BuffParamKind, long> additionalBuffDictionary { get; set; }

        public override bool GetTargetable() { }

        /*
        private sealed class PartsData.<> c__DisplayClass132_0 // TypeDefIndex: 1322
        {
            public BasePartsData.AttachmentNamePair pair; // 0x10

            public void .ctor() { }

            internal bool < Initialize > b__0(Slot e) { }

            internal bool < Initialize > b__1(Slot e) { }
        }
        */

        public void Initialize(Elements.Data.MasterEnemyMParts.EnemyMParts _enemyMParts, BattleManager _battleManager)
        {

        }

        public override Bone GetStateBone()
        {
            return stateBone;
        }

        public override Bone GetCenterBone()
        {
            return centerBone;
        }

        public override Vector3 GetBottomTransformPosition() { }

        public override Vector3 GetFixedCenterPos() { }

        public override Vector3 GetPosition() { }

        public override Vector3 GetLocalPosition() { }

        public override float GetBodyWidth() { }

        public override Vector3 GetColliderCenter() { }

        public override Vector3 GetColliderSize() { }

        public override long GetDefZero() { }

        public override long GetMagicDefZero() { }

        private long getDodgeZero() { }

        public override long GetAtkZero() { }

        public override long GetMagicStrZero() { }

        public override long GetAccuracyZero() { }

        public override long GetPhysicalCriticalZero() { }

        public override long GetMagicCriticalZero() { }

        public override long GetLifeStealZero() { }

        public override long GetHpRecoverRateZero() { }

        public override int GetLevel()
        {
            return Level;
        }

        public override float GetDodgeRate(long _accuracy) { }

        public override long GetDefZeroForDamagedEnergy() { }

        public override long GetMagicDefZeroForDamagedEnergy() { }

        public override long GetStartAtk()
        {
            return StartAtk;
        }

        public override long GetStartDef()
        {
            return StartDef;
        }

        public override long GetStartMagicStr()
        {
            return StartMagicStr;
        }

        public override long GetStartMagicDef()
        {
            return StartMagicDef;
        }

        public override long GetStartDodge()
        {
            return StartDodge;
        }

        public override long GetStartPhysicalCritical()
        {
            return StartPhysicalCritical;
        }

        public override long GetStartMagicCritical()
        {
            return StartMagicCritical;
        }

        public override long GetStartLifeSteal()
        {
            return StartLifeSteal;
        }

        public override void SetMissAtk(UnitCtrl _source, eDamageEffectType _damageEffectType, float _scale) { }

        public override void SetBuffDebuff(bool _enable, long _value, BuffParamKind _kind, UnitCtrl _source, bool _additional) { }

        /*
        private sealed class PartsData.< TrackBottomCoroutine > d__166 : IEnumerator<object>, IEnumerator, IDisposable // TypeDefIndex: 1323
            {
                // Fields
                private int <> 1__state; // 0x10
                private object <> 2__current; // 0x18
                public PartsData<> 4__this; // 0x20
                public bool _topBack; // 0x28

            // Properties
            private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
            private object System.Collections.IEnumerator.Current { get; }


            [DebuggerHidden]
            public void .ctor(int <> 1__state) { }

            [DebuggerHidden]
            private void IDisposable.Dispose() { }

            private bool MoveNext() { }

            [DebuggerHidden]
            private object IEnumerator<Object>.get_Current() { }

            [DebuggerHidden]
            private void IEnumerator.Reset() { }

            [DebuggerHidden]
            private object IEnumerator.get_Current() { }
        }
        */

        public IEnumerator TrackBottomCoroutine(bool _topBack)
        {

        }

        public void TrackBottom(bool _isTopBack) { }

        public void SetDamage(long _damage, UnitCtrl _source) { }

        /*
        private sealed class PartsData.<>c /
        {
	        public static readonly PartsData.<>c<>9; 
	        public static Predicate<PartsData> <>9__169_0; 
	        private static void .cctor() { }

            public void .ctor() { }
            internal bool <SetBreak>b__169_0(PartsData e) { }
        }
        */

        public void SetBreak(bool _enable, Transform _unitUiCtrl, bool _displayEffect) { }

        private void createBreakEffect(int _targetMotion) { }

        /*
        private sealed class PartsData.< waitAndPlayBreak > d__171 : IEnumerator<object>, IEnumerator, IDisposable 
        {
            private int <> 1__state; 
            private object <> 2__current; 
            public float _timer; 
            public PartsData<> 4__this; 
            public Transform _unitUiCtrl; 

            private object IEnumerator<System.Object>.Current { get; }
            private object IEnumerator.Current { get; }

            [DebuggerHidden]
            // RVA: 0x2081FA0 Offset: 0x2081FA0 VA: 0x2081FA0
            public void .ctor(int <> 1__state) { }

            [DebuggerHidden]
            private void IDisposable.Dispose() { }

            private bool MoveNext() { }

            [DebuggerHidden]
            private object IEnumerator<Object>.get_Current() { }

            [DebuggerHidden]
            private void IEnumerator.Reset() { }

            [DebuggerHidden]
            private object IEnumerator.get_Current() { }
        }
         */
        private IEnumerator waitAndPlayBreak(float _timer, Transform _unitUiCtrl) { }

        /*
        private sealed class PartsData.< updateChangeAttachment > d__172 : IEnumerator<object>, IEnumerator, IDisposable // TypeDefIndex: 1324
        {
            private int <> 1__state; // 0x10
            private object <> 2__current; // 0x18
            public float _timer; // 0x20
            public PartsData<> 4__this; // 0x28
                public bool _enable; // 0x30

            // Properties
            private object IEnumerator<System.Object>.Current { get; }
            private object IEnumerator.Current { get; }


            [DebuggerHidden]
            public void .ctor(int <> 1__state) { }

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
        private IEnumerator updateChangeAttachment(float _timer, bool _enable) { }

        public void ChangeAttachment(UnitCtrl _owner) { }

        public void FixAttachment(UnitCtrl _owner) { }

        public void DisableCursor() { }
        /*

        private sealed class PartsData.< waitAndBreakPointReset > d__176 : IEnumerator<object>, IEnumerator, IDisposable
        {
            private int <> 1__state; 
            private object <> 2__current; 
            public PartsData<> 4__this; 
            private float < time > 5__2;

            // Properties
            private object IEnumerator<System.Object>.Current { get; }
            private object IEnumerator.Current { get; }

            // Methods

            [DebuggerHidden]
            public void .ctor(int <> 1__state) { }

            [DebuggerHidden]
            private void IDisposable.Dispose() { }

            private bool MoveNext() { }

            [DebuggerHidden]
            private object IEnumerator<System.Object>.get_Current() { }

            [DebuggerHidden]
            private void IEnumerator.Reset() { }

            [DebuggerHidden]
            private object IEnumerator.get_Current() { }
        }
        */
        private IEnumerator waitAndBreakPointReset() { }
    }
}