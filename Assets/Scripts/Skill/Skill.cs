using System.Collections.Generic;

public class Skill
{
    public SkillData Data { get; set; }
    public List<SkillAction> Actions { get; set; }
    public bool IsNormal => Data == null;
}
