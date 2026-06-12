using System.Collections.Generic;

public class Skill
{
    public SkillConfig Config { get; set; }
    public List<SkillEffectConfig> Effects { get; set; }
    public bool IsNormal => string.IsNullOrEmpty(Config?.Id);
}
