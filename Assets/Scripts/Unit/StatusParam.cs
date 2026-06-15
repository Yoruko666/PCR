public class StatusParam
{
    public long Hp { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int MagicStr { get; set; }
    public int MagicDef { get; set; }
    public int PhysicalCritical { get; set; }
    public int MagicCritical { get; set; }
    public int WaveHpRecovery { get; set; }
    public int WaveEnergyRecovery { get; set; }
    public int HpRecoveryRate { get; set; }
    public int PhysicalPenetrate { get; set; }
    public int MagicPenetrate { get; set; }
    public int LifeSteal { get; set; }
    public int Dodge { get; set; }
    public int EnergyReduceRate { get; set; }
    public int EnergyRecoveryRate { get; set; }
    public int Accuracy { get; set; }
    public void SetHp(long _hp) => Hp = _hp;
    public void SetAtk(int _atk) => Atk = _atk;
    public void SetDef(int _def) => Def = _def;
    public void SetMagicStr(int _magicStr) => MagicStr = _magicStr;
    public void SetMagicDef(int _magicDef) => MagicDef = _magicDef;
    public void SetPhysicalCritical(int _physicalCritical) => PhysicalCritical = _physicalCritical;
    public void SetMagicCritical(int _magicCritical) => MagicCritical = _magicCritical;
    public void SetWaveHpRecovery(int _waveHpRecovery) => WaveHpRecovery = _waveHpRecovery;
    public void SetWaveEnergyRecovery(int _waveEnergyRecovery) => WaveEnergyRecovery = _waveEnergyRecovery;
    public void SetHpRecoveryRate(int _hpRecoveryRate) => HpRecoveryRate = _hpRecoveryRate;
    public void SetPhysicalPenetrate(int _physicalPenetrate) => PhysicalPenetrate = _physicalPenetrate;
    public void SetMagicPenetrate(int _magicPenetrate) => MagicPenetrate = _magicPenetrate;
    public void SetLifeSteal(int _lifeSteal) => LifeSteal = _lifeSteal;
    public void SetDodge(int _dodge) => Dodge = _dodge;
    public void SetEnergyReduceRate(int _energyReduceRate) => EnergyReduceRate = _energyReduceRate;
    public void SetEnergyRecoveryRate(int _energyRecoveryRate) => EnergyRecoveryRate = _energyRecoveryRate;
    public void SetAccuracy(int _accuracy) => Accuracy = _accuracy;

    private void initializeStatusParam() { }

    public StatusParam() { }
    public StatusParam(StatusParam _other)
    {
        Hp = _other.Hp;
        Atk = _other.Atk;
        Def = _other.Def;
        MagicStr = _other.MagicStr;
        MagicDef = _other.MagicDef;
        PhysicalCritical = _other.PhysicalCritical;
        MagicCritical = _other.MagicCritical;
        WaveHpRecovery = _other.WaveHpRecovery;
        WaveEnergyRecovery = _other.WaveEnergyRecovery;
        HpRecoveryRate = _other.HpRecoveryRate;
        PhysicalPenetrate = _other.PhysicalPenetrate;
        MagicPenetrate = _other.MagicPenetrate;
        LifeSteal = _other.LifeSteal;
        Dodge = _other.Dodge;
        EnergyReduceRate = _other.EnergyReduceRate;
        EnergyRecoveryRate = _other.EnergyRecoveryRate;
        Accuracy = _other.Accuracy;
    }

//  public StatusParam(JsonData _json) { }

//  public void ParseStatusParam(JsonData _json) { }

    public long GetParam(eParamType _paramType)
    {
        return _paramType switch
        {
            eParamType.Hp => Hp,
            eParamType.Atk => Atk,
            eParamType.Def => Def,
            eParamType.MagicAtk => MagicStr,
            eParamType.MagicDef => MagicDef,
            eParamType.PhysicalCritical => PhysicalCritical,
            eParamType.MagicCritical => MagicCritical,
            eParamType.Dodge => Dodge,
            eParamType.LifeSteal => LifeSteal,
            eParamType.WaveHpRecovery => WaveHpRecovery,
            eParamType.WaveEnergyRecovery => WaveEnergyRecovery,
            eParamType.PhysicalPenetrate => PhysicalPenetrate,
            eParamType.MagicPenetrate => MagicPenetrate,
            eParamType.EnergyRecoveryRate => EnergyRecoveryRate,
            eParamType.HpRecoveryRate => HpRecoveryRate,
            eParamType.EnergyReduceRate => EnergyReduceRate,
            eParamType.Accuracy => Accuracy,
            _ => 0,
        };
    }
}