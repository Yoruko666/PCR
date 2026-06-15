using System.ComponentModel;

public enum eStateIconType
{
    [Description("无图标")]
    None = 0,
    [Description("物攻提升")]
    BuffPhysicalAtk = 1,
    [Description("物防提升")]
    BuffPhysicalDef = 2,
    [Description("魔攻提升")]
    BuffMagicAtk = 3,
    [Description("魔防提升")]
    BuffMagicDef = 4,
    [Description("闪避提升")]
    BuffDodge = 5,
    [Description("暴击提升")]
    BuffCritical = 6,
    [Description("能量回复提升")]
    BuffEnergyRecovery = 7,
    [Description("生命持续回复")]
    BuffHpRecovery = 8,
    [Description("加速迅捷")]
    Haste = 9,
    [Description("免疫伤害")]
    NoDamage = 10,
    [Description("吸血")]
    BuffLifeSteal = 11,
    [Description("额外吸血倍率")]
    BuffAddLifeSteal = 12,

    [Description("物攻降低")]
    DebuffPhysicalAtk = 13,
    [Description("物防降低")]
    DebuffPhysicalDef = 14,
    [Description("魔攻降低")]
    DebuffMagicAtk = 15,
    [Description("魔防降低")]
    DebuffMagicDef = 16,
    [Description("闪避降低")]
    DebuffDodge = 17,
    [Description("暴击降低")]
    DebuffCritical = 18,
    [Description("能量回复衰减")]
    DebuffEnergyRecovery = 19,
    [Description("生命回复衰减")]
    DebuffHpRecovery = 20,
    [Description("吸血降低")]
    DebuffLifeSteal = 21,
    [Description("减速")]
    Slow = 22,
    [Description("大招禁用")]
    UbDisable = 23,

    [Description("物理护盾")]
    PhysicsBarriar = 24,
    [Description("魔法护盾")]
    MagicBarriar = 25,
    [Description("物理吸血护盾")]
    PhysicsDrainBarriar = 26,
    [Description("魔法吸血护盾")]
    MagicDrainBarriar = 27,
    [Description("全属性护盾")]
    BothBarriar = 28,
    [Description("全属性吸血护盾")]
    BothDrainBarriar = 29,
    [Description("减益类护盾")]
    DebufBarriar = 30,
    [Description("反弹伤害")]
    StrikeBack = 31,
    [Description("麻痹")]
    Paralysis = 32,
    [Description("持续流血伤害")]
    SlipDamage = 33,
    [Description("物理易伤")]
    PhysicsDark = 34,
    [Description("沉默")]
    Silence = 35,
    [Description("魅惑转化")]
    Convert = 36,
    [Description("诱饵分身")]
    Decoy = 37,
    [Description("灼烧DOT")]
    Burn = 38,
    [Description("诅咒")]
    Curse = 39,
    [Description("冰冻禁锢")]
    Freeze = 40,
    [Description("锁链束缚")]
    Chained = 41,
    [Description("睡眠")]
    Sleep = 42,
    [Description("眩晕")]
    Stun = 43,
    [Description("石化")]
    Stone = 44,
    [Description("拘禁")]
    Detain = 45,
    [Description("持续再生回血")]
    Regeneration = 46,
    [Description("移速降低")]
    DebuffMoveSpeed = 47,
    [Description("物理闪避提升")]
    PhysicsDodge = 48,
    [Description("混乱")]
    Confusion = 49,
    [Description("英灵封印")]
    HeroicSpiritSeal = 50,
    [Description("剧毒")]
    Venom = 51,
    [Description("致盲计数")]
    CountBlind = 52,
    [Description("禁止治疗")]
    InhibitHeal = 53,
    [Description("恐惧")]
    Fear = 54,

    [Description("噬魂")]
    SoulEat = 56,
    [Description("角色专属：克洛伊")]
    Chloe = 57,
    [Description("火坚果标记")]
    FireNuts = 58,
    [Description("震慑")]
    Awe = 59,
    [Description("角色专属：露娜")]
    Luna = 60,
    [Description("角色专属：克里斯蒂娜")]
    Christina = 61,
    [Description("临时再生")]
    TpRegeneration = 62,
    [Description("星运作弊")]
    CheatingStar = 63,
    [Description("角色专属：Tonakai")]
    Tonakai = 64,
    [Description("降益巫术")]
    Hex = 65,
    [Description("虚弱昏厥")]
    Faint = 66,

    [Description("物理暴击伤害提升")]
    BuffPhysicalCriticalDamage = 67,
    [Description("物理暴击伤害降低")]
    DebuffPhysicalCriticalDamage = 68,
    [Description("魔法暴击伤害提升")]
    BuffMagicCriticalDamage = 69,
    [Description("魔法暴击伤害降低")]
    DebuffMagicCriticalDamage = 70,
    [Description("伤害补偿反弹")]
    Compensation = 71,
    [Description("骑士守护")]
    KnightGuard = 72,
    [Description("物理伤害削减")]
    CutAtkDamage = 73,
    [Description("魔法伤害削减")]
    CutMgcDamage = 74,
    [Description("全伤害削减")]
    CutAllDamage = 75,

