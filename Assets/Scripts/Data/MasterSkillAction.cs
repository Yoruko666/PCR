using System.Collections.Generic;
using System.Linq;
using Sqlite3Plugin;

namespace Elements.Data
{
    public class MasterSkillAction : AbstractMasterData
    {
        public const string TABLE_NAME = "skill_action";
        private MasterSkillDatabase _db;
        private Dictionary<int, SkillAction> _strictPrimaryKeyDictionary;
        private Dictionary<int, SkillAction> _lazyPrimaryKeyDictionary;
        public SkillAction this[int action_id] => Get(action_id);
        public Dictionary<int, SkillAction> dictionary { get; private set; }

        public bool HasKey(int action_id)
        {
            return _lazyPrimaryKeyDictionary.ContainsKey(action_id);
        }

        public static Dictionary<int, SkillAction> op_Implicit(MasterSkillAction data)
        {
            return data.dictionary;
        }

        public SkillAction Get(int action_id)
        {
            if (_lazyPrimaryKeyDictionary.TryGetValue(action_id, out var result))
                return result;

            using var query = _db.GetSelectQuery_SkillAction();
            query.BindInt(1, action_id);
            if (query.Step())
            {
                result = _CreateCachedOrmByQueryResult(query);
                _lazyPrimaryKeyDictionary[action_id] = result;
            }
            return result;
        }

        public MasterSkillAction(MasterSkillDatabase db) : base(db)
        {
            _db = db;
            _lazyPrimaryKeyDictionary = new Dictionary<int, SkillAction>();
            _strictPrimaryKeyDictionary = new Dictionary<int, SkillAction>();
        }

        private SkillAction _CreateCachedOrmByQueryResult(Query query)
        {
            return new SkillAction(
                action_id: query.GetInt(0),
                class_id: query.GetInt(1),
                action_type: (ushort)query.GetInt(2),
                action_detail_1: query.GetInt(3),
                action_detail_2: query.GetInt(4),
                action_detail_3: query.GetInt(5),
                action_value_1: query.GetDouble(6),
                action_value_2: query.GetDouble(7),
                action_value_3: query.GetDouble(8),
                action_value_4: query.GetDouble(9),
                action_value_5: query.GetDouble(10),
                action_value_6: query.GetDouble(11),
                action_value_7: query.GetDouble(12),
                target_assignment: query.GetInt(13),
                target_area: query.GetInt(14),
                target_range: query.GetInt(15),
                target_type: query.GetInt(16),
                target_number: query.GetInt(17),
                target_count: query.GetInt(18),
                description: query.GetText(19),
                level_up_disp: query.GetText(20)
            );
        }

        public override void Unload()
        {
            _lazyPrimaryKeyDictionary.Clear();
            _strictPrimaryKeyDictionary.Clear();
        }

        private void _StrictLoadAllEntries()
        {
            using var query = _db.GetSelectAllQuery_SkillAction();
            while (query.Step())
            {
                var action = _CreateCachedOrmByQueryResult(query);
                _strictPrimaryKeyDictionary[action.action_id] = action;
            }
            dictionary = _strictPrimaryKeyDictionary;
        }

        public IEnumerable<KeyValuePair<int, SkillAction>> SortAllRecords()
        {
            _StrictLoadAllEntries();
            return _strictPrimaryKeyDictionary.OrderBy(kvp => kvp.Key);
        }

        private SkillAction _SelectOne(int action_id)
        {
            _StrictLoadAllEntries();
            _strictPrimaryKeyDictionary.TryGetValue(action_id, out var result);
            return result;
        }

        public class SkillAction
        {
            protected int _action_id;
            protected int _class_id;
            protected ushort _action_type;
            protected int _action_detail_1;
            protected int _action_detail_2;
            protected int _action_detail_3;
            protected double _action_value_1;
            protected double _action_value_2;
            protected double _action_value_3;
            protected double _action_value_4;
            protected double _action_value_5;
            protected double _action_value_6;
            protected double _action_value_7;
            protected int _target_assignment;
            protected int _target_area;
            protected int _target_range;
            protected int _target_type;
            protected int _target_number;
            protected int _target_count;
            protected string _description;
            protected string _level_up_disp;

            public int DependActionId { get; set; }
            public int action_id => _action_id;
            public int class_id => _class_id;
            public ushort action_type => _action_type;
            public int action_detail_1 => _action_detail_1;
            public int action_detail_2 => _action_detail_2;
            public int action_detail_3 => _action_detail_3;
            public double action_value_1 => _action_value_1;
            public double action_value_2 => _action_value_2;
            public double action_value_3 => _action_value_3;
            public double action_value_4 => _action_value_4;
            public double action_value_5 => _action_value_5;
            public double action_value_6 => _action_value_6;
            public double action_value_7 => _action_value_7;
            public int target_assignment => _target_assignment;
            public int target_area => _target_area;
            public int target_range => _target_range;
            public int target_type => _target_type;
            public int target_number => _target_number;
            public int target_count => _target_count;
            public string description => _description;
            public string level_up_disp => _level_up_disp;

            public SkillAction(int action_id = 0, int class_id = 0, ushort action_type = 0, int action_detail_1 = 0, int action_detail_2 = 0, int action_detail_3 = 0, double action_value_1 = 0, double action_value_2 = 0, double action_value_3 = 0, double action_value_4 = 0, double action_value_5 = 0, double action_value_6 = 0, double action_value_7 = 0, int target_assignment = 0, int target_area = 0, int target_range = 0, int target_type = 0, int target_number = 0, int target_count = 0, string description = "", string level_up_disp = "")
            {
                _action_id = action_id;
                _class_id = class_id;
                _action_type = action_type;
                _action_detail_1 = action_detail_1;
                _action_detail_2 = action_detail_2;
                _action_detail_3 = action_detail_3;
                _action_value_1 = action_value_1;
                _action_value_2 = action_value_2;
                _action_value_3 = action_value_3;
                _action_value_4 = action_value_4;
                _action_value_5 = action_value_5;
                _action_value_6 = action_value_6;
                _action_value_7 = action_value_7;
                _target_assignment = target_assignment;
                _target_area = target_area;
                _target_range = target_range;
                _target_type = target_type;
                _target_number = target_number;
                _target_count = target_count;
                _description = description;
                _level_up_disp = level_up_disp;
            }
        }
    }
}