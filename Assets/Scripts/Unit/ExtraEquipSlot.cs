public class ExtraEquipSlot 
{
	public int SerialId { get; set; }
    public int ExEquipmentId { get; set; }
    public int EnhancementPt { get; set; }

    private void initializeExtraEquipSlot() { }

    public ExtraEquipSlot() { }

    public ExtraEquipSlot(int _serialId, int _exEquipmentId, int _enhancementPt) { }

//  public ExtraEquipSlot(JsonData _json) { }

//  public void ParseExtraEquipSlot(JsonData _json) { }

    public ExtraEquipSlot(ExtraEquipSlot _original) { }

//  public ExtraEquipSlot(MyPartyExtraEquipSlot _original) { }

//  public bool IsEquip() { }
}
