using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleDefine 
{
	public const string BATTLE_LOGIC_VERSION = "4";
	public const int ARENA_BG_ID = 100001;
	public const int GRANDARENA_BG_ID = 100002;
	public const int COLOSSEUM_BG_ID = 100003;
	public const float MAIN_QUEST_ZOOM_POS = 4935;
	public const float OTHER_QUEST_ZOOM_POS = 4780;
	public const int LAST_SEAL_COUNT = 1;
	public const int LOGIC_FRAME_RATE = 60;
	public static readonly Dictionary<eBattleCategory, eBGM[]> BattleBgmDic; // 0x0
	public const int INVALID_BLOCK_ID = -1;
	public static readonly List<eUnitRespawnPos> UnitRespawnPosList; // 0x8
	public static readonly List<eUnitRespawnPos> UnitRespawnPosTopToBottom; // 0x10
	private static readonly List<eUnitRespawnPos> enemyRespawnPosList; // 0x18
	public const int BACKGROUND_ORDER = -1100;
	public const int FOREGROUND_ORDER = 10900;
	public const int MIDDLEGROUND_ORDER = 680;
	public const int BACK_CHARA_ORDER = 350;
	public const int FRONT_CHARA_ORDER = 10850;
	public const int CHANGE_WAVE_FRAME_NUM = 100000;
	public const string BATTLE_PATH = "Assets/_ElementsResources/Resources/All/Battle";
	private static readonly Dictionary<eUnitRespawnPos, int> unitSortOrderDictionary; // 0x20
	private const int RESULT_SORT_ORDER_OFFSET = 100;
	public const int STATUS_EFFECT_SORT_ORDER_OFFSET = 350;
	public const int EFFECT_UNIT_FRONT_SORT_ORDER_OFFSET = 300;
	public const int EFFECT_UNIT_BACK_SORT_ORDER_OFFSET = -300;
	public const int EFFECT_FRONT_SORT_ORDER = 11000;
	public const int EFFECT_BACK_SORT_ORDER = 690;
	public const int UI_SORT_ORDER = 11250;
	public const int BLACK_OUT_SORT_ORDER = 11500;
	public const int RESULT_UI_BACK_SORT_ORDER = 9000;
	public const int EFFECT_UNIT_FRONT_SORT_ORDER_OFFSET_FLATOUT = 200;
	public const int CRITICAL_RATE_MAX = 1;
	public const double CRITICAL_ATK_RATE = 2;
	public const int DEFAULT_CRITICAL_DAMAGE_RATE = 100;
	public const long MIN_CRITICAL_DAMAGE_RATE = 50;
	public const int DEFAULT_RECEIVE_DAMAGE_ADDITIONAL_PERCENT = 0;
	public const int DEFAULT_DAMAGE_UP_ADDITIONAL_PERCENT = 0;
	public const int DEFAULT_TALENT_FORMATION_BONUS = 0;
	public const double MIN_DAMAGE = 1;
	public const double DEFAULT_DAMAGE_RATE = 1;
	public const double SKILL_ENERGY_MAX = 1000;
	public const int TRANCATION_DIGIT = 1000;
	public const int ALONE_COUNT = 1;
	public const double UNIT_BASE_SPEED = 1;
	public const double UNIT_MIN_SPEED = 0.10000000149011612;
	private const float RESPAWN_POS_TOP_Y_1 = 40;
	private const float RESPAWN_POS_BOTTOM_Y_1 = -186;
	private const int LANE_COUNT_MINUS_ONE = 9;
	public const float BATTLE_POS_Y = 5000;
	public const float BATTLE_BG_SIZE = 1.15f;
	public const float BATTLE_POS_Y_OTHER_THAN_QUEST = 5140;
	public const float BATTLE_UNIT_SPACE_X = 200;
	public const string SKILL_FX_FILENAME_PREFIX = "fxsk_";
	public const string SKILL_FX_FILENAME_PREFIX_SAMPLE = "fxsk_0000_CUT_";
	public const float QUEST_WIN_OFFSET = 280;
	public const float GRAND_ARENA_WIN_OFFSET = 302;
	public const float QUEST_WIN_POS_Y = -100;
	public const int MODE_CHANGE_PREFIX = 1;
	public const double DEFAULT_SLIP_DAMAGE_RATE = 1;
	public const int MOVE_SPEED_MIN = 1;
	public static readonly Dictionary<eUnitRespawnPos, float> RESPAWN_POS; // 0x28
	public static readonly Dictionary<eUnitRespawnPos, List<eUnitRespawnPos>> SUMMON_RESPAWN_PRIORITY; // 0x30
	public const float BATTLE_START_POS = 560;
	public const float BOSS_DEFAULT_DELTA_X = -34;
	public static readonly float BATTLE_FIELD_SIZE; // 0x38
	public const float ARENA_TIME_LIMIT = 90;
	public const float MAX_BATTLE_TIME = 9999;
	public const float LOSE_WAIT_TIME = 1.3f;
	public const float TIME_UP_WAIT_TIME = 0.5f;
	public const float BATTLE_START_WAIT_TIME = 0.5f;
	public const float BATTLE_START_ADV_WAIT_TIME = 2;
	public const float MY_TURN_DISP_WAIT_TIME = 3;
	public const float MY_TURN_DISP_FADE_OUT_TIME = 0.2f;
	public const float WIN_FLATOUT_WAIT_TIME = 0.5f;
	public const float LOSE_FLATOUT_WAIT_TIME = 0.5f;
	public const float MOVE_STAGE_WIDTH = -480;
	public const float E_TO_E_COEFFICIENT = 2.0444443f;
	public const float JOY_MOTION_PAUSE_DURATION = 0.3f;
	public const int JOY_MOTION_PAUSE_START_FRAME = 3;
	public const float INVISIBLE_X = -1400;
	public const float RUN_MOVE_RATE = 1.6f;
	public const int BATTLE_UB_TIMELINE_MAX = 500;
	public static readonly Dictionary<SystemIdDefine.eWeaponSeType, eSE> WEAPON_SE_DIC; // 0x40
	public static readonly Dictionary<SystemIdDefine.eWeaponSeType, eResourceId> WEAPON_HIT_EFFECT_DIC; // 0x48
	public static readonly Dictionary<eResourceId, eResourceId> WEAPON_HIT_EFFECT_DIC_L; // 0x50
	public static readonly Dictionary<SystemIdDefine.eWeaponMotionType, float> WEAPON_HIT_DELAY_DIC; // 0x58
	public static readonly Dictionary<SystemIdDefine.eWeaponMotionType, float> WEAPON_EFFECT_DELAY_DIC; // 0x60
	public static readonly string[] HP_GAUGE_MODE_LABEL_OUTLINE_COLOR; // 0x68
	public const float BATTLE_SCALE = 540;
	public const float CAMERA_MIN_X = 1100;
	public const int BG_WIDTH = 1440;
	public const int BG_HEIGHT = 540;
	public const float RESULT_CAMERA_DEFAULT_SCALE = 1;
	public static readonly float HEAD_OFFSET; // 0x70
	public static readonly float AUDIO_LISTENER_POS_Z; // 0x74
	public const float UNIT_MOVE_SPEED = 1600;
	public const int ALONE_UNIT_COUNT = 1;
	public const string FOOTER_SHAKE_NAME = "battle_footer_icon_shake";
	public const string FOOTER_SKILL_RESERVE_ANIMATION_NAME = "SkillReserveEffect_idle";
	public const string HEADER_SKILL_RESERVE_LABEL_ANIMATION_NAME = "ReserveSkillIcon_disappear";
	public const string ENVIRONMENT_APPEAR_ANIMATTION_NAME_L = "EnvironmentIcon_appear_l";
	public const string ENVIRONMENT_DISAPPEAR_ANIMATTION_NAME_L = "EnvironmentIcon_disappear_l";
	public const string ENVIRONMENT_APPEAR_ANIMATTION_NAME_R = "EnvironmentIcon_appear_r";
	public const string ENVIRONMENT_DISAPPEAR_ANIMATTION_NAME_R = "EnvironmentIcon_disappear_r";
	public const string TALENT_BONUS_BACKGROUND_SPRITE_NAME = "battle_talent_bonus_bg_{0}";
	public const string TALENT_BONUS_BACKGROUND_RIGHT_SPRITE_NAME = "battle_talent_bonus_bg_r_{0}";
	public const string TALENT_BONUS_SYMBOL_SPRITE_NAME = "battle_talent_bonus_{0}";
	public const float GOLD_EFFECT_DELAY = 0.2f;
	public const float TREASURE_DROP_INTERVAL = 0.02f;
	public const float TREASURE_DROP_INTERVAL_RARE = 0.06f;
	public const float TREASURE_MOVE_START_INTERVAL = 0.05f;
	public static readonly float[] TREASURE_POS_OFFSET_X; // 0x78
	public const float TREASURE_POS_OFFSET_Y = 0.083333336f;
	public static readonly Vector3 TREASURE_BOX_POS; // 0x80
	public const int WAVE_MAX = 3;
	public const int FIRST_MODE_NUM = 1;
	public const int FINAL_MODE_3_NUM = 3;
	public const int MODE_CLEAR_WAIT_TIME = 2;
	public static readonly Dictionary<SoundManager.eVoiceType, BattleDefine.VoiceJudgeData> VoiceJudgeDataDictionary; // 0x90
	public static readonly Dictionary<SoundManager.eVoiceType, SoundManager.eVoiceType> ModeChangeVoiceDictionary; // 0x98
	public const double MAX_DAMAGE = 9999999;
	public const long MAX_TOTAL_DAMAGE = 99999999;
	public const long MAX_RECOVERY_VALUE = 99999999;
	public const long MAX_PARAMETER_VALUE = 2000000000;
	public const int MOTION_PREFIX_MODE_CHANGE = 1;
	public const double PERCENT_DIGIT = 100;
	public const int PERCENT_DIGIT_INT = 100;
	public const double PERMYRIAD_DIGIT = 10000;
	public const int ENEMY_COLOR_DEFAULT = 0;
	public const int ENEMY_COLOR_START = 1;
	public const int ENEMY_COLOR_LAST = 5;
	public const float HEAL_INTERVAL = 0.45f;
	public const int COLUMN_VALUE_TO_SHOW_ABNORMAL_STATE_ICON = 0;
	public const int IN_BATTLE_DIALOG_SORTING_ORDER = 9000;

	public static eUnitRespawnPos GetUnitRespawnPos(int index, bool isEnemySide = false) { }

	public static int GetUnitSortOrder(UnitCtrl _unit) { }

	public static int GetResultUnitSortOrder(int _order) { }

	public static int GetResultUnitSortOrder(int _baseDepth, int _order) { }

	public void BattleDefine() { }

	// RVA: 0x2FBBA1C Offset: 0x2FBBA1C VA: 0x2FBBA1C
	private static void BattleDefine() { }

	[Serializable]
	public class ZoomEffect 
	{
		public bool Enable; 
		public bool ConsiderScreenSize; 
		public float StartDelay; 
		public float StartDuration; // 0x18
		public float Duration; // 0x1C
		public float EndDuration; // 0x20
		public float To; // 0x24
		public eZoomTarget ZoomTarget; // 0x28
		public float OffsetY; // 0x2C
		public float OffsetX; // 0x30
		public bool UseYBottom; // 0x34
		public CustomEasing StartEasing; // 0x38
		public CustomEasing EndEasing; // 0x40
		public CustomEasing StartPosXEasing; // 0x48
		public CustomEasing EndPosXEasing; // 0x50
		public CustomEasing StartPosYEasing; // 0x58
		public CustomEasing EndPosYEasing; // 0x60
		public List<BattleDefine.ZoomEffectPlual> ZoomEffectList; // 0x68
		public CustomEasing.eType StartEasingType; // 0x70
		public CustomEasing.eType EndEasingType;
		public string BoneName; // 0x80

		// Properties
		public float ToPosX { get; set; }
		public float ToPosY { get; set; }
		public ZoomEffect() { }
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
		public CustomEasing.eType StartEasingType;
		public bool UseYBottom;
		public string BoneName; 

		// Properties
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