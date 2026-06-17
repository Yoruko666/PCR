using System;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Elements.Battle.Core;

namespace Elements 
{ 
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

    [Serializable]
    public class BasePartsData 
    {
        private const int ALL_DETAIL_VALUE = -1;
	    private int currentAbnormalResistId; // 0x18
        private int currentDebuffResistId; // 0x1C
        public float PositionX; // 0x20
        public float PositionY; // 0x24
        public List<AttachmentNamePair> AttachmentNamePairList; // 0x28
        public bool DisableStartBreakEffect; // 0x30
        public float ChangeAttachmentStartTime; // 0x34
        public float ChangeAttachmentEndTime; // 0x38
	    public float BodyWidthValue; // 0x4C
        public int Index; // 0x50
        public int EnemyId; // 0x54
        public float BreakEffectTime; // 0x58
        public float BreakEffectOffsetY; // 0x5C
        public float BreakEffectSize; // 0x60
        private UnitCtrl owner; // 0x68
	    private float lastHealEffectTime; // 0x88
	    private Dictionary<int, Dictionary<eActionType, Dictionary<int, int>>> abnormalResistIdDictionary; // 0x98
        private Dictionary<int, Dictionary<BuffParamKind, int>> debuffResistIdDictionary; // 0xA0
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
        public List<int> TalentWeaknessIds { get; } 
        private Dictionary<Elements.Battle.Core.eActionType, Dictionary<int, int>> abnormalResistStatusDictionary { get; }
        private Dictionary<Elements.Battle.Core.BuffParamKind, int> debuffResistStatusDictionary { get; }
        protected Elements.Battle.Core.UnitComponentParameter componentParameter { get; set; }
        protected Elements.Battle.Core.UnitComponentParameterClamped componentParameterClamped { get; set; }

        public void SetBattleManager(BattleManager _battleManager) { }

        public virtual Vector3 GetPosition() { }

        public virtual Vector3 GetLocalPosition() { }

        // RVA: 0x20772A8 Offset: 0x20772A8 VA: 0x20772A8 Slot: 6
        public virtual float GetBodyWidth() { }

        // RVA: 0x20772C8 Offset: 0x20772C8 VA: 0x20772C8 Slot: 7
        public virtual Vector3 GetBottomTransformPosition() { }

        // RVA: 0x20773A0 Offset: 0x20773A0 VA: 0x20773A0 Slot: 8
        public virtual Vector3 GetOwnerBottomTransformPosition() { }

        // RVA: 0x20773CC Offset: 0x20773CC VA: 0x20773CC
        public Vector3 GetBottomTransformLocalPosition() { }

        // RVA: 0x20773F8 Offset: 0x20773F8 VA: 0x20773F8
        public Vector3 GetBottomLossyScale() { }

        // RVA: 0x2077424 Offset: 0x2077424 VA: 0x2077424 Slot: 9
        public virtual Bone GetStateBone() { }

        // RVA: 0x2077444 Offset: 0x2077444 VA: 0x2077444 Slot: 10
        public virtual Bone GetCenterBone() { }

        // RVA: 0x2077464 Offset: 0x2077464 VA: 0x2077464 Slot: 11
        public virtual Vector3 GetFixedCenterPos() { }

        // RVA: 0x2077484 Offset: 0x2077484 VA: 0x2077484 Slot: 12
        public virtual Vector3 GetColliderCenter() { }

        // RVA: 0x20774AC Offset: 0x20774AC VA: 0x20774AC Slot: 13
        public virtual Vector3 GetColliderSize() { }

        // RVA: 0x20774D4 Offset: 0x20774D4 VA: 0x20774D4 Slot: 14
        public virtual int GetLevel() { }

        // RVA: 0x2077550 Offset: 0x2077550 VA: 0x2077550
        public void IncrementUbAttackHitCount() { }

        // RVA: 0x2077560 Offset: 0x2077560 VA: 0x2077560 Slot: 15
        public virtual long GetAtkZero() { }

        // RVA: 0x20775F0 Offset: 0x20775F0 VA: 0x20775F0 Slot: 16
        public virtual long GetMagicStrZero() { }

        // RVA: 0x2077680 Offset: 0x2077680 VA: 0x2077680 Slot: 17
        public virtual long GetAccuracyZero() { }

        // RVA: 0x2077710 Offset: 0x2077710 VA: 0x2077710 Slot: 18
        public virtual long GetPhysicalCriticalZero() { }

        // RVA: 0x20777A0 Offset: 0x20777A0 VA: 0x20777A0 Slot: 19
        public virtual long GetMagicCriticalZero() { }

        // RVA: 0x2077830 Offset: 0x2077830 VA: 0x2077830 Slot: 20
        public virtual long GetLifeStealZero() { }

        // RVA: 0x20778C0 Offset: 0x20778C0 VA: 0x20778C0 Slot: 21
        public virtual long GetHpRecoverRateZero() { }

        // RVA: 0x2077950 Offset: 0x2077950 VA: 0x2077950 Slot: 22
        public virtual float GetDodgeRate(long _accuracy) { }

        // RVA: 0x2077970 Offset: 0x2077970 VA: 0x2077970 Slot: 23
        public virtual long GetDefZero() { }

