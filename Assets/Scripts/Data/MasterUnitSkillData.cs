using System.Collections.Generic;
using Sqlite3Plugin;

namespace Elements.Data 
{
    public class MasterUnitSkillData : AbstractMasterData 
    {
        public const string TABLE_NAME = "unit_skill_data";
        private MasterUnitDatabase _db; 
        private Dictionary<int, UnitSkillData> _lazyPrimaryKeyDictionary; 

        public UnitSkillData this[int unit_id] => Get(unit_id);

        public UnitSkillData Get(int unit_id)
        {
            if (_lazyPrimaryKeyDictionary.TryGetValue(unit_id, out var result))
                return result;

            using var query = _db.GetSelectQuery_UnitSkillData();
            query.BindInt(1, unit_id);
            if (query.Step())
            {
                result = _CreateCachedOrmByQueryResult(query);
                _lazyPrimaryKeyDictionary[unit_id] = result;
            }
            return result;
        }

        public MasterUnitSkillData(MasterUnitDatabase db) : base(db)
        {
            _db = db;
            _lazyPrimaryKeyDictionary = new Dictionary<int, UnitSkillData>();
        }

        public override void Unload()
        {
            _lazyPrimaryKeyDictionary.Clear();
        }

        public bool HasKey(int unit_id)
        {
            return _lazyPrimaryKeyDictionary.ContainsKey(unit_id);
        }
        
        private UnitSkillData _CreateCachedOrmByQueryResult(Query query)
        {
            var skillData = new UnitSkillData(
                unit_id: query.GetInt(0),
                union_burst: query.GetInt(1),
                main_skill_1: query.GetInt(2),
                main_skill_2: query.GetInt(3),
                main_skill_3: query.GetInt(4),
                main_skill_4: query.GetInt(5),
                main_skill_5: query.GetInt(6),
                main_skill_6: query.GetInt(7),
                main_skill_7: query.GetInt(8),
                main_skill_8: query.GetInt(9),
                main_skill_9: query.GetInt(10),
                main_skill_10: query.GetInt(11),
                ex_skill_1: query.GetInt(12),
                ex_skill_evolution_1: query.GetInt(13),
                ex_skill_2: query.GetInt(14),
                ex_skill_evolution_2: query.GetInt(15),
                ex_skill_3: query.GetInt(16),
                ex_skill_evolution_3: query.GetInt(17),
                ex_skill_4: query.GetInt(18),
                ex_skill_evolution_4: query.GetInt(19),
                ex_skill_5: query.GetInt(20),
                ex_skill_evolution_5: query.GetInt(21),
                sp_union_burst: query.GetInt(22),
                sp_skill_1: query.GetInt(23),
                sp_skill_2: query.GetInt(24),
                sp_skill_3: query.GetInt(25),
                sp_skill_4: query.GetInt(26),
                sp_skill_5: query.GetInt(27),
                union_burst_evolution: query.GetInt(28),
                main_skill_evolution_1: query.GetInt(29),
                main_skill_evolution_2: query.GetInt(30),
                sp_skill_evolution_1: query.GetInt(31),
                sp_skill_evolution_2: query.GetInt(32)
            );
            skillData.SetUp();
            return skillData;
        }

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
            public int unit_id => _unit_id;
            public int union_burst => _union_burst;
            public int main_skill_1 => _main_skill_1;
            public int main_skill_2 => _main_skill_2;
            public int main_skill_3 => _main_skill_3;
            public int main_skill_4 => _main_skill_4;
            public int main_skill_5 => _main_skill_5;
            public int main_skill_6 => _main_skill_6;
            public int main_skill_7 => _main_skill_7;
            public int main_skill_8 => _main_skill_8;
            public int main_skill_9 => _main_skill_9;
            public int main_skill_10 => _main_skill_10;
            public int ex_skill_1 => _ex_skill_1;
            public int ex_skill_evolution_1 => _ex_skill_evolution_1;
            public int ex_skill_2 => _ex_skill_2;
            public int ex_skill_evolution_2 => _ex_skill_evolution_2;
            public int ex_skill_3 => _ex_skill_3;
            public int ex_skill_evolution_3 => _ex_skill_evolution_3;
            public int ex_skill_4 => _ex_skill_4;
            public int ex_skill_evolution_4 => _ex_skill_evolution_4;
            public int ex_skill_5 => _ex_skill_5;
            public int ex_skill_evolution_5 => _ex_skill_evolution_5;
            public int sp_union_burst => _sp_union_burst;
            public int sp_skill_1 => _sp_skill_1;
            public int sp_skill_2 => _sp_skill_2;
            public int sp_skill_3 => _sp_skill_3;
            public int sp_skill_4 => _sp_skill_4;
            public int sp_skill_5 => _sp_skill_5;
            public int union_burst_evolution => _union_burst_evolution;
            public int main_skill_evolution_1 => _main_skill_evolution_1;
            public int main_skill_evolution_2 => _main_skill_evolution_2;
            public int sp_skill_evolution_1 => _sp_skill_evolution_1;
            public int sp_skill_evolution_2 => _sp_skill_evolution_2;

