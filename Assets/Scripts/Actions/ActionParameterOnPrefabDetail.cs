using System;
using System.Collections.Generic;

[Serializable]
public class ActionParameterOnPrefabDetail // TypeDefIndex: 1296
{
    public bool Visible;
    public List<ActionExecTime> ExecTimeForPrefab;
//  public List<ActionExecTimeCombo> ExecTimeCombo;
    public int ActionId;
    public List<NormalSkillEffect> ActionEffectList;
    public List<NormalSkillEffect> ActionSubEffectList;
    public List<ActionExecTime> ExecTime { get; set; }
}