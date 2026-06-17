using System;

namespace Elements.Battle.Core 
{
    public class UnitComponentParameter
    {
        public long StartHpWithoutPassive { get; set; }
        public long StartMaxHP { get; set; }
        public long StartAtk { get; set; }
        public long StartMagicStr { get; set; }
        public long StartDef { get; set; }
        public long StartMagicDef { get; set; }
        public long StartDodge { get; set; }
        public long StartAccuracy { get; set; }
        public long StartPhysicalCritical { get; set; }
        public long StartMagicCritical { get; set; }
        public long StartEnergyRecoveryRate { get; set; }
        public long StartLifeSteal { get; set; }
        public float StartMoveSpeed { get; set; }
        public long StartWaveHpRecovery { get; set; }
        public long StartWaveEnergyRecovery { get; set; }
        public long StartPhysicalPenetrate { get; set; }
        public long StartMagicPenetrate { get; set; }
        public long StartHpRecoveryRate { get; set; }
        public long StartEnergyReduceRate { get; set; }
        public long StartPhysicalCriticalDamageRate { get; set; }
        public long StartMagicCriticalDamageRate { get; set; }
        public long StartReceiveCriticalDamageRate { get; set; }
        public long StartPhysicalAndMagicReceiveDamagePercent { get; set; }
        public long StartPhysicalReceiveDamagePercent { get; set; }
        public long StartMagicReceiveDamagePercent { get; set; }
        public long StartPhysicalDamageUpPercent { get; set; }
        public long StartMagicDamageUpPercent { get; set; }
        public long StartTalentFormationBonus { get; set; }
        public long StartMaxHpForDamagedEnergy { get; set; }
        public long DefForDamagedEnergy { get; set; }
        public long MagicDefForDamagedEnergy { get; set; }
        public int Level { get; set; }
        public long Hp { get; set; }
        public long MaxHp { get; set; }
        public long Atk { get; set; }
        public long MagicStr { get; set; }
        public long Def { get; set; }
        public long MagicDef { get; set; }
        public long Dodge { get; set; }
        public long Accuracy { get; set; }
        public long PhysicalCritical { get; set; }
        public long MagicCritical { get; set; }
        public long WaveHpRecovery { get; set; }
        public long WaveEnergyRecovery { get; set; }
        public long EnergyRecoveryRate { get; set; }
        public long LifeSteal { get; set; }
        public long PhysicalPenetrate { get; set; }
        public long MagicPenetrate { get; set; }
        public long HpRecoveryRate { get; set; }
        public long EnergyReduceRate { get; set; }
        public long PhysicalCriticalDamageRate { get; set; }
        public long MagicCriticalDamageRate { get; set; }
        public long ReceiveCriticalDamageRate { get; set; }
        public long AdditionalPhysicalAndMagicReceiveDamagePercent { get; set; }
        public long AdditionalPhysicalReceiveDamagePercent { get; set; }
        public long AdditionalMagicReceiveDamagePercent { get; set; }
        public long AdditionalPhysicalDamageUpPercent { get; set; }
        public long AdditionalMagicDamageUpPercent { get; set; }
        public long AdditionalTalentBonusPermyriad { get; set; }
        public float MoveSpeed { get; set; }
        public long MaxHpAfterPassive { get; set; }
        public float EnergyAmount { get; }
        public float LifeAmount { get; }
        public float MaxLifeAmount { get; }
        public double Energy { get; set; }
        public Action<float> OnEnergyChange { get; set; }
        private Action<long> OnHpChanged { get; set; }
        public UnitComponentParameter(Action<long> _onHpChanged) { }

        public void SetCurrentHp(long _value) => Hp = _value;

        public void ApplyEnhanceValue(eParamType _buffType, long _value, bool _first, bool _isImmutableMaxHp) { }

        public void SetEnergy(double _energy, eSetEnergyType _type, UnitCtrl _source) { }

        public void InitParamValue(bool _isFirst) { }

        public void RegisterComponentSet(IUnitComponentContainer _container) { }

