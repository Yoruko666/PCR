using System.Collections.Generic;
using System.Reflection;

namespace Elements.Data {
    [DefaultMember("Item")]
    public class MasterUnitSkillData : Elements.Data.AbstractMasterData 
    {
        public const string TABLE_NAME = "v1_2c188ee176622831a318e1e94ec804cd8278c06e7b884c6d1babc7e9a34c0f3a";
        private Elements.Data.MasterUnitDatabase _db; 
        private Dictionary<int, UnitSkillData> _lazyPrimaryKeyDictionary; 

        public UnitSkillData Item { get; }
        public UnitSkillData Get(int unit_id) { }
        public override void Unload() { }
        public bool HasKey(int unit_id) { }
        public MasterUnitSkillData(Elements.Data.MasterUnitDatabase db) { }
        private UnitSkillData _CreateCachedOrmByQueryResult(Query query) { }

        public class UnitSkillData
        {
            protected int _unit_id;
            protected int _union_burst;
            protected int _main_skill_1;
            protected int _main_skill_2;
            protected int _main_skill_3;
            protected int _main_skill_4;
            protected int _main_skill_5;
            protected int _main_skill_6;
            protected int _main_skill_7;
            protected int _main_skill_8;
            protected int _main_skill_9;
            protected int _main_skill_10;
            protected int _ex_skill_1;
            protected int _ex_skill_evolution_1;
            protected int _ex_skill_2;
            protected int _ex_skill_evolution_2;
            protected int _ex_skill_3;
            protected int _ex_skill_evolution_3;
            protected int _ex_skill_4;
            protected int _ex_skill_evolution_4;
            protected int _ex_skill_5;
            protected int _ex_skill_evolution_5;
            protected int _sp_union_burst;
            protected int _sp_skill_1;
            protected int _sp_skill_2;
            protected int _sp_skill_3;
            protected int _sp_skill_4;
            protected int _sp_skill_5;
            protected int _union_burst_evolution;
            protected int _main_skill_evolution_1;
            protected int _main_skill_evolution_2;
            protected int _sp_skill_evolution_1;
            protected int _sp_skill_evolution_2;

            public List<int> UnionBurstIds { get; set; }
            public List<int> ExSkillIds { get; set; }
            public List<int> ExSkillEvolutionIds { get; set; }
            public List<int> MainSkillIds { get; set; }
            public List<int> SpSkillIds { get; set; }
            public List<int> SpSkillEvolutionIds { get; set; }
            public List<int> UnionBurstEvolutionIds { get; set; }
            public List<int> MainSkillEvolutionIds { get; set; }
            public List<int> SubUnionBurstIds { get; set; }
            public int unit_id { get; }
            public int union_burst { get; }
            public int main_skill_1 { get; }
            public int main_skill_2 { get; }
            public int main_skill_3 { get; }
            public int main_skill_4 { get; }
            public int main_skill_5 { get; }
            public int main_skill_6 { get; }
            public int main_skill_7 { get; }
            public int main_skill_8 { get; }
            public int main_skill_9 { get; }
            public int main_skill_10 { get; }
            public int ex_skill_1 { get; }
            public int ex_skill_evolution_1 { get; }
            public int ex_skill_2 { get; }
            public int ex_skill_evolution_2 { get; }
            public int ex_skill_3 { get; }
            public int ex_skill_evolution_3 { get; }
            public int ex_skill_4 { get; }
            public int ex_skill_evolution_4 { get; }
            public int ex_skill_5 { get; }
            public int ex_skill_evolution_5 { get; }
            public int sp_union_burst { get; }
            public int sp_skill_1 { get; }
            public int sp_skill_2 { get; }
            public int sp_skill_3 { get; }
            public int sp_skill_4 { get; }
            public int sp_skill_5 { get; }
            public int union_burst_evolution { get; }
            public int main_skill_evolution_1 { get; }
            public int main_skill_evolution_2 { get; }
            public int sp_skill_evolution_1 { get; }
            public int sp_skill_evolution_2 { get; }

            public UnitSkillData(int unit_id = 0, int union_burst = 0, int main_skill_1 = 0, int main_skill_2 = 0, int main_skill_3 = 0, int main_skill_4 = 0, int main_skill_5 = 0, int main_skill_6 = 0, int main_skill_7 = 0, int main_skill_8 = 0, int main_skill_9 = 0, int main_skill_10 = 0, int ex_skill_1 = 0, int ex_skill_evolution_1 = 0, int ex_skill_2 = 0, int ex_skill_evolution_2 = 0, int ex_skill_3 = 0, int ex_skill_evolution_3 = 0, int ex_skill_4 = 0, int ex_skill_evolution_4 = 0, int ex_skill_5 = 0, int ex_skill_evolution_5 = 0, int sp_union_burst = 0, int sp_skill_1 = 0, int sp_skill_2 = 0, int sp_skill_3 = 0, int sp_skill_4 = 0, int sp_skill_5 = 0, int union_burst_evolution = 0, int main_skill_evolution_1 = 0, int main_skill_evolution_2 = 0, int sp_skill_evolution_1 = 0, int sp_skill_evolution_2 = 0)
            {

            }
            public void SetUp() { }
        }
    }
}