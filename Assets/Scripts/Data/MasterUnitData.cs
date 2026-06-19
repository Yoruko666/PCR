using System.Collections.Generic;
using Sqlite3Plugin;

namespace Elements.Data
{
    /*
    // Namespace: 
    [CompilerGenerated]
    [Serializable]
    private sealed class Elements.Data.MasterUnitData.<> c 
    {
        public static readonly Elements.Data.MasterUnitData.<> c<>9;
        public static Func<KeyValuePair<int, Elements.Data.MasterUnitData.UnitData>, int> <> 9__25_0; 

        internal int < SortAllRecords > b__25_0(KeyValuePair<int, Elements.Data.MasterUnitData.UnitData> __kvp) { }
    }
    */

    public class MasterUnitData : AbstractMasterData 
    {
        public const string TABLE_NAME = "unit_data";
        private Elements.Data.MasterUnitDatabase _db; 
        private Dictionary<int, UnitData> _strictPrimaryKeyDictionary; 
        private Dictionary<int, UnitData> _lazyPrimaryKeyDictionary; 
        private Dictionary<int, List<UnitData>> _dictionaryOfListWithOriginalUnitId; 

        public UnitData Item { get; }
        public int Count { get; }
        public Dictionary<int, UnitData> dictionary { get; }
        public bool HasKey(int UnitId) { }

        public void Add(UnitData unitData) { }

        public MasterUnitData(MasterUnitDatabase db) : base(db) { }

        private UnitData _SelectOne(int UnitId) { }

        private void _StrictLoadAllEntries() { }

        public UnitData Get(int UnitId)
        {
            if (_lazyPrimaryKeyDictionary.TryGetValue(UnitId, out var result))
                return result;
            using var query = _db.GetSelectQuery_UnitData();
            query.BindInt(1, UnitId);
            if (query.Step())
            {
                result = _CreateCachedOrmByQueryResult(query);
                _lazyPrimaryKeyDictionary[UnitId] = result;
            }
            return result;
        }

        private List<UnitData> _ListSelectWithOriginalUnitId(int OriginalUnitId) { }

        private UnitData _CreateCachedOrmByQueryResult(Query query) { }

        public static Dictionary<UnitData> op_Implicit(Elements.Data.MasterUnitData data) { }

        public List<UnitData> GetListWithOriginalUnitId(int OriginalUnitId) { }
        public override void Unload() { }

        public bool ContainsKey(int id) { }

        public List<UnitData> MaybeListWithOriginalUnitId(int OriginalUnitId) { }

        public IEnumerable<KeyValuePair<int, UnitData>> SortAllRecords() { }

        public class UnitData
        {

            protected int _UnitId;
            protected string _UnitName;
            protected string _Kana;
            protected int _PrefabId;
            protected int _prefab_id_battle;
            protected int _IsLimited;
            protected int _Rarity;
            protected int _MotionType;
            protected int _SeType;
            protected int _MoveSpeed;
            protected int _SearchAreaWidth;
            protected int _AtkType;
            protected double _AtkCastTime;
            protected int _CutIn1;
            protected int _CutIn2;
            protected int _cutin1_star6;
            protected int _cutin2_star6;
            protected int _GuildId;
            protected int _ExskillDisplay;
            protected string _Comment;
            protected int _OnlyDispOwned;
            protected string _StartTime;
            protected string _EndTime;
            protected int _OriginalUnitId;

            public int VisualChangeFlag { get; set; }
            public int UnitId => _UnitId;
            public string UnitName => _UnitName;
            public string Kana => _Kana;
            public int PrefabId => _PrefabId;
            public int prefab_id_battle => _prefab_id_battle;
            public int IsLimited => _IsLimited;
            public int Rarity => _Rarity;
            public int MotionType => _MotionType;
            public int SeType => _SeType;
            public int MoveSpeed => _MoveSpeed;
            public int SearchAreaWidth => _SearchAreaWidth;
            public int AtkType => _AtkType;
            public double AtkCastTime => _AtkCastTime;
            public int CutIn1 => _CutIn1;
            public int CutIn2 => _CutIn2;
            public int cutin1_star6 => _cutin1_star6;
            public int cutin2_star6 => _cutin2_star6;
            public int GuildId => _GuildId;
            public int ExskillDisplay => _ExskillDisplay;
            public string Comment => _Comment;
            public int OnlyDispOwned => _OnlyDispOwned;
            public string StartTime => _StartTime;
            public string EndTime => _EndTime;
            public int OriginalUnitId => _OriginalUnitId;

            public string UnitNameOnly() => UnitName;

            public UnitData(Elements.Data.MasterUnitEnemyData.UnitEnemyData unitEnemyData) { }

            public UnitData(int UnitId = 0, string UnitName = "", string Kana = "", int PrefabId = 0, int prefab_id_battle = 0, int IsLimited = 0, int Rarity = 0, int MotionType = 0, int SeType = 0, int MoveSpeed = 0, int SearchAreaWidth = 0, int AtkType = 0, double AtkCastTime = 0, int CutIn1 = 0, int CutIn2 = 0, int cutin1_star6 = 0, int cutin2_star6 = 0, int GuildId = 0, int ExskillDisplay = 0, string Comment = "", int OnlyDispOwned = 0, string StartTime = "", string EndTime = "", int OriginalUnitId = 0)
            {
                _UnitId = UnitId;
                _UnitName = UnitName;
                _Kana = Kana;
                _PrefabId = PrefabId;
                _prefab_id_battle = prefab_id_battle;
                _IsLimited = IsLimited;
                _Rarity = Rarity;
                _MotionType = MotionType;
                _SeType = SeType;
                _MoveSpeed = MoveSpeed;
                _SearchAreaWidth = SearchAreaWidth;
                _AtkType = AtkType;
                _AtkCastTime = AtkCastTime;
                _CutIn1 = CutIn1;
                _CutIn2 = CutIn2;
                _cutin1_star6 = cutin1_star6;
                _cutin2_star6 = cutin2_star6;
                _GuildId = GuildId;
                _ExskillDisplay = ExskillDisplay;
                _Comment = Comment;
                _OnlyDispOwned = OnlyDispOwned;
                _StartTime = StartTime;
                _EndTime = EndTime;
                _OriginalUnitId = OriginalUnitId;
            }
        }
    }
}