namespace Elements
{
    public class ContinuousUnit 
    {
        public readonly int UnitId; 
        public readonly int IdentifyNum; 
        public readonly long Hp; 
        public readonly int Energy; 
        public readonly List<SkillLimitCounter> SkillLimitCounter; 

        public ContinuousUnit(int _unitId, int _unitIndex, long _hp, int _energy, List<SkillLimitCounter> _skillLimitCounter) { }

        public ContinuousUnit(DungeonUnit _dungeonUnit) { }

//      public ContinuousUnit(TowerUnit _towerUnit) { }

//      public ContinuousUnit(SreEnemyUnit _sreEnemyUnit) { }

//      public ContinuousUnit(AcnEnemyUnit _enemyUnit) { }
    }
}