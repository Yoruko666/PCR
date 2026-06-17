public class UnitParameter 
{
    public UnitData UniqueData { get; set; }
    public UnitDataForView UniqueDataForView { get; set; }
    public UnitData LimitedUnitData { get; set; }
    public bool IsClanSupportOrReplay { get; set; }
    public Elements.Data.MasterUnitData.UnitData MasterData { get; set; }
    public Elements.Data.MasterUnitSkillData.UnitSkillData SkillData { get; set; }
    public int EnemyColor { get; set; }

    public UnitParameter() { }

	public UnitParameter(UnitData _unitData) { }

	public UnitParameter(UnitDataForView _unitData) { }

	public void SetMasterData() { }

	public void SetMasterDataForView() { }

	public void CalcUnitData() { }

	public void UpdateLimitedUnitData(bool _calcLocalPower = true, bool _isSupportOrReplay = false) { }
}