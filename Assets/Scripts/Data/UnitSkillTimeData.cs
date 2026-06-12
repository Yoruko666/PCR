using System.Collections.Generic;

[System.Serializable]
public class UnitSkillTimeData
{
    public int unitId;                  //id
    public float spineTime_Attack;      //普攻动画时间
    public float spineTime_UB;          //ub动画时间
    public float spineTime_MainSkill1;  //技能1动画时间
    public float spineTime_MainSkill2;  //技能2动画时间
    public Dictionary<string, float> all_spineTime_Dic = new Dictionary<string, float>();
//这个字典里包含了角色战斗小人的大部分战斗动画及其持续时间
//-1表示没有这个动画
//比如布丁的无敌技能动画有两个技能动画片段，一个变生一个保持无敌
    public bool useDefaultDelay;        //是否使用默认延时
    public Dictionary<int, Dictionary<int,bool>> skillExecDependParentaction;   //这个鸽了
    public Dictionary<int, Dictionary<int, bool>> skillExecDependEffect;        //是否由特效判定
    public Dictionary<int, float[]> actionExecTime_Attack;      //普攻时间
    public Dictionary<int, float[]> actionExecTime_UB;          //ub触发时间
    public Dictionary<int, float[]> actionExecTime_MainSkill1;  //1技能触发时间
    public Dictionary<int, float[]> actionExecTime_MainSkill2;  //2技能触发时间
    public Dictionary<int, List<EffectData>> actionEffectDic;   //技能片段的特效列表
}
[System.Serializable]
public class EffectData
{
    public float[] execTime;    //特效执行延时
    public float moveRate;      //特效的移动速度
    public float hitDelay;      //特效击中延时
    public int moveType;        //移动方式,直线为0，抛物线为2和3，竖直方向为4，1不清楚是啥移动方式
}