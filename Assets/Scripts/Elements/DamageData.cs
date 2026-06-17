using System;
using System.Runtime.CompilerServices;

namespace Elements 
{ 
    [Serializable]
    public class DamageData 
    {
	    public eDamageSoundType DamageSoundType { get; set; }
        public BasePartsData Target { get; set; }
        public long TotalDamageForLogBarrier { get; set; }
        public bool IsLogBarrierCritical { get; set; }
        public long LogBarrierExpectedDamage { get; set; }
        public long LogBarrierExpectedDamageForEnergyCalc { get; set; }
        public bool LogBarrierExpectedIsNoDamageByResist { get; set; }
        public long Damage { get; set; }
        public UnitCtrl Source { get; set; }
        public UnitCtrl StrikeBackSource { get; set; }
        public float CriticalRate { get; set; }
        public float CriticalRateForLogBarrier { get; set; }
        public eDamageType DamageType { get; set; }
        public eDamageEffectType DamegeEffectType { get; set; }
        public long DefPenetrate { get; set; }
        public Elements.Battle.Core.eActionType ActionType { get; set; }
        public bool TargetIncludeMyTeam { get; set; }
        public bool IgnoreDef { get; set; }
        public bool IsDivisionDamage { get; set; }
        public long LifeSteal { get; set; }
        public Func<double, double> LimitDamageFunc { get; set; }
        public bool IsSlipDamage { get; set; }
        public double CriticalDamageRate { get; set; }
        public bool DamageNumMagic { get; set; }
        public float DamegeNumScale { get; set; }
        public Func<long, long> ExecAbsorber { get; set; }
        public bool IsAlwaysChargeEnegry { get; set; }
        public long OverrideDamageLimit { get; set; }
        public bool IgnoreStrikeBackAndAllUnitDamageCutTrigger { get; set; }
        public bool IgnoreLogBarrier { get; set; }

        public enum eDamageType 
        {
            Atk = 1,
            Mgc = 2,
            None = 3,
        }

        public enum eDamageSoundType 
        {
            Hit = 0,
            Slip = 1,
        }
    }
}