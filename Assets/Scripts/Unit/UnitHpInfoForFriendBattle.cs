
namespace Elements
{
    public class UnitHpInfoForFriendBattle
    {
        public int viewer_id { get; set; }
        public int unit_id { get; set; }
        public long hp { get; set; }
        public int hp_rate { get; set; }
        public void SetViewerId(int _viewerId) => viewer_id = _viewerId;
        public void SetUnitId(int _unitId) => unit_id = _unitId;
        public void SetHp(long _hp) => hp = _hp;
        public void SetHpRate(int _hpRate)  => hp_rate = _hpRate;
        private void initializeUnitHpInfoForFriendBattle() { }
        public UnitHpInfoForFriendBattle() { }
        public UnitHpInfoForFriendBattle(JsonData _json) { }
        public void ParseUnitHpInfoForFriendBattle(JsonData _json) { }
    }
}