        // RVA: 0x2077A00 Offset: 0x2077A00 VA: 0x2077A00 Slot: 24
        public virtual long GetMagicDefZero() { }

        // RVA: 0x2077A90 Offset: 0x2077A90 VA: 0x2077A90 Slot: 25
        public virtual long GetDefZeroForDamagedEnergy() { }

        // RVA: 0x2077B20 Offset: 0x2077B20 VA: 0x2077B20 Slot: 26
        public virtual long GetMagicDefZeroForDamagedEnergy() { }

        // RVA: 0x2077BB0 Offset: 0x2077BB0 VA: 0x2077BB0 Slot: 27
        public virtual void SetMissAtk(UnitCtrl _source, eMissLogType _missLogType, eDamageEffectType _damageEffectType, float _scale) { }

        // RVA: 0x2077C48 Offset: 0x2077C48 VA: 0x2077C48
        public void ShowHitEffect(SystemIdDefine.eWeaponSeType _weaponSeType, Skill _skill, bool _isLeft) { }

        // RVA: 0x2077C74 Offset: 0x2077C74 VA: 0x2077C74 Slot: 28
        public virtual long GetStartAtk() { }

        // RVA: 0x2077D08 Offset: 0x2077D08 VA: 0x2077D08 Slot: 29
        public virtual long GetStartDef() { }

        // RVA: 0x2077D9C Offset: 0x2077D9C VA: 0x2077D9C Slot: 30
        public virtual long GetStartMagicStr() { }

        // RVA: 0x2077E30 Offset: 0x2077E30 VA: 0x2077E30 Slot: 31
        public virtual long GetStartMagicDef() { }

        // RVA: 0x2077EC4 Offset: 0x2077EC4 VA: 0x2077EC4 Slot: 32
        public virtual long GetStartDodge() { }

        // RVA: 0x2077F58 Offset: 0x2077F58 VA: 0x2077F58 Slot: 33
        public virtual long GetStartPhysicalCritical() { }

        // RVA: 0x2077FEC Offset: 0x2077FEC VA: 0x2077FEC Slot: 34
        public virtual long GetStartMagicCritical() { }

        // RVA: 0x2078080 Offset: 0x2078080 VA: 0x2078080 Slot: 35
        public virtual long GetStartLifeSteal() { }

        [IteratorStateMachine(typeof(BasePartsData.< StartTotalDamage > d__119))]
        // RVA: 0x2078118 Offset: 0x2078118 VA: 0x2078118
        public IEnumerator StartTotalDamage(bool _isLarge, float _delay, UnitCtrl _unit) { }

        // RVA: 0x20781F8 Offset: 0x20781F8 VA: 0x20781F8
        public bool JudgeShowTotalDamage() { }

        // RVA: 0x207821C Offset: 0x207821C VA: 0x207821C
        public void ResetTotalDamage() { }

        // RVA: 0x2078228 Offset: 0x2078228 VA: 0x2078228 Slot: 36
        public virtual void SetBuffDebuff(bool _enable, long _value, Elements.Battle.Core.BuffParamKind _kind, UnitCtrl _source, IBattleLog _battleLog, bool _additional) { }

        // RVA: 0x20791B0 Offset: 0x20791B0 VA: 0x20791B0
        public void RecoveryEffect(UnitCtrl _source, bool _isEnergy, IBattleEffectPool _battleEffectPool, bool _isRegenerate = False) { }

        // RVA: 0x20795FC Offset: 0x20795FC VA: 0x20795FC Slot: 37
        public virtual bool GetTargetable() { }

        // RVA: 0x2079604 Offset: 0x2079604 VA: 0x2079604
        public void SetAbnormalResistId(int _resistId, bool _isInit) { }

        // RVA: 0x2079A20 Offset: 0x2079A20 VA: 0x2079A20
        public void SetDebuffResistId(int _resistId, bool _isInit) { }

        // RVA: 0x2079698 Offset: 0x2079698 VA: 0x2079698
        private void createResistStatus(int _resistId) { }

        // RVA: 0x2079AB4 Offset: 0x2079AB4 VA: 0x2079AB4
        private void createDebuffStatus(int _resistId) { }

        // RVA: 0x2079C70 Offset: 0x2079C70 VA: 0x2079C70
        public void SetTalentWeakness(Dictionary<int, int> _talentWeaknessPercent) { }

        // RVA: 0x2079C78 Offset: 0x2079C78 VA: 0x2079C78
        public bool ResistStatus(Elements.Battle.Core.eActionType _actionType, int _detail1, UnitCtrl _source, bool _last, bool _targetOneParts, BasePartsData _target) { }

        // RVA: 0x2079E68 Offset: 0x2079E68 VA: 0x2079E68
        public int GetDebuffResistPercent(Elements.Battle.Core.BuffParamKind _buffParamKind) { }

        // RVA: 0x2079EE8 Offset: 0x2079EE8 VA: 0x2079EE8
        public double GetTalentWeaknessPercent(List<int> _talentIds) { }

        // RVA: 0x2079FCC Offset: 0x2079FCC VA: 0x2079FCC
        public void .ctor() { }

        [CompilerGenerated]
        // RVA: 0x207A118 Offset: 0x207A118 VA: 0x207A118
        private int <GetTalentWeaknessPercent>b__132_0(int id) { }

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