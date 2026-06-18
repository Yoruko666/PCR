namespace Elements.Battle.Core
{
    public class BuffDebuffAction : ActionParameter
    {
        public const int THOUSAND = 1000;
        private const int HP_DEBUF_DETAIL = 1;
        private const double PERCENT_DIGIT = 100;
        private const int UNDESPELABLE_NUMBER = 2;
        public const int DETAIL_DIGIT = 10;
        public const int DETAIL_DEBUFF = 1;
        public int EnvironmentId { get; set; }

        public static BuffParamKind GetChangeParamKind(int value) { }

        private bool getIsAdditional() { }

        public static long CalculateBuffDebuffParam(BasePartsData _target, double _value, Elements.Battle.Core.BuffDebuffAction.eChangeParameterType _changeParamType, Elements.Battle.Core.BuffParamKind _targetChangeParamKind, bool _isDebuf) { }

        public override void SetLevel(int _level) { }

        public override void ExecAction(UnitCtrl _source, BasePartsData _target, int _num, UnitActionController _sourceActionController, Skill _skill, float _starttime, Dictionary<int, bool> _enabledChildAction, Dictionary<Elements.Battle.Core.eValueNumber, double> _valueDictionary) { }

        private bool isShowIcon() { }

        public BuffDebuffAction() { }

        /*
        private sealed class BuffDebuffAction.<> c__DisplayClass12_1 
        {
            public Dictionary<BasePartsData, long> buffParam;
            public Elements.Battle.Core.BuffParamKind buffParamKind; 
            public bool isDebuff; 
            public Elements.Battle.Core.BuffDebuffAction.<> c__DisplayClass12_0 CS$<>8__locals1; 

            internal void < ExecActionOnStart > b__1() { }

            internal void < ExecActionOnStart > b__2() { }
        }

        private sealed class BuffDebuffAction.<> c__DisplayClass12_0 
        {
            public Skill _skill; 
            public UnitCtrl _source;
            public List<PartsData> bossPartsListForBattle; 
            public Elements.Battle.Core.BuffDebuffAction<> 4__this; 

            internal bool < ExecActionOnStart > b__0(PartsData e) { }
        }
        */

        public override void ExecActionOnStart(Skill _skill, UnitCtrl _source, UnitActionController _sourceActionController) { }

        private static double getBuffDebuffValueForCurrentValuePercentage(BasePartsData _target, double _value, BuffParamKind _targetChangeParamKind) { }

        public enum eChangeParameterType
        {
            Fixed = 1,
            Percentage = 2,
            CurrentValuePercentage = 3,
        }

        public enum eBuffDebuffStartReleaseType
        {
            Normal = 1,
            Break = 2,
        }
    }
}