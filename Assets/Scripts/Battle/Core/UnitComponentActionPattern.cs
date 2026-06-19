using System.Collections;
using System.Collections.Generic;

namespace Elements.Battle.Core
{
    public class UnitComponentActionPattern : UnitComponentBase, IUnitComponent 
    {
        private int unitId { get; set; }
        public int ActionPatternIndex { get; set; }
        public bool ActionPatternIsLoop { get; set; }
        public int CurrentActionPatternId { get; set; }
        public Dictionary<int, List<int>> ActionPatternDictionary { get; set; }
        public Dictionary<int, List<int>> ActionPatternLoopDictionary { get; set; }
        private Dictionary<int, int> skillLevelDictionary { get; set; }
        private Elements.Battle.Core.UnitComponentAbnormal componentAbnormal { get; set; }

        public UnitComponentActionPattern(UnitCtrl _unitController, int _unitId, Dictionary<int, int> _skillLevelDictionary): base(_unitController)
        {
            unitId = _unitId;
            skillLevelDictionary = new(_skillLevelDictionary);
        }

        public void Setup(Elements.Data.MasterUnitSkillData.UnitSkillData _skillData) { }

        private IEnumerator updateChangeActionPattern(int oldIndex, float limitTime)
        {
            float time = 0;
        }

        public void CreateAttackPattern(Elements.Data.MasterUnitSkillData.UnitSkillData _skillData, int _attackPatternId) 
        {

        }
        
        public void ChangeAttackPattern(int _attackPatternId, int _spSkillLevel, float _limitTime = -1) { }

        public void Reset() { }

        public bool HasLoopPattern() { }

        public int MoveToNext() { }

        public void RegisterComponentSet(Elements.Battle.Core.IUnitComponentContainer _container) { }

        public int GetFirstActionSkillId() { }

        public int GetSkillId() { }
    }
}