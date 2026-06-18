using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Elements.Battle.Core;
using UnityEditor.Build.Pipeline;

namespace Elements 
{ 
    [Serializable]
    public class BasePartsData 
    {
        private const int ALL_DETAIL_VALUE = -1;
	    private int currentAbnormalResistId; 
        private int currentDebuffResistId; 
        public float PositionX;
        public float PositionY;
        public List<AttachmentNamePair> AttachmentNamePairList; 
        public bool DisableStartBreakEffect; 
        public float ChangeAttachmentStartTime;
        public float ChangeAttachmentEndTime; 
	    public float BodyWidthValue; 
        public int Index;
        public int EnemyId; 
        public float BreakEffectTime; 
        public float BreakEffectOffsetY;
        public float BreakEffectSize; 
        private UnitCtrl owner;
	    private float lastHealEffectTime; 
	    private Dictionary<int, Dictionary<eActionType, Dictionary<int, int>>> abnormalResistIdDictionary;
        private Dictionary<int, Dictionary<BuffParamKind, int>> debuffResistIdDictionary; 
        private Dictionary<int, int> talentWeaknessPercent; 

        public int StartAbnormalResistId { get; set; }
        public int StartDebuffResistId { get; set; }
        public List<NormalSkillEffect> BreakEffectList { get; set; }
        public float InitialPositionX { get; set; }
        public UnitCtrl Owner { get; set; }
        public long TotalDamage { get; set; }
        protected BattleManager battleManager { get; set; }
        public int UbAttackHitCount { get; set; }
        public bool PassiveUbIsMagic { get; set; }
        public bool IsBlackoutTarget { get; set; }
        public int AbnormalResistIdSetCount { get; set; }
        public int DebuffResistIdSetCount { get; set; }
        /*
        [Serializable]
        private sealed class BasePartsData.<> c 
        {
            public static readonly BasePartsData.<> c<>9;
            public static Func<KeyValuePair<int, int>, bool> <> 9__69_0; 
            public static Func<KeyValuePair<int, int>, int> <> 9__69_1; 

            private static BasePartsData() { }

            public BasePartsData ctor() { }

            internal bool < get_TalentWeaknessIds > b__69_0(KeyValuePair<int, int> percentData) { }

            // RVA: 0x207A300 Offset: 0x207A300 VA: 0x207A300
            internal int < get_TalentWeaknessIds > b__69_1(KeyValuePair<int, int> weakness) { }
        }
        */
        public List<int> TalentWeaknessIds { get; } 
        private Dictionary<eActionType, Dictionary<int, int>> abnormalResistStatusDictionary { get; }
        private Dictionary<BuffParamKind, int> debuffResistStatusDictionary { get; }
        protected Elements.Battle.Core.UnitComponentParameter componentParameter { get; set; }
        protected Elements.Battle.Core.UnitComponentParameterClamped componentParameterClamped { get; set; }

        public void SetBattleManager(BattleManager _battleManager) { }

        public virtual Vector3 GetPosition() { }

        public virtual Vector3 GetLocalPosition() { }

        public virtual float GetBodyWidth() { }

        public virtual Vector3 GetBottomTransformPosition() { }

        public virtual Vector3 GetOwnerBottomTransformPosition() { }

        public Vector3 GetBottomTransformLocalPosition() { }

        public Vector3 GetBottomLossyScale() { }

        public virtual Bone GetStateBone() { }

        public virtual Bone GetCenterBone() { }

        public virtual Vector3 GetFixedCenterPos() { }

        public virtual Vector3 GetColliderCenter() { }

        public virtual Vector3 GetColliderSize() { }

        public virtual int GetLevel() { }

        public void IncrementUbAttackHitCount() { }

        public virtual long GetAtkZero() { }

        public virtual long GetMagicStrZero() { }

        public virtual long GetAccuracyZero() { }

        public virtual long GetPhysicalCriticalZero() { }

        public virtual long GetMagicCriticalZero() { }

        public virtual long GetLifeStealZero() { }

        public virtual long GetHpRecoverRateZero() { }

        public virtual float GetDodgeRate(long _accuracy) { }

        public virtual long GetDefZero() { }

        public virtual long GetMagicDefZero() { }

        public virtual long GetDefZeroForDamagedEnergy() { }

        public virtual long GetMagicDefZeroForDamagedEnergy() { }

