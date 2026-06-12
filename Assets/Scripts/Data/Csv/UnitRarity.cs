using System;

[Serializable]
public class UnitRarity
{
    public int unit_id;                         // 角色id
    public int rarity;                          // 星级
    public float hp;                            // 生命值
    public float hp_growth;                     // 生命值成长
    public float atk;                           // 物理攻击力
    public float atk_growth;                    // 物理攻击力成长
    public float magic_str;                     // 魔法攻击力
    public float magic_str_growth;              // 魔法攻击力成长
    public float def;                           // 物理防御力
    public float def_growth;                    // 物理防御力成长
    public float magic_def;                     // 魔法防御力
    public float magic_def_growth;              // 魔法防御力成长
    public float physical_critical;             // 物理暴击
    public float physical_critical_growth;      // 物理暴击成长
    public float magic_critical;                // 魔法暴击
    public float magic_critical_growth;         // 魔法暴击成长
    public float wave_hp_recovery;              // 波次生命回复
    public float wave_hp_recovery_growth;       // 波次生命回复成长
    public float wave_energy_recovery;          // 波次技能值回复
    public float wave_energy_recovery_growth;   // 波次技能值回复成长
    public float dodge;                         // 闪避
    public float dodge_growth;                  // 闪避成长
    public float physical_penetrate;            // 物理穿透
    public float physical_penetrate_growth;     // 物理穿透成长
    public float magic_penetrate;               // 魔法穿透
    public float magic_penetrate_growth;        // 魔法穿透成长
    public float life_steal;                    // 生命偷取
    public float life_steal_growth;             // 生命偷取成长
    public float hp_recovery_rate;              // 生命回复量上升
    public float hp_recovery_rate_growth;       // 生命回复量上升成长
    public float energy_recovery_rate;          // 技能值上升量
    public float energy_recovery_rate_growth;   // 技能值上升量成长
    public float energy_reduce_rate;            // 技能值降低
    public float energy_reduce_rate_growth;     // 技能值降低成长
    public int unit_material_id;                // 升星材料id
    public int consume_num;                     // 升星消耗个数
    public int consume_gold;                    // 升星消耗金币
    public float accuracy;                      // 命中
    public float accuracy_growth;               // 命中成长
}
