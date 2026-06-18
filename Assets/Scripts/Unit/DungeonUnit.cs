public class DungeonUnit 
{
	public int UnitId { get; set; }
	public long Hp { get; set; }
	public int Energy { get; set; }
	public List<SkillLimitCounter> SkillLimitCounter { get; set; }
	public long MaxHp { get; set; }
	public int Power { get; set; }
	public int Level { get; set; }
	public int Rarity { get; set; }
	public int PromotionLevel { get; set; }
	public SkinData SkinData { get; set; }
	public List<int> UniqueEquippedList { get; set; }
	public List<ExtraEquipSlot> ExEquipSlot { get; set; }
	public List<ExtraEquipSlot> CbExEquipSlot { get; set; }
	public List<PartsInfo> PartsList { get; set; }

	public DungeonUnit() { }

//	public DungeonUnit(JsonData _json) { }

//	public void ParseDungeonUnit(JsonData _json) { }

	private void initializeDungeonUnit() { }

	public void SetUnitId(int _unitId) => UnitId = _unitId;
	public void SetHp(long _hp) => Hp = _hp;
	public void SetEnergy(int _energy) => Energy = _energy;
	public void SetMaxHp(long _maxHp) => MaxHp = _maxHp;
	public void SetExEquipSlot(List<ExtraEquipSlot> _exEquipSlot) => ExEquipSlot = new(_exEquipSlot);
	public void SetCbExEquipSlot(List<ExtraEquipSlot> _cbExEquipSlot) => CbExEquipSlot = new(_cbExEquipSlot);

}