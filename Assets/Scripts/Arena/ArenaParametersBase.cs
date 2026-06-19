using System.Collections.Generic;

namespace Elements
{
    public class ArenaParametersBase 
    {
	    public int BattleViewerId { get; set; }
        public int TrueRank { get; set; }
        public int OldRecord { get; set; }
        public int NewRecord { get; set; }
        public int SelectedEnemyIndex { get; set; }
        public InventoryInfo HighestRankReward { get; set; }
        public int Seed { get; set; }
        public InventoryInfo RewardInfo { get; set; }
        public int RewardHourNum { get; set; }
        public bool IsTimeRewardMax { get; set; }
        public List<ArenaWaveInfo> WaveInfoList { get; set; }
        public long ArenaApplyLimitTime { get; set; }
        public long ArenaPlayerSelectLimitTime { get; set; }
        public void Initialize() { }

        public void ClearEnemyIndex() { }

        public ArenaParametersBase() { }
    }
}