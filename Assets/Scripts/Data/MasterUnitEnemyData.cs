using System.Collections.Generic;
using Sqlite3Plugin;

namespace Elements.Data 
{
    /*
    [CompilerGenerated]
    [Serializable]
    private sealed class Elements.Data.MasterUnitEnemyData.<> c // TypeDefIndex: 17041
    {
        public static readonly Elements.Data.MasterUnitEnemyData.<> c<>9; // 0x0
        public static Func<KeyValuePair<int, Elements.Data.MasterUnitEnemyData.UnitEnemyData>, int> <> 9__14_0; // 0x8

        private static void .cctor() { }
        public void .ctor() { }

        internal int < SortAllRecords > b__14_0(KeyValuePair<int, Elements.Data.MasterUnitEnemyData.UnitEnemyData> __kvp) { }
    }
    */

    // Namespace: 
    public class MasterUnitEnemyData : AbstractMasterData 
    {
        public const string TABLE_NAME = "unit_enemy_data";
        private MasterUnitDatabase _db; // 0x10
        private Dictionary<int, UnitEnemyData> _strictPrimaryKeyDictionary; 
        private Dictionary<int, UnitEnemyData> _lazyPrimaryKeyDictionary;

        public Dictionary<int, UnitEnemyData> dictionary { get; }

        private UnitEnemyData _CreateCachedOrmByQueryResult(Query query) { }

        public MasterUnitEnemyData(MasterUnitDatabase db) { }

        public bool HasKey(int unit_id) { }

        public override void Unload() { }

        public void WholeWarmUp() { }

        private void _StrictLoadAllEntries() { }

        public Dictionary<int, UnitEnemyData> FDIIMFGCAEM() { }

        private UnitEnemyData _SelectOne(int unit_id) { }

        public UnitEnemyData Get(int unit_id)
        {
            if (_lazyPrimaryKeyDictionary.TryGetValue(unit_id, out var result))
                return result;
            using var query = _db.GetSelectQuery_UnitEnemyData();
            query.BindInt(1, unit_id);
            if (query.Step())
            {
                result = _CreateCachedOrmByQueryResult(query);
                _lazyPrimaryKeyDictionary[unit_id] = result;
            }
            return result;
        }
        public class UnitEnemyData
        {
            protected int _unit_id;
            protected string _unit_name;
            protected int _prefab_id;
            protected int _motion_type;
            protected int _se_type;
            protected int _move_speed;
            protected int _search_area_width;
            protected int _atk_type;
            protected double _normal_atk_cast_time;
            protected int _cutin;
            protected int _cutin_star6;
            protected int _visual_change_flag;
            protected string _comment;

            public int unit_id => _unit_id;
            public string unit_name => _unit_name;
            public int prefab_id => _prefab_id;
            public int motion_type => _motion_type;
            public int se_type => _se_type;
            public int move_speed => _move_speed;
            public int search_area_width => _search_area_width;
            public int atk_type => _atk_type;
            public double normal_atk_cast_time => _normal_atk_cast_time;
            public int cutin => _cutin;
            public int cutin_star6 => _cutin_star6;
            public int visual_change_flag => _visual_change_flag;
            public string comment => _comment;

            public UnitEnemyData(int unit_id = 0, string unit_name = "", int prefab_id = 0, int motion_type = 0, int se_type = 0, int move_speed = 0, int search_area_width = 0, int atk_type = 0, double normal_atk_cast_time = 0, int cutin = 0, int cutin_star6 = 0, int visual_change_flag = 0, string comment = "")
            {
                _unit_id = unit_id;
                _unit_name = unit_name;
                _prefab_id = prefab_id;
                _motion_type = motion_type;
                _se_type = se_type;
                _move_speed = move_speed;
                _search_area_width = search_area_width;
                _atk_type = atk_type;
                _normal_atk_cast_time = normal_atk_cast_time;
                _cutin = cutin;
                _cutin_star6 = cutin_star6;
                _visual_change_flag = visual_change_flag;
                _comment = comment;
            }

        }
    }
}