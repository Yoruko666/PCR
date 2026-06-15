using System;
using System.Collections.Generic;

public class UnitData
{
    public int Id { get; set; }
    public DateTime GetTime { get; set; }
    public int StartRarety { get; set; }
    public int UnitRarity { get; set; }
    public int BattleRarity { get; set; }
    public int UnitLevel { get; set; }
    public int UnitExp { get; set; }
    public ePromotionLevel PromotionLevel { get; set; }
    public List<SkillLevelInfo> UnionBurst { get; set; }
    public List<SkillLevelInfo> MainSkill { get; set; }
    public List<SkillLevelInfo> ExSkill { get; set; }
    public List<SkillLevelInfo> FreeSkill { get; set; }
    public List<EquipSlot> EquipSlot { get; set; }
    public List<EquipSlot> UniqueEquipSlot { get; set; }
    public int ExceedStage { get; set; }
    public UnitParam UnitParam { get; set; }
    public StatusParamShort BonusParam { get; set; }
    public int ResistStatusId { get; set; }
    public int ResistVariationId { get; set; }
    public int Power { get; set; }
    public SkinData SkinData { get; set; }
    public int IdentifyNum { get; set; }
    public int FavoriteFlag { get; set; }
    public UnlockRarity6Slot UnlockRarity6Item { get; set; }
    public List<ExtraEquipSlot> ExEquipSlot { get; set; }
    public List<ExtraEquipSlot> CbExEquipSlot { get; set; }
//  private MasterDataManager masterDataMgr { get; }
//  private UserData userData { get; }
    public long TotalHpWithoutExtra { get; }
    public long TotalHp { get; }
    public int TotalAtkWithoutExtra { get; }
    public int TotalAtk { get; }
    public int TotalDefWithoutExtra { get; }
    public int TotalDef { get; }
    public int TotalMagicAtkWithoutExtra { get; }
    public int TotalMagicAtk { get; }
    public int TotalMagicDefWithoutExtra { get; }
    public int TotalMagicDef { get; }
    public int TotalCriticalWithoutExtra { get; }
    public int TotalCritical { get; }
    public int TotalMagicCriticalWithoutExtra { get; }
    public int TotalMagicCritical { get; }
    public int TotalWaveHpRecovery { get; }
    public int TotalWaveEnergyRecovery { get; }
    public int TotalHpRecoveryRate { get; }
    public int TotalPhysicalPenetrate { get; }
    public int TotalMagicPenetrate { get; }
    public int TotalLifeSteal { get; }
    public int TotalDodge { get; }
    public int TotalAccuracy { get; }
    public int TotalEnergyRecoveryRate { get; }
    public int TotalEnergyReduceRate { get; }
    public EquipSlot UniqueEquipSlot1 { get; }
    public EquipSlot UniqueEquipSlot2 { get; }

    public void SetId(int _id) => Id = _id;

    public void SetUnitRarity(int _unitRarity) => UnitRarity = _unitRarity;

    public void SetBattleRarity(int _battleRarity) => BattleRarity = _battleRarity;

    public void SetUnitLevel(int _unitLevel) => UnitLevel = _unitLevel;

    public void SetUnitExp(int _unitExp) => UnitExp = _unitExp;

    public void SetPromotionLevel(ePromotionLevel _promotionLevel) => PromotionLevel = _promotionLevel;

    public void SetUnionBurst(List<SkillLevelInfo> _unionBurst) => UnionBurst = new(_unionBurst);

    public void SetMainSkill(List<SkillLevelInfo> _mainSkill) => MainSkill = new(_mainSkill);

    public void SetExSkill(List<SkillLevelInfo> _exSkill) => ExSkill = new(_exSkill);

    public void SetFreeSkill(List<SkillLevelInfo> _freeSkill) => FreeSkill = new(_freeSkill);

    public void SetEquipSlot(List<EquipSlot> _equipSlot) => EquipSlot = new(_equipSlot);

    public void SetUniqueEquipSlot(List<EquipSlot> _uniqueEquipSlot) => UniqueEquipSlot = new(_uniqueEquipSlot);

    public void SetExceedStage(int _exceedStage) => ExceedStage = _exceedStage;

    public void SetUnitParam(UnitParam _unitParam) => UnitParam = new(_unitParam);

    public void SetBonusParam(StatusParamShort _bonusParam) => BonusParam = new(BonusParam);

    public void SetResistStatusId(int _resistStatusId) => ResistStatusId = _resistStatusId;

    public void SetResistVariationId(int _resistVariationId) => ResistVariationId = _resistVariationId;

    public void SetPower(int _power) => Power = _power;

    public void SetSkinData(SkinData _skinData) => SkinData = _skinData;

    public void SetIdentifyNum(int _identifyNum) => IdentifyNum = _identifyNum;

    public void SetFavoriteFlag(int _favoriteFlag) => FavoriteFlag = _favoriteFlag;

    public void SetUnlockRarity6Item(UnlockRarity6Slot _unlockRarity6Item) => UnlockRarity6Item = new(_unlockRarity6Item);

    public void SetExEquipSlot(List<ExtraEquipSlot> _exEquipSlot) => ExEquipSlot = new(_exEquipSlot);

