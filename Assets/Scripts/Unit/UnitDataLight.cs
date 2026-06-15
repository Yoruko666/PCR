using System;
using System.Collections.Generic;

public class UnitDataLight
{
    public int Id { get; set; }
    public DateTime GetTime { get; set; }
    public int StartRarety { get; set; }
    public int UnitRarity { get; set; }
    public int BattleRarity { get; set; }
    public int UnitLevel { get; set; }
    public int UnitExp { get; set; }
    public ePromotionLevel PromotionLevel { get; set; }
    public List<SkillLevelInfoLight> UnionBurst { get; set; }
    public List<SkillLevelInfoLight> MainSkill { get; set; }
    public List<SkillLevelInfoLight> ExSkill { get; set; }
    public List<EquipSlotLight> EquipSlot { get; set; }
    public List<EquipSlotLight> UniqueEquipSlot { get; set; }
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

    public void SetId(int _id) => Id = _id;
    public void SetUnitRarity(int _unitRarity) => UnitRarity = _unitRarity;
    public void SetBattleRarity(int _battleRarity) => BattleRarity = _battleRarity;
    public void SetUnitLevel(int _unitLevel) => UnitLevel = _unitLevel;
    public void SetUnitExp(int _unitExp) => UnitExp = _unitExp;
    public void SetPromotionLevel(ePromotionLevel _promotionLevel) => PromotionLevel = _promotionLevel;
    public void SetUnionBurst(List<SkillLevelInfoLight> _unionBurst) => UnionBurst = _unionBurst;
    public void SetMainSkill(List<SkillLevelInfoLight> _mainSkill) => MainSkill = _mainSkill;
    public void SetExSkill(List<SkillLevelInfoLight> _exSkill) => ExSkill = _exSkill;
    public void SetEquipSlot(List<EquipSlotLight> _equipSlot) => EquipSlot = _equipSlot;
    public void SetUniqueEquipSlot(List<EquipSlotLight> _uniqueEquipSlot) => UniqueEquipSlot = _uniqueEquipSlot;
    public void SetBonusParam(StatusParamShort _bonusParam) => BonusParam = _bonusParam;
    public void SetResistStatusId(int _resistStatusId) => ResistStatusId = _resistStatusId;
    public void SetResistVariationId(int _resistVariationId) => ResistVariationId = _resistVariationId;
    public void SetPower(int _power) => Power = _power;
    public void SetSkinData(SkinData _skinData) => SkinData = _skinData;
    public void SetFavoriteFlag(int _favoriteFlag) => FavoriteFlag = _favoriteFlag;
    public void SetUnlockRarity6Item(UnlockRarity6Slot _unlockRarity6Item) => UnlockRarity6Item = _unlockRarity6Item;
    public void SetExEquipSlot(List<ExtraEquipSlot> _exEquipSlot) => ExEquipSlot = _exEquipSlot;
    public void SetCbExEquipSlot(List<ExtraEquipSlot> _cbExEquipSlot) => CbExEquipSlot = _cbExEquipSlot;

    private void initializeUnitDataLight() { }

    public UnitDataLight() { }

    // public UnitDataLight(JsonData _json) { }

    // public void ParseUnitDataLight(JsonData _json) { }
}