using System.Collections.Generic;

namespace Elements
{
    public class RankingSearchOpponent 
    {
        public int ViewerId { get; set; }
        public int Rank { get; set; }
        public string UserName { get; set; }
        public int TeamLevel { get; set; }
        public UnitDataForView FavoriteUnit { get; set; }
        public List<UnitDataForView> ArenaDeck { get; set; }
        public EmblemData Emblem { get; set; }

        private void initializeRankingSearchOpponent() { }

        public RankingSearchOpponent() { }

        //public RankingSearchOpponent(JsonData _json) { }

        //public void ParseRankingSearchOpponent(JsonData _json) { }
    }
}