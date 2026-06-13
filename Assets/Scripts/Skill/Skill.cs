using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill 
{
	// Fields
	public bool IsPrincessForm; // 0x10
	public List<PrincessSkillMovieData> PrincessSkillMovieDataList; // 0x18
	private List<ActionParameter> actionParameters; // 0x20
	public List<ActionParameterOnPrefab> ActionParametersOnPrefab; // 0x28
	public List<NormalSkillEffect> SkillEffects; // 0x30
	public List<ShakeEffect> ShakeEffects; // 0x38
	public List<BlurEffect.BlurEffectData> BlurEffects; // 0x40
	public BattleDefine.ZoomEffect ZoomEffect; // 0x48
	public BattleDefine.SlowEffect SlowEffect; // 0x50
	public bool ForcePlayNoTarget; // 0x58
	public int ParameterTarget; // 0x5C
	public List<ChangeSortOrderData> ChangeSortDatas; // 0x60
	public List<ScaleChanger> ScaleChangers; // 0x68
	public int SkillId; // 0x78
	public float skillAreaWidth; // 0x7C
	public eSpineCharacterAnimeId AnimId; // 0x80
	public bool Cancel; // 0x84
	public bool DisableOtherCharaOnStart; // 0x90
	private List<SkillEffectCtrl> effectObjs; // 0x98
	private List<SkillEffectCtrl> loopEffectObjs; // 0xA0
	public float BlackOutTime; // 0xB0
	public bool BlackoutEndWithMotion; // 0xB4
	public bool ForceComboDamage; // 0xB5
	public Color BlackoutColor; // 0xB8
	public float CutInMovieFadeStartTime; // 0xC8
	public float CutInMovieFadeDurationTime; // 0xCC
	public float CutInSkipTime; // 0xD0
	public bool ForceCutinOff; // 0xD4
	public int Level; // 0xD8
	public string SkillName; // 0xE0
	public List<int> BranchIds; // 0x138
	public SubUbVoiceTimingSet SpeedUpWithCutinVoice; // 0x178
	public SubUbVoiceTimingSet SpeedUpNoCutinVoice; // 0x180
	public SubUbVoiceTimingSet NormalWithCutinVoice; // 0x188
	public SubUbVoiceTimingSet NormalNoCutinVoice; // 0x190
	public List<Skill> OverrideSkillList; // 0x1A0

	// Properties
	public List<ActionParameter> ActionParameters { get; set; }
	public float CastTime { get; set; }
	public float UnionBurstCoolDownTime { get; set; }
	public Dictionary<BasePartsData, BasePartsData> ProtectParts { get; set; }
	public int SkillNum { get; set; }
	public List<SkillEffectCtrl> EffectObjs { get; }
	public List<SkillEffectCtrl> LoopEffectObjs { get; }
	public List<int> HasParentIndexes { get; set; }
	public Vector3 OwnerReturnPosition { get; set; }
	public bool IsModeChange { get; set; }
	public Dictionary<UnitCtrl, double> AccumulatedTpRecovery { get; set; }
	public long AccumulatedLifeSteal { get; set; }
	public bool UseAccumulatedDamage { get; set; }
	public int DefeatEnemyCount { get; set; }
	public bool DefeatByThisSkill { get; set; }
	public bool AlreadyAddAttackSelfSeal { get; set; }
	public bool AlreadyExexActionByHit { get; set; }
	public bool AlreadyAddAttackSealForAllEnemy { get; set; }
	public int LifeSteal { get; set; }
	public bool CountBlind { get; set; }
	public KPCGPAGLKBJ.MDHGGPCJHMO CountBlindType { get; set; }
	public int EffectBranchId { get; set; }
	public bool HasAttack { get; set; }
	public bool LoopEffectAlreadyDone { get; set; }
	public List<BasePartsData> DamagedPartsList { get; set; }
	public List<BasePartsData> CriticalPartsList { get; set; }
	public long TotalDamage { get; set; }
	public double AweValue { get; set; }
	public bool IsLifeStealEnabled { get; set; }
	public long AbsorberValue { get; set; }
	public int BonusId { get; set; }

	// RVA: 0x208324C Offset: 0x208324C VA: 0x208324C
	public void SetLevel(int _level) { }

	// RVA: 0x20832F4 Offset: 0x20832F4 VA: 0x20832F4
	public void ReadySkill() { }
}