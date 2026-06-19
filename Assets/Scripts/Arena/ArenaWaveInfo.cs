using System.Collections.Generic;

namespace Elements
{
    public class ArenaWaveInfo
    {
        public List<UnitData> UserArenaDeck { get; set; }
        public List<UnitData> VsUserArenaDeck { get; set; }
        public int Seed { get; set; }
        public int BattleLogId { get; set; }
        public int WaveNum { get; set; }
        private void initializeArenaWaveInfo() { }

        public ArenaWaveInfo() { }

        //public ArenaWaveInfo(JsonData _json) { }

        //public void ParseArenaWaveInfo(JsonData _json) { }
    }
}