using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Elements.Battle.Core 
{

    public class AttackActionBase : ActionParameter 
    {
        private BasePartsData parts; 
        public bool UseCopyAtkParam; 
        public long CopyAtk; 

        public eCriticalReference CriticalReference { get; set; }
        public long AdditionalCritical { get; set; }


        private long LCGBKNEMDGK(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private bool MFEJBMDNNGC(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected bool PMJHFMAGIBE(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        protected virtual double HNIOPOEBDHI(Dictionary<eValueNumber, double> _valueDictionary) { }

        private bool judgeDarkMiss(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        private bool NHIGLMGBDEC(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        public long CJEBEHJBIGI() { }

        private void BPEJOCCPGDJ(DamageData _damageData, Dictionary<BasePartsData, long> _limitDamageDictionary, BasePartsData _target) { }

        public AttackActionBase() { }

        private long calcDamage(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private bool DBPAMGJEFEA(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected bool BAGNFHHNHAM(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        private bool NKCEMGOLBFC(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        public void LKGCPACJCHB(long value) { }

        public void BJDIMAIEMAE(long value) { }

        public void ACHLDAOENJG(eCriticalReference value) { }

        private long NEOBNPFDJGF(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected bool AFBCJHDCODK(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        public void IMMHFLOJLLG(long value) { }

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
            (_skill) =>
            {
                _skill.ex
            };
        }

        protected bool NOBBHIADBLM(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        protected virtual DamageData LHBHGFECKMH(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        public void DGBCCIFDMGC(eCriticalReference value) { }

        private long NBCHCPCKFGI(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private long JBOIINBBAKH(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private bool GNBJAGFBHIM(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        public long JGILMHFKDBO() { }

        private bool BKGJBJDDMJA(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        private long LCIEELIOCFP(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected virtual DamageData NDKPAMJKAIC(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        protected bool NODMFHHJBCA(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        protected virtual double LKOAOMFKDAG(Dictionary<eValueNumber, double> _valueDictionary) { }

        protected bool KCBEAJJFNOJ(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        private bool PLBFJANCCGJ(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected virtual DamageData FMJOGIFBECE(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        public void AGGMPODKKCE(long value) { }

        protected bool HEJHFPALKIC(eAttackType _attackType) { }

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

        private long INCGKPKHEAC(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected bool IABPLBBMDJC(eAttackType _attackType) { }

        private bool EJMNIPPPGDH(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected virtual double LFMNGKCNJCE(Dictionary<eValueNumber, double> _valueDictionary) { }

        private long FJEMNKBKKDB(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        public void KKFGOAONJPF(eCriticalReference value) { }

        private long EACLLMPPDGM(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected virtual double PDGPJJPGAPA(Dictionary<eValueNumber, double> _valueDictionary) { }

        private bool IBGNPGOIKOD(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        private bool EPCEGMHLIBI(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected bool GOHENAEFFLK(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        private long JGGALNIMANF(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private void IEPDIPBDJLM(DamageData _damageData, Dictionary<BasePartsData, long> _limitDamageDictionary, BasePartsData _target) { }

        private long LAKDHLJNPCH(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected bool KGJBGLGFFJB(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        private long HIPFAAMDMGL(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected virtual DamageData CDGBGBHPOGD(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        protected virtual DamageData createDamageData(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        public void CHPOPCBEKIK(long value) { }

        public void MOAGACFOCCH(long value) { }

        private long PEGDKFLJNFF(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        public void KGGFAHOIDJE(eCriticalReference value) { }

        public void DCJEMBGFMDA(eCriticalReference value) { }

        public void FBPKHAAGEBE(long value) { }

        private long OMLCLFFNGKA(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private bool CKKFCADAGLD(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected virtual double FNMMMNIAEPK(Dictionary<eValueNumber, double> _valueDictionary) { }

        public eCriticalReference CHJPCPBEJJA() { }

        protected virtual DamageData GHMNHMCLALG(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        private long KNFJLBPECJB(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        public eCriticalReference GFFLGGCKILP() { }

        private bool HMPMKNAKJKJ(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        private bool AIANGGPNLHI(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        public void MLGCFDOJGLK(long value) { }

        protected bool judgeMiss(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        public eCriticalReference DDKKPJAGGHI() { }

        protected bool LNAHGBMONIF(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        private long AONBHGDDGOI(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        public void HKKLFFBLMNA(long value) { }

        public void KILAHMKDMDB(eCriticalReference value) { }

        protected bool NKBPGFCNEGN(eAttackType _attackType) { }

        public eCriticalReference MBHPIBMIGKH() { }

        protected bool JJJPJEEOODE(eAttackType _attackType) { }

        protected bool FIHHMOHGKHE(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        // RVA: 0x3705B60 Offset: 0x3705B60 VA: 0x3705B60
        private long OHHKNFAEMNM(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected bool PFPPHDBEDPL(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        public long IGHEOGJBJDB() { }

        protected bool NMIJAIEKKEA(eAttackType _attackType) { }

        protected virtual DamageData DHDEGIMLCNM(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        private long PHEAGDBDJPH(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        public override void SetLevel(int _level)
        {
            
        }

        public void FPEFEBABIFK(long value) { }

        protected virtual double GLLEGIEGPBL(Dictionary<eValueNumber, double> _valueDictionary) { }

        public void HGJIPILOMDP(long value) { }

        public override void ExecAction(UnitCtrl _source, BasePartsData _target, int _num, UnitActionController _sourceActionController, Skill _skill, float _starttime, Dictionary<int, bool> _enabledChildAction, Dictionary<eValueNumber, double> _valueDictionary) { }

        protected virtual double GGMEHPGHPIG(Dictionary<eValueNumber, double> _valueDictionary) { }

        public long JKCJAPNAIII() { }

        private long OAMPKHDOJNI(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        protected bool HMOKADAIHHA(BasePartsData _target, UnitCtrl _source, int _num, Skill _skill, eAttackType _actionDetail1) { }

        protected virtual double JPFGBHABHLA(Dictionary<eValueNumber, double> _valueDictionary) { }

        public long GCJEMHMKPHM() { }

        public void PPADBKKDPHG(eCriticalReference value) { }

        public void AIJALMAMEFL(eCriticalReference value) { }

        public void KENODECPOCL(long value) { }

        public void NIJPGCEKHKG(eCriticalReference value) { }
        public void GEMKLEKJOGF(long value) { }

        protected bool HCMGFKLBBBG(eAttackType _attackType) { }

        protected bool judgeIsPhysical(eAttackType _attackType)
        {
            return _attackType == eAttackType.Physical || _attackType == eAttackType.InevitablePhysical;
        }

        public override void ReadyAction(UnitCtrl _source, UnitActionController _sourceActionController, Skill _skill) { }

        private long FMBIACAFFPD(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        private void OKDEOAMPINA(DamageData _damageData, Dictionary<BasePartsData, long> _limitDamageDictionary, BasePartsData _target) { }

        private bool DEPAIJJOLAH(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected virtual double LFNBGKFLEOI(Dictionary<eValueNumber, double> _valueDictionary) { }

        private long COGPANCPFHP(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, long _atk) { }

        public long IBNDJIPGFJP() { }

        public eCriticalReference ENEGOKNLFBE() { }

        private bool LBALJPHKBLO(eAbnormalState _abnormalState, eAttackType _attackType, BasePartsData _target, UnitCtrl _source, int _num) { }

        protected virtual DamageData IGHADFGJHGH(UnitCtrl _source, BasePartsData _target, int _num, Dictionary<eValueNumber, double> _valueDictionary, eAttackType _actionDetail1, bool _isCritical, Skill _skill, eActionType _actionTypeForSource, bool _isPhysicalForTarget) { }

        public eCriticalReference ICLDJLCKECE() { }

        public eCriticalReference KECHDDMPBOO() { }

        public eCriticalReference IABFMBFOMJL() { }

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