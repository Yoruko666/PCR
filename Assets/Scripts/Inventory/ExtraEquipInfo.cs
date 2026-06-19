namespace Elements
{
    public class ExtraEquipInfo
    {
        public int SerialId { get; set; }
        public int ExEquipmentId { get; set; }
        public int EnhancementPt { get; set; }
        public int Rank { get; set; }
        public int ProtectionFlag { get; set; }

        public void SetEnhancementPt(int _enhancementPt) => EnhancementPt = _enhancementPt;

        public void SetRank(int _rank) => Rank = _rank;

        public void SetProtectionFlag(int _protectionFlag) => ProtectionFlag = _protectionFlag;

        private void initializeExtraEquipInfo() { }

        public ExtraEquipInfo() { }

        //public ExtraEquipInfo(int _serialId, int _exEquipmentId, int _enhancementPt, int _rank, int _protectionFlag) { }

        //public ExtraEquipInfo(JsonData _json) { }

        //public void ParseExtraEquipInfo(JsonData _json) { }
    }
}