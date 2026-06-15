using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleDefine 
{
	public const string BattleLogicVersion = "4";
	public const int ArenaBgId = 100001;
	public const int GrandarenaBgId = 100002;
	public const int ColosseumBgId = 100003;
	public const float MainQuestZoomPos = 4935;
	public const float OtherQuestZoomPos = 4780;
	public const int LastSealCount = 1;
	public const int LogicFrameRate = 60;
	public static readonly Dictionary<eBattleCategory, eBGM[]> BattleBgmDic; 
	public const int InvalidBlockId = -1;
	public static readonly List<eUnitRespawnPos> UnitRespawnPosList;
	public static readonly List<eUnitRespawnPos> UnitRespawnPosTopToBottom; 
	private static readonly List<eUnitRespawnPos> EnemyRespawnPosList;
	public const int BackgroundOrder = -1100;
	public const int ForegroundOrder = 10900;
	public const int MiddlegroundOrder = 680;
	public const int BackCharaOrder = 350;
	public const int FrontCharaOrder = 10850;
	public const int ChangeWaveFrameNum = 100000;
	public const string BattlePath = "Assets/_ElementsResources/Resources/All/Battle";
	private static readonly Dictionary<eUnitRespawnPos, int> UnitSortOrderDictionary; 
	private const int ResultSortOrderOffset = 100;
	public const int StatusEffectSortOrderOffset = 350;
	public const int EffectUnitFrontSortOrderOffset = 300;
	public const int EffectUnitBackSortOrderOffset = -300;
	public const int EffectFrontSortOrder = 11000;
	public const int EffectBackSortOrder = 690;
	public const int UiSortOrder = 11250;
	public const int BlackOutSortOrder = 11500;
	public const int ResultUiBackSortOrder = 9000;
	public const int EffectUnitFrontSortOrderOffsetFlatout = 200;
	public const int CriticalRateMax = 1;
	public const double CriticalAtkRate = 2;
	public const int DefaultCriticalDamageRate = 100;
	public const long MinCriticalDamageRate = 50;
	public const int DefaultReceiveDamageAdditionalPercent = 0;
	public const int DefaultDamageUpAdditionalPercent = 0;
	public const int DefaultTalentFormationBonus = 0;
	public const double MinDamage = 1;
	public const double DefaultDamageRate = 1;
	public const double SkillEnergyMax = 1000;
	public const int TrancationDigit = 1000;
	public const int AloneCount = 1;
	public const double UnitBaseSpeed = 1;
	public const double UnitMinSpeed = 0.10000000149011612;
	private const float RespawnPosTopY1 = 40;
	private const float RespawnPosBottomY1 = -186;
	private const int LaneCountMinusOne = 9;
	public const float BattlePosY = 5000;
	public const float BattleBgSize = 1.15f;
	public const float BattlePosYOtherThanQuest = 5140;
	public const float BattleUnitSpaceX = 200;
	public const string SkillFxFilenamePrefix = "fxsk_";
	public const string SkillFxFilenamePrefixSample = "fxsk_0000_CUT_";
	public const float QuestWinOffset = 280;
	public const float GrandArenaWinOffset = 302;
	public const float QuestWinPosY = -100;
	public const int ModeChangePrefix = 1;
	public const double DefaultSlipDamageRate = 1;
	public const int MoveSpeedMin = 1;
	public static readonly Dictionary<eUnitRespawnPos, float> RespawnPos; 
	public static readonly Dictionary<eUnitRespawnPos, List<eUnitRespawnPos>> SummonRespawnPriority;
	public const float BattleStartPos = 560;
	public const float BossDefaultDeltaX = -34;
	public static readonly float BattleFieldSize; // 0x38
	public const float ArenaTimeLimit = 90;
	public const float MaxBattleTime = 9999;
	public const float LoseWaitTime = 1.3f;
	public const float TimeUpWaitTime = 0.5f;
	public const float BattleStartWaitTime = 0.5f;
	public const float BattleStartAdvWaitTime = 2;
	public const float MyTurnDispWaitTime = 3;
	public const float MyTurnDispFadeOutTime = 0.2f;
	public const float WinFlatoutWaitTime = 0.5f;
	public const float LoseFlatoutWaitTime = 0.5f;
	public const float MoveStageWidth = -480;
	public const float EToECoefficient = 2.0444443f;
	public const float JoyMotionPauseDuration = 0.3f;
	public const int JoyMotionPauseStartFrame = 3;
	public const float InvisibleX = -1400;
	public const float RunMoveRate = 1.6f;
	public const int BattleUbTimelineMax = 500;
//	public static readonly Dictionary<SystemIdDefine.eWeaponSeType, eSE> WeaponSeDic;
//	public static readonly Dictionary<SystemIdDefine.eWeaponSeType, eResourceId> WeaponHitEffectDic; 
//	public static readonly Dictionary<eResourceId, eResourceId> WeaponHitEffectDicL; 
//	public static readonly Dictionary<SystemIdDefine.eWeaponMotionType, float> WeaponHitDelayDic;
//	public static readonly Dictionary<SystemIdDefine.eWeaponMotionType, float> WeaponEffectDelayDic; 
	public static readonly string[] HpGaugeModeLabelOutlineColor; 
	public const float BattleScale = 540;
	public const float CameraMinX = 1100;
	public const int BgWidth = 1440;
	public const int BgHeight = 540;
	public const float ResultCameraDefaultScale = 1;
	public static readonly float HeadOffset; 
	public static readonly float AudioListenerPosZ;
	public const float UnitMoveSpeed = 1600;
	public const int AloneUnitCount = 1;
	public const string FooterShakeName = "battle_footer_icon_shake";
	public const string FooterSkillReserveAnimationName = "SkillReserveEffect_idle";
	public const string HeaderSkillReserveLabelAnimationName = "ReserveSkillIcon_disappear";
	public const string EnvironmentAppearAnimationNameL = "EnvironmentIcon_appear_l";
	public const string EnvironmentDisappearAnimationNameL = "EnvironmentIcon_disappear_l";
	public const string EnvironmentAppearAnimationNameR = "EnvironmentIcon_appear_r";
	public const string EnvironmentDisappearAnimationNameR = "EnvironmentIcon_disappear_r";
	public const string TalentBonusBackgroundSpriteName = "battle_talent_bonus_bg_{0}";
	public const string TalentBonusBackgroundRightSpriteName = "battle_talent_bonus_bg_r_{0}";
	public const string TalentBonusSymbolSpriteName = "battle_talent_bonus_{0}";
	public const float GoldEffectDelay = 0.2f;
	public const float TreasureDropInterval = 0.02f;
	public const float TreasureDropIntervalRare = 0.06f;
	public const float TreasureMoveStartInterval = 0.05f;
	public static readonly float[] TreasurePosOffsetX; 
	public const float TreasurePosOffsetY = 0.083333336f;
	public static readonly Vector3 TreasureBoxPos; 
	public const int WaveMax = 3;
	public const int FirstModeNum = 1;
	public const int FinalMode3Num = 3;
	public const int ModeClearWaitTime = 2;
//	public static readonly Dictionary<SoundManager.eVoiceType, BattleDefine.VoiceJudgeData> VoiceJudgeDataDictionary; 
//	public static readonly Dictionary<SoundManager.eVoiceType, SoundManager.eVoiceType> ModeChangeVoiceDictionary; 
	public const double MaxDamage = 9999999;
	public const long MaxTotalDamage = 99999999;
	public const long MaxRecoveryValue = 99999999;
	public const long MaxParameterValue = 2000000000;
	public const int MotionPrefixModeChange = 1;
	public const double PercentDigit = 100;
	public const int PercentDigitInt = 100;
	public const double PermyriadDigit = 10000;
	public const int EnemyColorDefault = 0;
	public const int EnemyColorStart = 1;
	public const int EnemyColorLast = 5;
	public const float HealInterval = 0.45f;
	public const int ColumnValueToShowAbnormalStateIcon = 0;
	public const int InBattleDialogSortingOrder = 9000;

//	public static eUnitRespawnPos GetUnitRespawnPos(int index, bool isEnemySide = false) { }

//	public static int GetUnitSortOrder(UnitCtrl _unit) { }

//	public static int GetResultUnitSortOrder(int _order) { }

//	public static int GetResultUnitSortOrder(int _baseDepth, int _order) { }

	public BattleDefine() { }

	static BattleDefine() { }

	[Serializable]
	public class ZoomEffect 
	{
		public bool Enable; 
		public bool ConsiderScreenSize; 
		public float StartDelay; 
		public float StartDuration; 
		public float Duration; 
		public float EndDuration; 
		public float To; 
		public eZoomTarget ZoomTarget; 
		public float OffsetY; 
		public float OffsetX; 
		public bool UseYBottom; 
		public CustomEasing StartEasing; 
		public CustomEasing EndEasing; 
		public CustomEasing StartPosXEasing;
		public CustomEasing EndPosXEasing; 
		public CustomEasing StartPosYEasing;
		public CustomEasing EndPosYEasing; 
		public List<ZoomEffectPlual> ZoomEffectList; 
		public CustomEasing.eEasingType StartEasingType; 
		public CustomEasing.eEasingType EndEasingType;
		public string BoneName; 
		public float ToPosX { get; set; }
		public float ToPosY { get; set; }
		public ZoomEffect() { }
	}
		
	public enum eZoomTarget
	{
		Owner = 0,
		EnemyTarget = 1,
		OAndEt = 2,
		PlayerTarget = 3,
		OAndPt = 4,
		OBone = 5,
		InvalidValue = -1,
	}

	[Serializable]
	public class ZoomEffectPlual 
	{
		public float StartDuration; 
		public float Duration; 
		public float To;
		public float OffsetX; 
		public float OffsetY; 
		public eZoomTarget ZoomTarget; 
		public CustomEasing StartEasing; 
		public CustomEasing StartPosXEasing; 
		public CustomEasing StartPosYEasing; 
		public CustomEasing.eEasingType StartEasingType;
		public bool UseYBottom;
		public string BoneName; 

		public float ToPosX { get; set; }
		public float ToPosY { get; set; }

		public ZoomEffectPlual() { }
	}

	[Serializable]
	public class SlowEffect 
	{
		public bool Enable; 
		public float StartDelay; 
		public float StartDuration; 
		public float Duration; 
		public float EndDuration; 
		public float To; 
		public CustomEasing StartEasing; 
		public CustomEasing EndEasing; 

		public SlowEffect() { }
	}
}