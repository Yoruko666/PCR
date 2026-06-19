namespace Elements 
{
    public class ArenaInfo 
    {
        public float MaxBattleNumber { get; set; }
        public int BattleNumber { get; set; }
        public long IntervalEndTime { get; set; }
        public int YesterdayDefendNumber { get; set; }
        public int HighestRank { get; set; }
        public int SeasonHighestRank { get; set; }
        public int Rank { get; set; }
        public int Group { get; set; }
        public int GroupMovingReleaseTime { get; set; }
        public int AlreadySuspend { get; set; }
        public void SetMaxBattleNumber(float _maxBattleNumber) => MaxBattleNumber = _maxBattleNumber;

        public void SetBattleNumber(int _battleNumber) => BattleNumber = _battleNumber;

        private void initializeArenaInfo() { }

        public ArenaInfo() { }

        //public ArenaInfo(JsonData _json) { }

        //public void ParseArenaInfo(JsonData _json) { }
    }
}