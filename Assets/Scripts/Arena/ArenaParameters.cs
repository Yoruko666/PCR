using System.Collections.Generic;

namespace Elements
{
    public class ArenaParameters : ArenaParametersBase 
    {
        public ArenaInfo ArenaInfo; 
        public List<ArenaSearchOpponent> SearchOpponent;// 对战对手
        public List<ArenaSearchOpponent> RankingList;   // 竞技场排行榜
        public int RankAtInfo; 

        public ArenaParameters() { }

        public void RankingClear() { }

        public ArenaSearchOpponent GetSelectedSearchOpponent() { }

        public void UpdateOpponentRank() { }

        public bool CanSkipBattle()
        {
            return RankAtInfo > 50;
        }
    }
}