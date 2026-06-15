public class EquipSlot
{
    public int Id { get; set; }
    public bool IsSlot { get; set; }
    public int EnhancementLevel { get; set; }
    public int EnhancementPt { get; set; }
    public int Rank { get; set; }
    public int Status { get; set; }
    public void SetId(int _id) => Id = _id;

    public void SetIsSlot(bool _isSlot) => IsSlot = _isSlot;

    public void SetEnhancementLevel(int _enhancementLevel) => EnhancementLevel = _enhancementLevel;
    public void SetEnhancementPt(int _enhancementPt) => EnhancementPt = _enhancementPt;
    public void SetRank(int _rank) => Rank = _rank;
    public void SetStatus(int _status) => Status = _status;
    private void initializeEquipSlot() { }
    public EquipSlot() { }
//  public EquipSlot(JsonData _json) { }
//  public void ParseEquipSlot(JsonData _json) { }
    public EquipSlot(EquipSlot _equipSlot) { }
}

public class EquipSlotLight
{
    public bool IsSlot { get; set; }
    public int EnhancementPt { get; set; }
    public int Rank { get; set; }
    private void initializeEquipSlotLight() { }
    public EquipSlotLight() { }
//  public EquipSlotLight(JsonData _json) { }
//  public void ParseEquipSlotLight(JsonData _json) { }
}