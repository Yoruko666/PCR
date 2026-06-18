namespace Elements
{
    public enum eStateIconType
    {
        None = 0,
        BuffPhysicalAtk = 1,
        BuffPhysicalDef = 2,
        BuffMagicAtk = 3,
        BuffMagicDef = 4,
        BuffDodge = 5,
        BuffCritical = 6,
        BuffEnergyRecovery = 7,
        BuffHpRecovery = 8,
        Haste = 9,  //加速
        NoDamage = 10,
        BuffLifeSteal = 11,
        BuffAddLifeSteal = 12,

        DebuffPhysicalAtk = 13,
        DebuffPhysicalDef = 14,
        DebuffMagicAtk = 15,
        DebuffMagicDef = 16,
        DebuffDodge = 17,
        DebuffCritical = 18,
        DebuffEnergyRecovery = 19,
        DebuffHpRecovery = 20,
        DebuffLifeSteal = 21,
        Slow = 22,
        UbDisable = 23,

        PhysicsBarriar = 24,
        MagicBarriar = 25,
        PhysicsDrainBarriar = 26,
        MagicDrainBarriar = 27,
        BothBarriar = 28,
        BothDrainBarriar = 29,
        DebufBarriar = 30,
        StrikeBack = 31,    // 反弹
        Paralysis = 32,     // 麻痹
        SlipDamage = 33,    // 流血
        PhysicsDark = 34,   // 物理易伤
        Silence = 35,       // 沉默
        Convert = 36,       // 魅惑
        Decoy = 37,         // 诱饵
        Burn = 38,          // 灼烧
        Curse = 39,         // 诅咒
        Freeze = 40,        // 冻结
        Chained = 41,       // 束缚
        Sleep = 42,         // 睡眠
        Stun = 43,          // 眩晕
        Stone = 44,         // 石化
        Detain = 45,        // 拘禁

        Regeneration = 46,
        DebuffMoveSpeed = 47,   //减速
        PhysicsDodge = 48,      // 物理闪避
        Confusion = 49,         // 混乱
        HeroicSpiritSeal = 50,
        Venom = 51,         // 中毒
        CountBlind = 52,    // 致盲计数
        InhibitHeal = 53,   // 禁疗
        Fear = 54,          // 恐惧

        SoulEat = 56,   // 噬魂
        Chloe = 57,     // 角色专属：克洛伊
        FireNuts = 58,  // 火坚果标记
        Awe = 59,       // 震慑
        Luna = 60,      // 角色专属：露娜
        Christina = 61, // 角色专属：克里斯蒂娜
        TpRegeneration = 62,    // 临时再生
        CheatingStar = 63,      // 星运作弊
        Tonakai = 64,   // 角色专属：Tonakai
        Hex = 65,       // 降益巫术
        Faint = 66,     // 虚弱昏厥

        BuffPhysicalCriticalDamage = 67,    // 物理暴击伤害提升
        DebuffPhysicalCriticalDamage = 68,  // 物理暴击伤害降低
        BuffMagicCriticalDamage = 69,       // 魔法暴击伤害提升
        DebuffMagicCriticalDamage = 70,     // 魔法暴击伤害降低
        Compensation = 71,      // 伤害补偿反弹
        KnightGuard = 72,       // 骑士守护
        CutAtkDamage = 73,      // 物理伤害削减
        CutMgcDamage = 74,      // 魔法伤害削减
        CutAllDamage = 75,      // 全伤害削减

        Chieru = 76,    // 角色专属：千惠留
        Rei = 77,       // 角色专属：玲
        LogAtkBarrier = 78,     // 物理伤害屏障
        LogMgcBarrier = 79,     // 魔法伤害屏障
        LogAllBarrier = 80,     // 全伤害屏障
        PauseAction = 81,       // 禁止行动

        BuffAccuracy = 83,      // 命中提升
        DebuffAccuracy = 84,    // 命中降低
        BossBuff = 85,          // BOSS专属增益
        UbSilence = 86,         // 大招专属沉默
        Cupid = 87,             // 角色专属：丘比特
        DebuffMaxHp = 88,       // 最大生命值降低
        MagicDark = 89,         // 魔法易伤
        Matsuri = 90,           // 角色专属：祭
        HealDown = 91,          // 治疗效果衰减
        AkinoChristmas = 92,    // 角色专属：秋乃圣诞
        NpcStun = 93,           // NPC专属眩晕

        BuffReceiveCriticalDamage = 94,     // 受到暴击伤害降低
        DebuffReceiveCriticalDamage = 95,   // 受到暴击伤害提升
        DecreaseHeal = 96,      // 治疗量大幅降低
        Shefi = 97,             // 角色专属：诗菲
        SchoolFestivalYuni = 98,        // 学园祭：由仁
        SchoolFestivalChloe = 99,       // 学园祭：克洛伊
        PoisonByBehaviour = 100,        // 行为触发中毒
        AdditionalBuffPhysicalDef = 101, // 额外物防增益
        Crystalize = 102,       // 晶化禁锢
        DamageLimit = 103,      // 伤害上限限制
        AdditionalBuffMagicDef = 104,    // 额外魔防增益

        MagicCharacterOfWisdom = 105,    // 智慧魔法刻印
        MagicCharacterOfPower = 106,     // 力量魔法刻印
        DetectWeakness = 107,   // 弱点侦测
        DebuffReceivePhysicalAndMagicDamagePercent = 108, // 受到物魔伤害百分比提升
        DebuffReceivePhysicalDamagePercent = 109,         // 受到物理伤害百分比提升
        DebuffReceiveMagicDamagePercent = 110,            // 受到魔法伤害百分比提升
        LabyristaOverload = 111,        // 拉比丽斯塔超载
        SwordSeal = 112,        // 剑印封印
        PhantomcoreWedge = 113, // 幻核楔子标记
        Spy = 114,              // 侦察暴露隐身
        HappyMoment = 115,      // 美好时刻增益
        SeaGodProtection = 116, // 海神庇护
        BlueMagicSeal = 117,    // 蓝魔法封印
        Sheep = 118,            // 绵羊变形标记
        TwilightGuard = 119,    // 黄昏守护
        PsychicPower = 120,     // 心灵力量
        CelestialBodies = 121,  // 天体星象印记
        KaiserInsightCarvedSeal = 122,  // 凯撒洞察刻印
        Like = 123,             // 好感标记
        EnergyDamageReduce = 124,       // 能量伤害减免
        SagittariusCarvedSeal = 125,    // 射手座刻印
        AnneAndGlareCarvedSeal = 126,   // 安&古蕾雅
        MitsukiNyCarvedSeal = 127,      // 美月新年刻印
        BlackFrame = 128,       // 黑屏镜头效果
        UnableStateGuard = 129, // 异常状态免疫护盾
        MuimiAnniversaryCarvedSeal = 130, // 睦美周年刻印
        MisoraCarvedSeal = 131, // 美空刻印
        Flight = 132,           // 飞行浮空
        DjeetaWitch = 133,      // 吉塔魔女标记

        LimitEnergyRecoverRate = 150,    // 能量回复速率限制
        SlipDamageUp = 154,     // 持续流血伤害提升
        UnableStateGuardExtraEffect = 165, // 额外效果异常免疫盾
        ChainedAcn = 166,       // 强化锁链禁锢
        Puppet = 167,           // 傀儡控制
        Taunt = 172,            // 嘲讽强制攻击自身

        BuffPhysicalDamage = 179,       // 物攻百分比提升
        BuffMagicDamage = 180,  // 魔攻百分比提升
        DebuffPhysicalDamage = 181,     // 物攻百分比降低
        DebuffMagicDamage = 182, // 魔攻百分比降低
        MagicDodge = 184,       // 魔法闪避提升

        ExPassive1 = 999,

        Num = 1000,
        InvalidValue = -1
    }
}