    [Description("角色专属：千惠留")]
    Chieru = 76,
    [Description("角色专属：玲")]
    Rei = 77,
    [Description("物理伤害屏障")]
    LogAtkBarrier = 78,
    [Description("魔法伤害屏障")]
    LogMgcBarrier = 79,
    [Description("全伤害屏障")]
    LogAllBarrier = 80,
    [Description("禁止行动")]
    PauseAction = 81,

    [Description("命中提升")]
    BuffAccuracy = 83,
    [Description("命中降低")]
    DebuffAccuracy = 84,
    [Description("BOSS专属增益")]
    BossBuff = 85,
    [Description("大招专属沉默")]
    UbSilence = 86,
    [Description("角色专属：丘比特")]
    Cupid = 87,
    [Description("最大生命值降低")]
    DebuffMaxHp = 88,
    [Description("魔法易伤")]
    MagicDark = 89,
    [Description("角色专属：祭")]
    Matsuri = 90,
    [Description("治疗效果衰减")]
    HealDown = 91,
    [Description("角色专属：秋乃圣诞")]
    AkinoChristmas = 92,
    [Description("NPC专属眩晕")]
    NpcStun = 93,

    [Description("受到暴击伤害降低")]
    BuffReceiveCriticalDamage = 94,
    [Description("受到暴击伤害提升")]
    DebuffReceiveCriticalDamage = 95,
    [Description("治疗量大幅降低")]
    DecreaseHeal = 96,
    [Description("角色专属：诗菲")]
    Shefi = 97,
    [Description("学园祭：由仁")]
    SchoolFestivalYuni = 98,
    [Description("学园祭：克洛伊")]
    SchoolFestivalChloe = 99,
    [Description("行为触发中毒")]
    PoisonByBehaviour = 100,
    [Description("额外物防增益")]
    AdditionalBuffPhysicalDef = 101,
    [Description("晶化禁锢")]
    Crystalize = 102,
    [Description("伤害上限限制")]
    DamageLimit = 103,
    [Description("额外魔防增益")]
    AdditionalBuffMagicDef = 104,

    [Description("智慧魔法刻印")]
    MagicCharacterOfWisdom = 105,
    [Description("力量魔法刻印")]
    MagicCharacterOfPower = 106,
    [Description("弱点侦测")]
    DetectWeakness = 107,
    [Description("受到物魔伤害百分比提升")]
    DebuffReceivePhysicalAndMagicDamagePercent = 108,
    [Description("受到物理伤害百分比提升")]
    DebuffReceivePhysicalDamagePercent = 109,
    [Description("受到魔法伤害百分比提升")]
    DebuffReceiveMagicDamagePercent = 110,
    [Description("拉比丽斯塔超载")]
    LabyristaOverload = 111,
    [Description("剑印封印")]
    SwordSeal = 112,
    [Description("幻核楔子标记")]
    PhantomcoreWedge = 113,
    [Description("侦察暴露隐身")]
    Spy = 114,
    [Description("美好时刻增益")]
    HappyMoment = 115,
    [Description("海神庇护")]
    SeaGodProtection = 116,
    [Description("蓝魔法封印")]
    BlueMagicSeal = 117,
    [Description("绵羊变形标记")]
    Sheep = 118,
    [Description("黄昏守护")]
    TwilightGuard = 119,
    [Description("心灵力量")]
    PsychicPower = 120,
    [Description("天体星象印记")]
    CelestialBodies = 121,
    [Description("凯撒洞察刻印")]
    KaiserInsightCarvedSeal = 122,
    [Description("好感标记")]
    Like = 123,
    [Description("能量伤害减免")]
    EnergyDamageReduce = 124,
    [Description("射手座刻印")]
    SagittariusCarvedSeal = 125,
    [Description("安与辉刻印")]
    AnneAndGlareCarvedSeal = 126,
    [Description("美月新年刻印")]
    MitsukiNyCarvedSeal = 127,
    [Description("黑屏镜头效果")]
    BlackFrame = 128,
    [Description("异常状态免疫护盾")]
    UnableStateGuard = 129,
    [Description("睦美周年刻印")]
    MuimiAnniversaryCarvedSeal = 130,
    [Description("美空刻印")]
    MisoraCarvedSeal = 131,
    [Description("飞行浮空")]
    Flight = 132,
    [Description("吉塔魔女标记")]
    DjeetaWitch = 133,

    [Description("能量回复速率限制")]
    LimitEnergyRecoverRate = 150,
    [Description("持续流血伤害提升")]
    SlipDamageUp = 154,
    [Description("额外效果异常免疫盾")]
    UnableStateGuardExtraEffect = 165,
    [Description("强化锁链禁锢")]
    ChainedAcn = 166,
    [Description("傀儡控制")]
    Puppet = 167,
    [Description("嘲讽强制攻击自身")]
    Taunt = 172,

    [Description("物攻百分比提升")]
    BuffPhysicalDamage = 179,
    [Description("魔攻百分比提升")]
    BuffMagicDamage = 180,
    [Description("物攻百分比降低")]
    DebuffPhysicalDamage = 181,
    [Description("魔攻百分比降低")]
    DebuffMagicDamage = 182,
    [Description("魔法闪避提升")]
    MagicDodge = 184,

    [Description("额外被动图标1")]
    ExPassive1 = 999,
    [Description("枚举总数计数")]
    Num = 1000,
    [Description("无效占位值")]
    InvalidValue = -1
}