    public void SetCbExEquipSlot(List<ExtraEquipSlot> _cbExEquipSlot) => CbExEquipSlot = new(_cbExEquipSlot);

    private void initializeUnitData() { }

    public UnitData() { }

    public UnitData(int _id, DateTime _getTime, int _startRarety, int _unitRarity, int _battleRarity, int _unitLevel, int _unitExp, ePromotionLevel _promotionLevel, List<SkillLevelInfo> _unionBurst, List<SkillLevelInfo> _mainSkill, List<SkillLevelInfo> _exSkill, List<SkillLevelInfo> _freeSkill, List<EquipSlot> _equipSlot, List<EquipSlot> _uniqueEquipSlot, int _exceedStage, UnitParam _unitParam, StatusParamShort _bonusParam, int _resistStatusId, int _resistVariationId, int _power, SkinData _skinData, int _identifyNum, int _favoriteFlag, UnlockRarity6Slot _unlockRarity6Item, List<ExtraEquipSlot> _exEquipSlot, List<ExtraEquipSlot> _cbExEquipSlot)
    {
        Id = _id;
        GetTime = _getTime;
        StartRarety = _startRarety;
        UnitRarity = _unitRarity;
        BattleRarity = _battleRarity;
        UnitLevel = _unitLevel;
        UnitExp = _unitExp;
        PromotionLevel = _promotionLevel;
        UnionBurst = new(_unionBurst);
        MainSkill = new(_mainSkill);
        ExSkill = new(_exSkill);
        FreeSkill = new(_freeSkill);
        EquipSlot = new(_equipSlot);
        ExceedStage = _exceedStage;
        UnitParam = new(_unitParam);
        BonusParam = new(_bonusParam);
        ResistStatusId = _resistStatusId;
        ResistVariationId = _resistVariationId;
        Power = _power;
        SkinData = new(_skinData);
        IdentifyNum = _identifyNum;
        FavoriteFlag = _favoriteFlag;
        UnlockRarity6Item = new(_unlockRarity6Item);
        ExEquipSlot = new(_exEquipSlot);
        CbExEquipSlot = new(_cbExEquipSlot);
    }

//  public UnitData(JsonData _json) { }

//  public void ParseUnitData(JsonData _json) { }

    private void parseHookUnitData() { }

//  private MasterDataManager GetMasterDataMgr() { }

//  private UserData GetUserData() { }

//  public long GetTotalParamWithoutExtra(eParamType _paramType) { }

//  public long GetTotalParam(eParamType _paramType) { }
//  public UnitDataForView CreateUnitDataForView() { }

//  public UnitData CreateCopyData() { }

//  public UnitData CraeteCopyDataDeep() { }

//  public UnitData CreateRarityUpUnitDataForView(int _nextRarity, int _battleRarity = 0, bool _removeExEquip = false) { }

//  public UnitData CreateUniqueEquipmentUnitData(List<EquipSlot> _outerParam) { }

//  public UnitData CreateHighRarityEquipUnitDataForView(UnlockRarity6Slot _outerParam) { }

    public void UpdateSkinData(SkinData _skindata) { }

    public int GetCurrentRarity() => UnitRarity;

    public void UpdateUnlockRarityLevel(int _index, int _level) { }

//  public int GetUnlockRarityLevel(int _index) { }

    public void UpdateUnlockRarityStatus(int _index, int _status) { }

    public void EquipEnhancedEquipment() { }

//  private EquipSlot createNotEquipSlotData(int _equipId) { }

//  public UnitData(UnitDataLight _unitDataLight, bool _isDownwardRevision = false, bool _isClanBattleSupport = false) { }

    private void setSkillLevelInfo(List<SkillLevelInfo> _outSkillLevelInfo, List<SkillLevelInfoLight> _skillInfoLights, List<int> _skillIds, int _limitLevel = 2147483647) { }

//  public UnitData(ODLNBOGAMKM.LAFHHOOHBKD _enemyParameter) { }

//  private List<SkillLevelInfo> createSkillLevelInfo(int[] _args) { }

//  public List<int> CreateSkillIdList() { }

//  public EquipSlot GetUniqueEquipSlot(int _slotIndex) { }

//  public EquipSlot GetUniqueEquipSlot1() { }

//  public EquipSlot GetUniqueEquipSlot2() { }

//  public int IncreaseLevelCap() { }

//  public int CalcAddRateParam(eParamType _type, long _status) { }

//  public int CalcAddRateDisplayParam(eParamType _type, long _status, int _slot) { }

//  public int GetAddParam(eParamType _type) { }

//  public ExtraEquipPair GetSerialEquipData(int _slot) { }

//  private int getEquipmentParam(int _slot, eParamType _type) { }

//  internal static List<SkillLevelInfo> CreateSkillInstance(List<SkillLevelInfo> _originalData) { }

//  internal static List<ExtraEquipSlot> CreateExtraEquipSlotInstance(List<ExtraEquipSlot> _originalData) { }
}

namespace Elements
{
    public class UnitData
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int MotionType { get; set; }
        public int PrefabIdBattle { get; set; }
        public UnitData(string[] _csvParam) { }
    }
}