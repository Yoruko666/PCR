namespace Elements
{
    public class InventoryInfo
    {
        public int Id { get; set; }
        public eInventoryType Type { get; set; }
        public int Count { get; set; }
        public int Received { get; set; }
        public int Stock { get; set; }
        public UnitData UnitData { get; set; }
        public DuplicateUnitInfo ExchangeData { get; set; }
        public ExtraEquipInfo ExEquip { get; set; }

        public void SetType(eInventoryType _type) => Type = _type;

        public void SetCount(int _count) => Count = _count;

        public void SetReceived(int _received) => Received = _received;

        public void SetStock(int _stock) => Stock = _stock;

        private void initializeInventoryInfo() { }

        public InventoryInfo() { }

        public InventoryInfo(int _id, eInventoryType _type, int _count, int _received, int _stock, UnitData _unitData, DuplicateUnitInfo _exchangeData, ExtraEquipInfo _exEquip) { }

        //public InventoryInfo(JsonData _json) { }

        //public void ParseInventoryInfo(JsonData _json) { }
    }
}