        public virtual void SetMissAtk(UnitCtrl _source, eMissLogType _missLogType, eDamageEffectType _damageEffectType, float _scale) { }

        public void ShowHitEffect(SystemIdDefine.eWeaponSeType _weaponSeType, Skill _skill, bool _isLeft) { }

        public virtual long GetStartAtk() { }

        public virtual long GetStartDef() { }

        public virtual long GetStartMagicStr() { }

        public virtual long GetStartMagicDef() { }

        public virtual long GetStartDodge() { }

        public virtual long GetStartPhysicalCritical() { }

        public virtual long GetStartMagicCritical() { }

        public virtual long GetStartLifeSteal() { }
        /*
        [CompilerGenerated]
        private sealed class BasePartsData.< StartTotalDamage > d__119 : IEnumerator<object>, IEnumerator, IDisposable // TypeDefIndex: 1300
        {
            // Fields
            private int <> 1__state; // 0x10
            private object <> 2__current; // 0x18
            public BasePartsData<> 4__this; // 0x20
            public float _delay; // 0x28
            public bool _isLarge; // 0x2C
            public UnitCtrl _unit; // 0x30
            private long < tmpTotalDamage > 5__2; // 0x38

            // Properties
            private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
            private object System.Collections.IEnumerator.Current { get; }

            // Methods

            [DebuggerHidden]
            // RVA: 0x20781CC Offset: 0x20781CC VA: 0x20781CC
            public void .ctor(int <> 1__state) { }

            [DebuggerHidden]
            // RVA: 0x207A340 Offset: 0x207A340 VA: 0x207A340 Slot: 5
            private void System.IDisposable.Dispose() { }

            // RVA: 0x207A344 Offset: 0x207A344 VA: 0x207A344 Slot: 6
            private bool MoveNext() { }

            [DebuggerHidden]
            // RVA: 0x207A4F4 Offset: 0x207A4F4 VA: 0x207A4F4 Slot: 4
            private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

            [DebuggerHidden]
            // RVA: 0x207A4FC Offset: 0x207A4FC VA: 0x207A4FC Slot: 8
            private void System.Collections.IEnumerator.Reset() { }

            [DebuggerHidden]
            // RVA: 0x207A544 Offset: 0x207A544 VA: 0x207A544 Slot: 7
            private object System.Collections.IEnumerator.get_Current() { }
        }
        */

        public IEnumerator StartTotalDamage(bool _isLarge, float _delay, UnitCtrl _unit)
        {
            if (!JudgeShowTotalDamage()) 
                yield break;

            long tmpTotalDamage = TotalDamage;
            ResetTotalDamage();

            yield return new WaitForSeconds(_delay);

            // Show Total Damage
        }

        public bool JudgeShowTotalDamage()
        {
            return TotalDamage > 0;
        }

        public void ResetTotalDamage()
        {
            TotalDamage = 0;
        }

        public virtual void SetBuffDebuff(bool _enable, long _value, BuffParamKind _kind, UnitCtrl _source, bool _additional) { }

        public void RecoveryEffect(UnitCtrl _source, bool _isEnergy, IBattleEffectPool _battleEffectPool, bool _isRegenerate = False) { }

        public virtual bool GetTargetable() { }

        public void SetAbnormalResistId(int _resistId, bool _isInit) { }

        public void SetDebuffResistId(int _resistId, bool _isInit) { }

        private void createResistStatus(int _resistId) { }

        private void createDebuffStatus(int _resistId) { }

        public void SetTalentWeakness(Dictionary<int, int> _talentWeaknessPercent) { }

        public bool ResistStatus(eActionType _actionType, int _detail1, UnitCtrl _source, bool _last, bool _targetOneParts, BasePartsData _target) { }

        public int GetDebuffResistPercent(BuffParamKind _buffParamKind)
        {
            return debuffResistStatusDictionary[_buffParamKind];
        }

        public double GetTalentWeaknessPercent(List<int> _talentIds) { }

        public BasePartsData() { }

        [Serializable]
        public class AttachmentNamePair
        {
            public string TargetSlotName;
            public string TargetAttachmentName;
            public string AppliedSlotName;
            public string AppliedAttachmentName;

            public int TargetIndex { get; set; }
            public Attachment TargetAttachment { get; set; }
            public Attachment AppliedAttachment { get; set; }

            public AttachmentNamePair() { }
        }
    }
}