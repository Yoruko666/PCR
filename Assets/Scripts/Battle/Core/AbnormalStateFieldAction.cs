using System.Collections.Generic;

namespace Elements.Battle.Core 
{
    public class AbnormalStateFieldAction : ActionParameter
    {
        private ActionParameter targetAction; 
        public eAbnormalState TargetAbnormalState { get; set; }

        public eAbnormalState GetAbnormalState() => TargetAbnormalState;

        public void SetAbnormalState(eAbnormalState value) => TargetAbnormalState = value;

        private bool IsChildActionValid(ActionParameter childAction)
        {

        }

        public override void ReadyAction(UnitCtrl _source, UnitActionController _sourceActionController, Skill _skill) { }

        public override void SetLevel(int _level) { }

        public override void ExecAction(UnitCtrl _source, BasePartsData _target, int _num, UnitActionController _sourceActionController, Skill _skill, float _starttime, Dictionary<int, bool> _enabledChildAction, Dictionary<eValueNumber, double> _valueDictionary)
        {

        }
        public override void ExecActionOnStart(Skill _skill, UnitCtrl _source, UnitActionController _sourceActionController)  //bool lambda 1
        {

        }

        public AbnormalStateFieldAction()
        { 

        }
    }
}