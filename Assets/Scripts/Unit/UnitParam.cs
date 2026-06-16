public class UnitParam
{
    public StatusParam BaseParam { get; set; }
    public StatusParam EquipParam { get; set; }
    
    public void SetBaseParam(StatusParam _baseParam)
    {
        BaseParam = new(_baseParam);
    }

    public void SetEquipParam(StatusParam _equipParam)
    {
        _equipParam = new(_equipParam);
    }

    private void initializeUnitParam() { }

    public UnitParam() { }

    public UnitParam(UnitParam _unitParam)
    {
        BaseParam = new(_unitParam.BaseParam);
        EquipParam = new(_unitParam.EquipParam);
    }

    //  public UnitParam(JsonData _json) { }

    //  public void ParseUnitParam(JsonData _json) { }
}