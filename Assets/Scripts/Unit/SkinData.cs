public class SkinData
{
	public int IconSkinId { get; set; }
    public int SdSkinId { get; set; }
    public int StillSkinId { get; set; }
    public int MotionId { get; set; }

    public void SetIconSkinId(int _iconSkinId) { }

    public void SetSdSkinId(int _sdSkinId) { }

    public void SetStillSkinId(int _stillSkinId) { }

    public void SetMotionId(int _motionId) { }

    private void initializeSkinData() { }

    public SkinData() { }
    public SkinData(SkinData other)
    {
        IconSkinId = other.IconSkinId;
        SdSkinId = other.SdSkinId;
        StillSkinId = other.StillSkinId;
        MotionId = other.MotionId;
    }

    //  public SkinData(JsonData _json) { }

    //  public void ParseSkinData(JsonData _json) { }
}
