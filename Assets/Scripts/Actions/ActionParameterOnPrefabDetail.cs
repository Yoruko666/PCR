using System;
using System.Collections.Generic;

namespace Elements
{
    [Serializable]
    public class ActionParameterOnPrefabDetail
    {
        public bool Visible;
        public List<ActionExecTime> ExecTimeForPrefab;
        public List<ActionExecTimeCombo> ExecTimeCombo;
        public int ActionId;
        public List<NormalSkillEffect> ActionEffectList;
        public List<NormalSkillEffect> ActionSubEffectList;
        public List<ActionExecTime> ExecTime { get; set; }
    }
}