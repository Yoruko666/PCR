using System;

[Serializable]
public class VoiceTimingGroup
{
    public int VoiceGroupId;
    public VoiceTimingSet ConstantVelocity;
    public VoiceTimingSet DoubleSpeed; 

    public VoiceTimingGroup(int _VoiceGroupId, VoiceTimingSet _ConstantVelocity, VoiceTimingSet _DoubleSpeed) { }
}