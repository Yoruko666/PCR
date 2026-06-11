using System;

[Serializable]
public class UnitConfig
{
    public string Id;
    public string Name;
    public int MaxHP;
    public int AttackPower;
    public float AttackRange;
    public string AnimRunGameStart;
    public string AnimStandBy;
    public string AnimRun;
    public string AnimAttack;
    public string AnimIdle;
    public string UbSkillId;     // UB技能ID
    public string Skill1Id;      // 技能1ID
    public string Skill2Id;      // 技能2ID
    public float AttackInterval; // 普攻间隔（秒）
    public string StartSequence; // 启动序列，如 "21A12"
    public string LoopSequence;  // 循环序列，如 "A1A2"
}
