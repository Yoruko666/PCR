using System.Collections.Generic;

namespace Elements.Battle.Core
{
    public class AttackAction : AttackActionBase 
    {
        private const int DAMAGE_BASE = 100;
        protected override double getCriticalDamageRate(Dictionary<eValueNumber, double> _valueDictionary) { }

        public void AttackAction() { }

        public override void SetLevel(int _level) { }

        protected override DamageData createDamageData(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget)
        {
            DamageData damageData = new DamageData();

            damageData.Source = _source;
            damageData.Target = _target;
            

            return damageData;
        }

        public override void ExecAction(UnitCtrl _source, BasePartsData _target, int _num, UnitActionController _sourceActionController, Skill _skill, float _starttime, Dictionary<int, bool> _enabledChildAction, Dictionary<eValueNumber, double> _valueDictionary) { }

        private enum eDecideTargetAtkType
        {
            SelectAttackType = 0,
            TargetLowerDefType = 1,
        }
    }
}