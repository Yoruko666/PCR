namespace Elements
{
    public struct VoiceGroupIdSet 
    {
	    public int GroupId { get; set; }
        public int GroupUnitId { get; set; }
        public int UnitId { get; set; }

        public VoiceGroupIdSet(int _groupId, int _groupUnitId, int _unitId) 
        {
            GroupId = _groupId;
            GroupUnitId = _groupUnitId;
            UnitId = _unitId;
        }
    }
}