        public void InitializeParameter(long _hp, long _atk, long _def, long _magicStr, long _magicDef, long _waveHpRecovery, long _waveEnergyRecovery, long _physicalCritical, long _magicCritical, long _dodge, long _accuracy, long _lifeSteal, long _physicalPenetrate, long _magicPenetrate, long _hpRecoveryRate, long _energyRecoveryRate, long _energyReduceRate, long _startMaxHpForDamagedEnergy, long _defForDamagedEnergy, long _magicDefForDamagedEnergy, long _physicalCriticalDamageRate, long _magicCriticalDamageRate, long _receiveCriticalDamageRate, long _additionalPhysicalAndMagicReceiveDamagePercent, long _additionalPhysicalReceiveDamagePercent, long _additionalMagicReceiveDamagePercent, long _additionalPhysicalDamageUpPercent, long _additionalMagicDamageUpPercent, long _additionalTalentBonusPermyriad, float _moveSpeed)
        {
            StartHpWithoutPassive = _hp;
            StartAtk = _atk;
            StartDef = _def;
            StartMagicStr = _magicStr;
            StartMagicDef = _magicDef;
            StartWaveHpRecovery = _waveHpRecovery;
            StartWaveEnergyRecovery = _waveEnergyRecovery;
            StartPhysicalCritical = _physicalCritical;
            StartMagicCritical = _magicCritical;
            StartDodge = _dodge;
            StartAccuracy = _accuracy;
            StartLifeSteal = _lifeSteal;
            StartPhysicalPenetrate = _physicalPenetrate;
            StartMagicPenetrate = _magicPenetrate;
            StartHpRecoveryRate = _hpRecoveryRate;
            StartEnergyRecoveryRate = _energyRecoveryRate;
            StartEnergyReduceRate = _energyReduceRate;
            StartMaxHpForDamagedEnergy = _startMaxHpForDamagedEnergy;
            DefForDamagedEnergy = _defForDamagedEnergy;
            MagicDefForDamagedEnergy = _magicDefForDamagedEnergy;
            StartPhysicalCriticalDamageRate = _physicalCriticalDamageRate;
            StartMagicCriticalDamageRate = _magicCriticalDamageRate;
            StartReceiveCriticalDamageRate = _receiveCriticalDamageRate;
            StartPhysicalAndMagicReceiveDamagePercent = _additionalPhysicalAndMagicReceiveDamagePercent;
            StartPhysicalReceiveDamagePercent = _additionalPhysicalReceiveDamagePercent;
            StartMagicReceiveDamagePercent = _additionalMagicReceiveDamagePercent;
            StartPhysicalDamageUpPercent = _additionalPhysicalDamageUpPercent;
            StartMagicDamageUpPercent = _additionalMagicDamageUpPercent;
            StartTalentFormationBonus = _additionalTalentBonusPermyriad;
            StartMoveSpeed = _moveSpeed;

            Hp = _hp;
            Atk = _atk;
            Def = _def;
            MagicStr = _magicStr;
            MagicDef = _magicDef;
            WaveHpRecovery = _waveHpRecovery;
            WaveEnergyRecovery = _waveEnergyRecovery;
            PhysicalCritical = _physicalCritical;
            MagicCritical = _magicCritical;
            Dodge = _dodge;
            Accuracy = _accuracy;
            LifeSteal = _lifeSteal;
            PhysicalPenetrate = _physicalPenetrate;
            MagicPenetrate = _magicPenetrate;
            HpRecoveryRate = _hpRecoveryRate;
            EnergyRecoveryRate = _energyRecoveryRate;
            EnergyReduceRate = _energyReduceRate;
            PhysicalCriticalDamageRate = _physicalCriticalDamageRate;
            MagicCriticalDamageRate = _magicCriticalDamageRate;
            ReceiveCriticalDamageRate = _receiveCriticalDamageRate;
            AdditionalPhysicalAndMagicReceiveDamagePercent = _additionalPhysicalAndMagicReceiveDamagePercent;
            AdditionalPhysicalReceiveDamagePercent = _additionalPhysicalReceiveDamagePercent;
            AdditionalMagicReceiveDamagePercent = _additionalMagicReceiveDamagePercent;
            AdditionalPhysicalDamageUpPercent = _additionalPhysicalDamageUpPercent;
            AdditionalMagicDamageUpPercent = _additionalMagicDamageUpPercent;
            AdditionalTalentBonusPermyriad = _additionalTalentBonusPermyriad;
            MoveSpeed = _moveSpeed;

            MaxHp = _hp;
            MaxHpAfterPassive = _hp;

            Energy = 0d;
        }
    }
}