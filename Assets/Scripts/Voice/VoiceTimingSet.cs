using System;
using System.Collections.Generic;

namespace Elements
{
    [Serializable]
    public class VoiceTimingSet 
    {
        public bool UseBranch; 
        public List<VoiceDelayAndEnable> CutinList; 
        public List<VoiceDelayAndEnable> Voice1List;
        public List<VoiceDelayAndEnable> Voice2List; 
        public List<VoiceDelayAndEnable> Voice3List; 
        public List<VoiceDelayAndEnable> Voice4List; 
        public List<VoiceDelayAndEnable> CutinStar6List;
        public List<VoiceDelayAndEnable> Voice1Star6List; 
        public List<VoiceDelayAndEnable> Voice2Star6List; 
        public List<VoiceDelayAndEnable> Voice3Star6List;
        public List<VoiceDelayAndEnable> Voice4Star6List; 
        public VoiceDelayAndEnable Cutin; 
        public VoiceDelayAndEnable Voice1; 
        public VoiceDelayAndEnable Voice2;
        public VoiceDelayAndEnable Voice3; 
        public VoiceDelayAndEnable Voice4; 
        public VoiceDelayAndEnable CutinStar6; 
        public VoiceDelayAndEnable Voice1Star6; 
        public VoiceDelayAndEnable Voice2Star6;
        public VoiceDelayAndEnable Voice3Star6; 
        public VoiceDelayAndEnable Voice4Star6; 
        public VoiceTimingSet(VoiceDelayAndEnable _Cutin, VoiceDelayAndEnable _Voice1, VoiceDelayAndEnable _Voice2, VoiceDelayAndEnable _Voice3, VoiceDelayAndEnable _Voice4) 
        {
            Cutin = _Cutin;
            Voice1 = _Voice1;
            Voice2 = _Voice2;
            Voice3 = _Voice3;
            Voice4 = _Voice4;
        }
    }
}