using System;

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
