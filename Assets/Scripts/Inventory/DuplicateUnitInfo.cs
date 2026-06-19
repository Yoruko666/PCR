namespace Elements
{
    public class DuplicateUnitInfo
    {
        public int UnitId { get; set; }
        public int Rarity { get; set; }
        public int Count { get; set; }

        private void initializeDuplicateUnitInfo() { }

        public DuplicateUnitInfo() { }

        public DuplicateUnitInfo(int _unitId, int _rarity, int _count)
        {
            UnitId = _unitId;
            Rarity = _rarity;
            Count = _count;
        }

        //public DuplicateUnitInfo(JsonData _json) { }

        //public void ParseDuplicateUnitInfo(JsonData _json) { }
    }
}