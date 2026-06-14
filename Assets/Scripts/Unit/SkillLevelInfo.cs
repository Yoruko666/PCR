public class SkillLevelInfo 
{
	public int SkillId { get; set; }
	public int SkillLevel { get; set; }
	public int SlotNumber { get; set; }

	public void SetSkillId(int _skillId)
    {
        SkillId = _skillId;
    }

	public void SetSkillLevel(int _skillLevel)
    {
        SkillLevel = _skillLevel;
    }

	public void SetSlotNumber(int _slotNumber)
    {
        SlotNumber = _slotNumber;
    }

	private void initializeSkillLevelInfo() { }

	public SkillLevelInfo() { }

	public SkillLevelInfo(JsonData _json) { }

	public void ParseSkillLevelInfo(JsonData _json) { }
}

public class SkillLevelInfoLight 
{

	public int SkillLevel { get; set; }

	public void SetSkillLevel(int _skillLevel)
    {
        SkillLevel = _skillLevel;
    }

	private void initializeSkillLevelInfoLight() { }

	public void SkillLevelInfoLight() { }

	public void SkillLevelInfoLight(JsonData _json) { }

	public void ParseSkillLevelInfoLight(JsonData _json) { }
}