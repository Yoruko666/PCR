using System.Collections.Generic;

namespace Elements
{ 
    public static class SystemIdDefine
    {
        public static readonly int AREA_ID_DEFAULT_MIN;
        public static readonly int AREA_ID_DEFAULT_MAX; 
        public static readonly int AREA_ID_ELITE_MIN; 
        public static readonly int AREA_ID_ELITE_MAX; 
        public static readonly int AREA_ID_VERY_HARD_MIN; 
        public static readonly int AREA_ID_VERY_HARD_MAX; 
        public static readonly int AREA_ID_UNIQUE_EQUIP; 
        public static readonly int AREA_ID_HIGH_RARITY_EQUIP; 
        public static readonly int AREA_ID_RUPEE; 
        public static readonly int AREA_ID_EXP; 
        public static readonly Dictionary<eMissionStatusType, int> MissionStatusTypeOrderDictionary; 
        public static readonly Dictionary<eMissionType, eTextId> MissionTypeTextDictionary; 
        public static readonly Dictionary<eSystemId, eTextId> SystemIdTextDictionary; 
        public static readonly Dictionary<eSystemId, eTextId> SystemIdTextForRarityUpDictionary; 
        public static readonly Dictionary<eLineupGroupSetId, eSystemId> LineupGroupSetIdToSystemIdDictionary; 
        public static readonly eTextId[] LoginBonusLotteryIdTexts; 
        public static readonly Dictionary<eSystemId, ContentReleaseInfo> ContentReleaseInfoDictionary; 
        public static readonly Dictionary<eSystemId, ContentReleaseInfo> ContentReleaseInfoUniqueTutorialDictionary; 
        public static readonly Dictionary<eSystemId, eSystemId> ContentReleaseIconDictionary; 


        public class ContentReleaseInfo 
        {

            public eViewId MoveTarget { get; set; }
            public eTextId Text { get; set; }
            public bool MoveButtonEnable { get; set; }
            public eViewId ContentView { get; set; }
            public bool IsTutorialEndCheck { get; set; }

            public ContentReleaseInfo(eViewId _moveTargetView = 0, eTextId _text = 1672466659, bool _moveButtonEnable = false, eViewId _contentTargetView = 0, bool _isTutorialEndCheck = false) { }
        }

        public enum eAreaType
        {
            None = 0,
            Normal = 11,
            Hard = 12,
            VeryHard = 13,
            UniqueEquip = 18,
            HighRarityEquip = 19,
            Dungeon = 31,
            SecretDungeon = 32,
            HatsuneNormal = 100,
            HatsuneHard = 200,
            Rupee = 21001,
            Exp = 21002
        }

        public enum eMissionConditionType
        {
            Unique = 1,
            Count = 2
        }

        public enum eMultiLobbyType
        {
            All = 1,
            Guild = 2
        }

        public enum eWeaponSeType
        {
            Default = 0,
            Knuckle = 1,
            ShortSword = 2,
            Ax = 3,
            Sword = 4,
            LongSword = 5,
            Spear = 6,
            Wand = 7,
            Arrow = 8,
            Dagger = 9,
            LongSword2 = 10,
            Scratch1 = 11,
            Scratch2 = 12,
            Hammer = 13,
            Bite = 14,
            CommonSmall = 15,
            CommonLarge = 16,
            Explosion = 17,
            WandKimono = 21,
            SwordKimono = 22,
            NoWandWitch = 23,
            Wand2 = 25,
            NoWandWitch2 = 26,
            DualSword = 27,
            Flail = 28,
            Wand3 = 29,
            AxKimono = 30,
            Dagger2 = 31,
            DualKnuckle = 32,
            Slingshot = 33,
            GlorySword = 34,
            Crossbow = 35,
            ShortSword2 = 36,
            Karin = 37,
            AxFurisode = 38,
            Flag = 39,
            Sword2 = 40,
            LongSword3 = 41,
            Wand4 = 42,
            Wing = 43,
            Ames = 44,
            Kaiser = 45,
            MitsukiNy = 46,
            SpearKimono = 48,
            Misora = 49,
            Vikala = 51
        }

        public enum eWeaponMotionType
        {
            Default = 0,
            Knuckle = 1,
            ShortSword = 2,
            Ax = 3,
            Sword = 4,
            LongSword = 5,
            Spear = 6,
            Wand = 7,
            Arrow = 8,
            Dagger = 9,
            LongSword2 = 10,
            WandKimono = 21,
            SwordKimono = 22,
            NoWandWitch = 23,
            Wand2 = 25,
            NoWandWitch2 = 26,
            DualSword = 27,
            Flail = 28,
            Wand3 = 29,
            AxKimono = 30,
            Dagger2 = 31,
            DualKnuckle = 32,
            Slingshot = 33,
            GlorySword = 34,
            Crossbow = 35,
            ShortSword2 = 36,
            Karin = 37,
            AxFurisode = 38,
            Flag = 39,
            Sword2 = 40,
            LongSword3 = 41,
            Wand4 = 42,
            Wing = 43,
            Ames = 44,
            Kaiser = 45,
            LongSwordKimono = 46,
            TamakiCafe = 47,
            SpearKimono = 48,
            Misora = 49,
            WandDjeeta = 50,
            ShortSwordSwimsuit = 52,
            Pureshia = 53
        }
    }
}