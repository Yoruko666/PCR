
namespace Elements
{
    public class UnitHpInfo 
    {
	    public int viewer_id { get; set; }
        public int unit_id { get; set; }
        public long hp { get; set; }
        public void SetViewerId(int _viewerId) => viewer_id = _viewerId;
        public void SetUnitId(int _unitId) => unit_id = _unitId;
        public void SetHp(long _hp) => hp = _hp;
        private void initializeUnitHpInfo() { }
        public UnitHpInfo() { }
        public UnitHpInfo(JsonData _json) { }
        public void ParseUnitHpInfo(JsonData _json) { }
    }
}