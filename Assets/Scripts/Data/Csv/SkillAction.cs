using System;

/*
 * ActionType
 *  1：伤害
 *  3：造成位移
 *  4：回复HP
 *  6：护盾
 *  8：加速/减速/无法移动
 *  10：施加Buff
 *  12：施加黑暗状态
 *  16：回复TP
 *  21：无敌
 *  48：持续回复HP
 *  59：重伤
 *  90：被动技能提升
 *  102：每次攻击伤害增加
 */

[Serializable]
public class SkillAction
{
    public int action_id;           // 事件id
    public string description;      // 事件描述
    public int class_id;     
    public int action_type;         // 技能类型
    public int action_detail_1;
    public int action_detail_2;
    public int action_detail_3;
    public float action_value_1;
    public float action_value_2;
    public float action_value_3;
    public float action_value_4;
    public float action_value_5;
    public float action_value_6;
    public float action_value_7;
    public int target_assignment;   
    public int target_count;
    public int target_range;
    public int target_area;
    public int target_type;
    public int target_number;
    public string level_up_disp;
}
