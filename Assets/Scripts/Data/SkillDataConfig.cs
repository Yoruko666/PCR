using System.Collections.Generic;

public class SkillDataConfig
{
    public int skill_id;
    public string name;
    public int skill_type;
    public float skill_cast_time;
    public string description;
    public int icon_type;
    public float skill_area_width;
    public float boss_ub_cool_time;

    public int action_1;
    public int action_2;
    public int action_3;
    public int action_4;
    public int action_5;
    public int action_6;
    public int action_7;
    public int action_8;
    public int action_9;
    public int action_10;

    public int depend_action_1;
    public int depend_action_2;
    public int depend_action_3;
    public int depend_action_4;
    public int depend_action_5;
    public int depend_action_6;
    public int depend_action_7;
    public int depend_action_8;
    public int depend_action_9;
    public int depend_action_10;

    public List<int> GetActionIds()
    {
        var ids = new List<int>();
        if (action_1 != 0) ids.Add(action_1);
        if (action_2 != 0) ids.Add(action_2);
        if (action_3 != 0) ids.Add(action_3);
        if (action_4 != 0) ids.Add(action_4);
        if (action_5 != 0) ids.Add(action_5);
        if (action_6 != 0) ids.Add(action_6);
        if (action_7 != 0) ids.Add(action_7);
        if (action_8 != 0) ids.Add(action_8);
        if (action_9 != 0) ids.Add(action_9);
        if (action_10 != 0) ids.Add(action_10);
        return ids;
    }
}
