using System.Collections.Generic;

public class UnitDataForView // TypeDefIndex: 2410
{
    public int Id { get; set; }
    public int UnitLevel { get; set; }
    public int UnitRarity { get; set; }
    public int BattleRarity { get; set; }
    public ePromotionLevel PromotionLevel { get; set; }
    public int Power { get; set; }
    public SkinData SkinData { get; set; }
    public List<EquipSlot> UniqueEquipSlot { get; set; }
    public List<ExtraEquipSlot> ExEquipSlot { get; set; }
    public List<ExtraEquipSlot> CbExEquipSlot { get; set; }

    private void initializeUnitDataForView() { }

    public UnitDataForView() { }

    public UnitDataForView(int _id, int _unitLevel, int _unitRarity, int _battleRarity, ePromotionLevel _promotionLevel, int _power, SkinData _skinData, List<EquipSlot> _uniqueEquipSlot, List<ExtraEquipSlot> _exEquipSlot, List<ExtraEquipSlot> _cbExEquipSlot)
    {
        Id = _id;
        UnitLevel = _unitLevel;
        UnitRarity = _unitRarity;
        BattleRarity = _battleRarity;
        PromotionLevel = _promotionLevel;
        Power = _power;
        SkinData = _skinData;
        UniqueEquipSlot = new(_uniqueEquipSlot);
        ExEquipSlot = new(_exEquipSlot);
        CbExEquipSlot = new(_cbExEquipSlot);
    }

//  public UnitDataForView(JsonData _json) { }

//  public void ParseUnitDataForView(JsonData _json) { }
}