            public UnitSkillData(int unit_id = 0, int union_burst = 0, int main_skill_1 = 0, int main_skill_2 = 0, int main_skill_3 = 0, int main_skill_4 = 0, int main_skill_5 = 0, int main_skill_6 = 0, int main_skill_7 = 0, int main_skill_8 = 0, int main_skill_9 = 0, int main_skill_10 = 0, int ex_skill_1 = 0, int ex_skill_evolution_1 = 0, int ex_skill_2 = 0, int ex_skill_evolution_2 = 0, int ex_skill_3 = 0, int ex_skill_evolution_3 = 0, int ex_skill_4 = 0, int ex_skill_evolution_4 = 0, int ex_skill_5 = 0, int ex_skill_evolution_5 = 0, int sp_union_burst = 0, int sp_skill_1 = 0, int sp_skill_2 = 0, int sp_skill_3 = 0, int sp_skill_4 = 0, int sp_skill_5 = 0, int union_burst_evolution = 0, int main_skill_evolution_1 = 0, int main_skill_evolution_2 = 0, int sp_skill_evolution_1 = 0, int sp_skill_evolution_2 = 0)
            {
                _unit_id = unit_id;
                _union_burst = union_burst;
                _main_skill_1 = main_skill_1;
                _main_skill_2 = main_skill_2;
                _main_skill_3 = main_skill_3;
                _main_skill_4 = main_skill_4;
                _main_skill_5 = main_skill_5;
                _main_skill_6 = main_skill_6;
                _main_skill_7 = main_skill_7;
                _main_skill_8 = main_skill_8;
                _main_skill_9 = main_skill_9;
                _main_skill_10 = main_skill_10;
                _ex_skill_1 = ex_skill_1;
                _ex_skill_evolution_1 = ex_skill_evolution_1;
                _ex_skill_2 = ex_skill_2;
                _ex_skill_evolution_2 = ex_skill_evolution_2;
                _ex_skill_3 = ex_skill_3;
                _ex_skill_evolution_3 = ex_skill_evolution_3;
                _ex_skill_4 = ex_skill_4;
                _ex_skill_evolution_4 = ex_skill_evolution_4;
                _ex_skill_5 = ex_skill_5;
                _ex_skill_evolution_5 = ex_skill_evolution_5;
                _sp_union_burst = sp_union_burst;
                _sp_skill_1 = sp_skill_1;
                _sp_skill_2 = sp_skill_2;
                _sp_skill_3 = sp_skill_3;
                _sp_skill_4 = sp_skill_4;
                _sp_skill_5 = sp_skill_5;
                _union_burst_evolution = union_burst_evolution;
                _main_skill_evolution_1 = main_skill_evolution_1;
                _main_skill_evolution_2 = main_skill_evolution_2;
                _sp_skill_evolution_1 = sp_skill_evolution_1;
                _sp_skill_evolution_2 = sp_skill_evolution_2;
            }
            
            private static List<int> NonZero(params int[] values)
            {
                var list = new List<int>(values.Length);
                foreach (var v in values)
                {
                    if (v != 0) list.Add(v);
                }
                return list;
            }

            public void SetUp()
            {
                UnionBurstIds = NonZero(_union_burst);
                SubUnionBurstIds = NonZero(_sp_union_burst);
                MainSkillIds = NonZero(_main_skill_1, _main_skill_2, _main_skill_3, _main_skill_4, _main_skill_5, _main_skill_6, _main_skill_7, _main_skill_8, _main_skill_9, _main_skill_10);
                ExSkillIds = NonZero(_ex_skill_1, _ex_skill_2, _ex_skill_3, _ex_skill_4, _ex_skill_5);
                ExSkillEvolutionIds = NonZero(_ex_skill_evolution_1, _ex_skill_evolution_2, _ex_skill_evolution_3, _ex_skill_evolution_4, _ex_skill_evolution_5);
                SpSkillIds = NonZero(_sp_skill_1, _sp_skill_2, _sp_skill_3, _sp_skill_4, _sp_skill_5);
                UnionBurstEvolutionIds = NonZero(_union_burst_evolution);
                MainSkillEvolutionIds = NonZero(_main_skill_evolution_1, _main_skill_evolution_2);
                SpSkillEvolutionIds = NonZero(_sp_skill_evolution_1, _sp_skill_evolution_2);
            }
        }
    }
}