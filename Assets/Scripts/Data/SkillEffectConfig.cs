using System;

[Serializable]
public class SkillEffectConfig
{
    public string SkillId;          // 所属技能ID
    public int EffectIndex;         // 效果序号（按顺序执行）
    public string EffectType;       // 效果类型: Damage / Heal / Buff / Debuff
    public string EffectTarget;     // 目标: SingleEnemy / AllEnemies / Self / AllAllies
    public float SkillMulti;        // 攻击力倍率（如 3.0 = 300% 攻击力）
    public int EffectValue;         // 固定附加值（治疗/伤害固定值）
}
