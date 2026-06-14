using System.Collections.Generic;
using System.Reflection;

namespace Elements 
{
    [DefaultMember("Item")]
    public class UnitSkillReserve 
    {
        private Dictionary<int, bool> skillReserves; 
        public bool IsReserve { get; }
        public bool Item { get; set; }
        public UnitSkillReserve(Dictionary<int, bool> _copyData)
        {
            skillReserves = new(_copyData);
        }
        public Dictionary<int, bool> GetSkillReserveData()
        {
            return skillReserves;
        }
        public void Reset()
        {
            skillReserves.Clear();
        }
    }
}