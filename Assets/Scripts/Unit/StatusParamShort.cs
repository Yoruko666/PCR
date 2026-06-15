public class StatusParamShort
{
    public long Hp { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Matk { get; set; }
    public int Mdef { get; set; }
    public int Crt { get; set; }
    public int Mcrt { get; set; }
    public int Hrec { get; set; }
    public int Erec { get; set; }
    public int HrecRate { get; set; }
    public int Pnt { get; set; }
    public int Mpnt { get; set; }
    public int LifeSteal { get; set; }
    public int Dodge { get; set; }
    public int ErecRate { get; set; }
    public int EredRate { get; set; }
    public int Accuracy { get; set; }

    public void SetHp(long _hp) => Hp = _hp;
    public void SetAtk(int _atk) => Atk = _atk;
    public void SetDef(int _def) => Def = _def;
    public void SetMatk(int _matk) => Matk = _matk;
    public void SetMdef(int _mdef) => Mdef = _mdef;
    public void SetCrt(int _crt) => Crt = _crt;
    public void SetMcrt(int _mcrt) => Mcrt = _mcrt;
    public void SetHrec(int _hrec) => Hrec = _hrec;
    public void SetErec(int _erec) => Erec = _erec;
    public void SetHrecRate(int _hrecRate) => HrecRate = _hrecRate;
    public void SetPnt(int _pnt) => Pnt = _pnt;
    public void SetMpnt(int _mpnt) => Mpnt = _mpnt;
    public void SetLifeSteal(int _lifeSteal) => LifeSteal = _lifeSteal;
    public void SetDodge(int _dodge) => Dodge = _dodge;
    public void SetErecRate(int _erecRate) => ErecRate = _erecRate;
    public void SetEredRate(int _eredRate) => EredRate = _eredRate;
    public void SetAccuracy(int _accuracy) => Accuracy = _accuracy;

    public StatusParamShort() { }

    public StatusParamShort(StatusParamShort _other)
    {
        Hp = _other.Hp;
        Atk = _other.Atk;
        Def = _other.Def;
        Matk = _other.Matk;
        Mdef = _other.Mdef;
        Crt = _other.Crt;
        Mcrt = _other.Mcrt;
        Hrec = _other.Hrec;
        Erec = _other.Erec;
        HrecRate = _other.HrecRate;
        Pnt = _other.Pnt;
        Mpnt = _other.Mpnt;
        LifeSteal = _other.LifeSteal;
        Dodge = _other.Dodge;
        ErecRate = _other.ErecRate;
        EredRate = _other.EredRate;
        Accuracy = _other.Accuracy;
    }

    //  public StatusParamShort(JsonData _json) { }

    //  public void ParseStatusParamShort(JsonData _json) { }

    public long GetParam(eParamType paramType)
    {
        return paramType switch
        {
            eParamType.Hp => Hp,
            eParamType.Atk => Atk,
            eParamType.Def => Def,
            eParamType.MagicAtk => Matk,
            eParamType.MagicDef => Mdef,
            eParamType.PhysicalCritical => Crt,
            eParamType.MagicCritical => Mcrt,
            eParamType.Dodge => Dodge,
            eParamType.LifeSteal => LifeSteal,
            eParamType.WaveHpRecovery => Hrec,
            eParamType.WaveEnergyRecovery => Erec,
            eParamType.PhysicalPenetrate => Pnt,
            eParamType.MagicPenetrate => Mpnt,
            eParamType.EnergyRecoveryRate => ErecRate,
            eParamType.HpRecoveryRate => HrecRate,
            eParamType.EnergyReduceRate => EredRate,
            eParamType.Accuracy => Accuracy,
            _ => 0,
        };
    }
}