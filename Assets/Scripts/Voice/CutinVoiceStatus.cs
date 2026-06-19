namespace Elements
{
    public struct CutinVoiceStatus 
    {
        public bool IsUseSpecialVoice { get; set; }
        public VoiceGroupIdSet GroupIdSet { get; set; }
        public VoiceTimingSet TimingSet { get; set; }

        public CutinVoiceStatus(bool _IsUseSpecialVoice, VoiceGroupIdSet _GroupIdSet, VoiceTimingSet _TimingSet) 
        {
            IsUseSpecialVoice = _IsUseSpecialVoice;
            GroupIdSet = _GroupIdSet;
            TimingSet = _TimingSet;
        }
    }
}