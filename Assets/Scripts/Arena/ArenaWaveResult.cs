namespace Elements
{
    public class ArenaWaveResult 
    {
        public UnitDamageInfo[] unit_damage_list { get; set; }
        public UnitHpInfo[] unit_hp_list { get; set; }
        public int wave_num { get; set; }
        public int remain_time { get; set; }

        public void SetUnitDamageList(UnitDamageInfo[] _unitDamageList) { }

        public void SetUnitHpList(UnitHpInfo[] _unitHpList) { }

        public void SetWaveNum(int _waveNum) { }

        public void SetRemainTime(int _remainTime) { }

        private void initializeArenaWaveResult() { }

        public ArenaWaveResult() { }

        //public ArenaWaveResult(JsonData _json) { }

        //public void ParseArenaWaveResult(JsonData _json) { }
    }
}