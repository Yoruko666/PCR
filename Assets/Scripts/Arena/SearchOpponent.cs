
// Namespace: Elements
using System.Collections.Generic;

namespace Elements
{
    public class SearchOpponent
    {
        public int ViewerId { get; set; }
        public int Rank { get; set; }
        public string UserName { get; set; }
        public int TeamLevel { get; set; }
        public UnitDataForView FavoriteUnit { get; set; }
        public List<UnitData> ArenaDeck { get; set; }
        public EmblemData Emblem { get; set; }

        private void initializeSearchOpponent() { }

        public SearchOpponent() { }

        //  public SearchOpponent(JsonData _json) { }

        //  public void ParseSearchOpponent(JsonData _json) { }
    }
}