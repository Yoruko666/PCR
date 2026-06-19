using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Elements
{
    public class ArenaSearchOpponent 
    {
        public int ViewerId { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public int TeamLevel { get; set; }
        public List<UnitParameter> ArenaDeck { get; set; }
        public UnitDataForView FavoriteUnit { get; set; }
        public EmblemData Emblem { get; set; }
         
        public ArenaSearchOpponent() { }

        public ArenaSearchOpponent(SearchOpponent _opponent)
        {
            ViewerId = _opponent.ViewerId;
            Rank = _opponent.Rank;
            Name = _opponent.UserName;
            TeamLevel = _opponent.TeamLevel;
            FavoriteUnit = _opponent.FavoriteUnit;
            Emblem = _opponent.Emblem;
            ArenaDeck = _opponent.ArenaDeck.Select(item => new UnitParameter(item)).ToList();
        }

        public ArenaSearchOpponent(RankingSearchOpponent _opponent)
        {
            ViewerId = _opponent.ViewerId;
            Rank = _opponent.Rank;
            Name = _opponent.UserName;
            TeamLevel = _opponent.TeamLevel;
            FavoriteUnit = _opponent.FavoriteUnit;
            Emblem = _opponent.Emblem;
            ArenaDeck = _opponent.ArenaDeck.Select(item => new UnitParameter(item)).ToList();
        }

        public void UpdateSearchOpponent(SearchOpponent _opponent)
        {
            ViewerId = _opponent.ViewerId;
            Rank = _opponent.Rank;
            Name = _opponent.UserName;
            TeamLevel = _opponent.TeamLevel;
            FavoriteUnit = _opponent.FavoriteUnit;
            Emblem = _opponent.Emblem;
            ArenaDeck = _opponent.ArenaDeck.Select(item => new UnitParameter(item)).ToList();
        }

        public void UpdateSearchOpponent(RankingSearchOpponent _opponent)
        {
            ViewerId = _opponent.ViewerId;
            Rank = _opponent.Rank;
            Name = _opponent.UserName;
            TeamLevel = _opponent.TeamLevel;
            FavoriteUnit = _opponent.FavoriteUnit;
            Emblem = _opponent.Emblem;
            ArenaDeck = _opponent.ArenaDeck.Select(item => new UnitParameter(item)).ToList();
        }

        public void SetRank(int _rank)
        {
            Rank = _rank;
        }
    }
}