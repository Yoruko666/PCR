using System.Collections.Generic;

namespace Elements.Battle.Core 
{
    public class AttackActionBase : ActionParameter 
    {
        private BasePartsData parts; 
        public bool UseCopyAtkParam; 
        public long CopyAtk;

        public AttackActionBase() { }

        public eCriticalReference CriticalReference { get; set; }
        public long AdditionalCritical { get; set; }

        private bool judgeDarkMiss(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        private long calcDamage(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private long calcTotalDamage(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }
        
        /*
        private sealed class <> c__DisplayClass14_0 
        {
            public Skill _skill; 

            internal bool < ExecActionOnStart > b__0(PartsData e) { }
        }
        */
        public override void ExecActionOnStart(Skill _skill, UnitCtrl _source, UnitActionController _sourceActionController)
        {
        }

        /*
        private sealed class <> c__DisplayClass19_0 
        {
            public Dictionary<BasePartsData, long> _limitDamageDictionary;
            public BasePartsData _target; 

            internal double < setupLimitDamageData > b__0(double _damage) { }
        }
        */
        private void setupLimitDamageData(DamageData _damageData, Dictionary<BasePartsData, long> _limitDamageDictionary, BasePartsData _target)
        {

        }

        protected virtual double getCriticalDamageRate(Dictionary<eValueNumber, double> _valueDictionary) { }

        protected virtual DamageData createDamageData(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        protected bool judgeMiss(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        public override void SetLevel(int _level)
        {
            
        }

        public override void ExecAction(UnitCtrl _source, BasePartsData _target, int _num, UnitActionController _sourceActionController, Skill _skill, float _starttime, Dictionary<int, bool> _enabledChildAction, Dictionary<eValueNumber, double> _valueDictionary) { }

        protected bool judgeIsPhysical(eAttackType _attackType)
        {
            return _attackType == eAttackType.Physical || _attackType == eAttackType.InevitablePhysical;
        }

        public override void ReadyAction(UnitCtrl _source, UnitActionController _sourceActionController, Skill _skill) { }

        public enum eCriticalReference 
        {
            Normal = 0,
            Physical = 1,
            Magic = 2,
            Sum = 3
        }

        public enum eAttackType
        {
            Physical = 1,
            Magic = 2,
            InevitablePhysical = 3
        }
    }
}