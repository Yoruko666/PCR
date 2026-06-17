using System;
using System.Collections.Generic;

namespace Elements
{
    [Serializable]
    public class SubUbVoiceTimingSet
    {
        public List<VoiceDelayAndEnable> Voice1List;
        public List<VoiceDelayAndEnable> Voice2List;
    }
}