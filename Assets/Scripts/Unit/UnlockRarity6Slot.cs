public class UnlockRarity6Slot 
{
	public int QuestClear { get; set; }
    public int Slot1 { get; set; }
    public int Slot2 { get; set; }
    public int Slot3 { get; set; }
    public int Status1 { get; set; }
    public int Status2 { get; set; }
    public int Status3 { get; set; }
    public void SetQuestClear(int _questClear) => QuestClear = _questClear;

    public void SetSlot1(int _slot1) => Slot1 = _slot1;

    public void SetSlot2(int _slot2) => Slot2 = _slot2;

    public void SetSlot3(int _slot3) => Slot3 = _slot3;

    public void SetStatus1(int _status1) => Status1 = _status1;

    public void SetStatus2(int _status2) => Status2 = _status2;

    public void SetStatus3(int _status3) => Status3 = _status3;

    private void initializeUnlockRarity6Slot() { }

    public UnlockRarity6Slot() { }
    public UnlockRarity6Slot(UnlockRarity6Slot other)
    {
        QuestClear = other.QuestClear;
        Slot1 = other.Slot1;
        Slot2 = other.Slot2;
        Slot3 = other.Slot3;
        Status1 = other.Status1;
        Status2 = other.Status2;
        Status3 = other.Status3;
    }

    //  public UnlockRarity6Slot(JsonData _json) { }

    //  public void ParseUnlockRarity6Slot(JsonData _json) { }

    public void SetSlot(int _slot, int _value)
    {
        switch (_slot)
        {
            case 1: Slot1 = _value; break;
            case 2: Slot2 = _value; break;
            case 3: Slot3 = _value; break;
        }
    }

    public int GetSlot(int _slot)
    {
        switch (_slot)
        {
            case 1: return Slot1;
            case 2: return Slot2;
            case 3: return Slot3;
        }
        return -1;
    }
}
