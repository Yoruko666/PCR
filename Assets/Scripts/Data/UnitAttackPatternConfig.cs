using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 对应 unit_attack_pattern.csv 的角色攻击循环配置。
/// CSV 列名与字段名一一对应，由 CsvReader 反射填充。
/// 
/// atk_pattern_1 ~ 20 存储攻击序列中的每一步使用的技能标识：
///   - 1  = 普通攻击
///   - 1001 = 技能槽1 (main_skill_1)
///   - 1002 = 技能槽2 (main_skill_2)
///   - 其他值类似，可结合 unit_skill_data 解析为完整 skill_id
/// 
/// loop_start / loop_end 表示循环段的范围（1-based 索引）。
/// </summary>
public class UnitAttackPatternConfig
{
    public int pattern_id;
    public int unit_id;

    // 20 个攻击模式槽位
    public int atk_pattern_1;
    public int atk_pattern_2;
    public int atk_pattern_3;
    public int atk_pattern_4;
    public int atk_pattern_5;
    public int atk_pattern_6;
    public int atk_pattern_7;
    public int atk_pattern_8;
    public int atk_pattern_9;
    public int atk_pattern_10;
    public int atk_pattern_11;
    public int atk_pattern_12;
    public int atk_pattern_13;
    public int atk_pattern_14;
    public int atk_pattern_15;
    public int atk_pattern_16;
    public int atk_pattern_17;
    public int atk_pattern_18;
    public int atk_pattern_19;
    public int atk_pattern_20;

    public int loop_start;
    public int loop_end;

    /// <summary>按 1-based 索引顺序获取所有非 0 的模式值（仅返回 atk_pattern_1~20）。</summary>
    public List<int> GetAllPatternSteps()
    {
        var list = new List<int>();
        var fields = new[] {
            atk_pattern_1,  atk_pattern_2,  atk_pattern_3,  atk_pattern_4,  atk_pattern_5,
            atk_pattern_6,  atk_pattern_7,  atk_pattern_8,  atk_pattern_9,  atk_pattern_10,
            atk_pattern_11, atk_pattern_12, atk_pattern_13, atk_pattern_14, atk_pattern_15,
            atk_pattern_16, atk_pattern_17, atk_pattern_18, atk_pattern_19, atk_pattern_20,
        };
        // 只取非 0 的有效步骤
        list.AddRange(fields.Where(f => f != 0));
        return list;
    }

    /// <summary>获取起始序列（索引 0 ~ loop_start-2）。</summary>
    public List<int> GetStartSequence()
    {
        var all = GetOrderedPatternSteps();
        int startIdx = loop_start - 1; // 转 0-based
        return all.Take(startIdx).ToList();
    }

    /// <summary>获取循环序列（索引 loop_start-1 ~ loop_end-1）。</summary>
    public List<int> GetLoopSequence()
    {
        var all = GetOrderedPatternSteps();
        int startIdx = loop_start - 1;
        int endIdx = loop_end - 1;
        if (startIdx < 0) startIdx = 0;
        if (endIdx >= all.Count) endIdx = all.Count - 1;
        if (startIdx > endIdx) return new List<int>();
        return all.GetRange(startIdx, endIdx - startIdx + 1);
    }

    /// <summary>按 1~20 槽位顺序返回完整列表（包含 0 值），用于精确的索引访问。</summary>
    private List<int> GetOrderedPatternSteps()
    {
        return new List<int>
        {
            atk_pattern_1,  atk_pattern_2,  atk_pattern_3,  atk_pattern_4,  atk_pattern_5,
            atk_pattern_6,  atk_pattern_7,  atk_pattern_8,  atk_pattern_9,  atk_pattern_10,
            atk_pattern_11, atk_pattern_12, atk_pattern_13, atk_pattern_14, atk_pattern_15,
            atk_pattern_16, atk_pattern_17, atk_pattern_18, atk_pattern_19, atk_pattern_20,
        };
    }
}
