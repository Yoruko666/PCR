using System;

[Serializable]
public class SkillConfig
{
    public string Id;           // 技能ID
    public string Name;         // 技能名称
    public float CastTime;      // 技能前摇（秒）
    public string AnimName;     // 技能动画名
    public string SoundName;    // 技能音效名
}
