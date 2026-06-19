namespace Elements
{
    public class UnitDamageInfo 
    {
        public int viewer_id { get; set; }
        public int unit_id { get; set; }
        public long damage { get; set; }
        public int rarity { get; set; }
        public SkinData skin_data { get; set; }

        public void SetViewerId(int _viewerId) => viewer_id = _viewerId;

        public void SetUnitId(int _unitId) => unit_id = _unitId;

        public void SetDamage(long _damage) => damage = _damage;

        public void SetRarity(int _rarity) => rarity = _rarity;

        public void SetSkinData(SkinData _skinData) => skin_data = _skinData;

        private void initializeUnitDamageInfo() { }

        public UnitDamageInfo() { }

        //public UnitDamageInfo(JsonData _json) { }

        //public void ParseUnitDamageInfo(JsonData _json) { }
    }
}