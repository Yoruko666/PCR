using System;


[Serializable]
public class UnitData
{
    public int unit_id;                 // 角色id
    public string unit_name;            // 中文名
    public string kana;                 // 日文名
    public int prefab_id;               // 立绘 Prefab id
    public int prefab_id_battle;        // 战斗 Prefab id
    public int move_speed;              // 移动速度
    public AtkType atk_type;            // 攻击属性 物理/魔法
    public int search_area_width;       // 攻击距离
    public float normal_atk_cast_time;  // 普攻间隔时间
    public int rarity;                  // 初始星级
    public int guild_id;                // 公会id
    public int motion_type;
    public string start_time;           // 上线时间
    public string end_time;             // 下线时间
    public int cutin_1;         
    public int cutin_2;
    public int cutin1_star6;
    public int cutin2_star6;
    public int original_unit_id;
    public bool exskill_display;
    public int se_type;                 // 武器类型
    public bool unknown_1;              // 是否为未知人物
    public string comment;              // 简介
    public bool is_limited;             // 是否限定
    public int only_disp_owned;
}

public enum AtkType
{
    Physical = 1,   // 物理
    Magical = 2     // 魔法
}