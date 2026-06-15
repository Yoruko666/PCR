public enum eAbnormalStateType
{
    /// <summary>无状态</summary>
    None = 0,
    /// <summary>物理伤害格挡</summary>
    GuardAtk = 1,
    /// <summary>法术伤害格挡</summary>
    GuardMgc = 2,
    /// <summary>物理吸血</summary>
    DrainAtk = 3,
    /// <summary>法术吸血</summary>
    DrainMgc = 4,
    /// <summary>物理+法术双格挡</summary>
    GuardBoth = 5,
    /// <summary>物理+法术双吸血</summary>
    DrainBoth = 6,
    /// <summary>加速/迅捷</summary>
    Haste = 7,
    /// <summary>中毒持续掉血</summary>
    Poison = 8,
    /// <summary>灼烧</summary>
    Burn = 9,
    /// <summary>诅咒</summary>
    Curse = 10,
    /// <summary>减速</summary>
    Slow = 11,
    /// <summary>麻痹</summary>
    Paralysis = 12,
    /// <summary>冰冻</summary>
    Freeze = 13,
    /// <summary>魅惑/转化敌方</summary>
    Convert = 14,
    /// <summary>物理易伤/物理增伤标记</summary>
    PhysicsDark = 15,
    /// <summary>沉默，无法释放技能</summary>
    Silence = 16,
    /// <summary>锁链禁锢</summary>
    Chained = 17,
    /// <summary>睡眠</summary>
    Sleep = 18,
    /// <summary>眩晕</summary>
    Stun = 19,
    /// <summary>拘禁/束缚</summary>
    Detain = 20,
    /// <summary>免疫持续伤害</summary>
    NoEffectSlipDamage = 21,
    /// <summary>受伤无动作僵直</summary>
    NoDamageMotion = 22,
    /// <summary>免疫所有异常状态</summary>
    NoAbnormal = 23,
    /// <summary>免疫减益debuff</summary>
    NoDebuf = 24,
    /// <summary>累积伤害</summary>
    AccumulativeDamage = 25,
    /// <summary>诱饵/分身嘲讽</summary>
    Decoy = 26,
    /// <summary>特定角色专属buff（美冬）</summary>
    Mifuyu = 27,
    /// <summary>石化</summary>
    Stone = 28,
    /// <summary>持续回血再生</summary>
    Regeneration = 29,
    /// <summary>物理闪避提升</summary>
    PhysicsDodge = 30,
    /// <summary>混乱</summary>
    Confusion = 31,
    /// <summary>剧毒</summary>
    Venom = 32,
    /// <summary>多层致盲计数</summary>
    CountBlind = 33,
    /// <summary>禁止治疗</summary>
    InhibitHeal = 34,
    /// <summary>恐惧</summary>
    Fear = 35,
    /// <summary>临时再生</summary>
    TpRegeneration = 36,
    /// <summary>巫术/降益</summary>
    Hex = 37,
    /// <summary>虚弱/昏厥</summary>
    Faint = 38,
    /// <summary>部位免疫伤害</summary>
    PartsNoDamage = 39,
    /// <summary>伤害补偿反弹</summary>
    Compensation = 40,
    /// <summary>物理伤害削减</summary>
    CutAtkDamage = 41,
    /// <summary>法术伤害削减</summary>
    CutMgcDamage = 42,
    /// <summary>全伤害削减</summary>
    CutAllDamage = 43,
    /// <summary>物理伤害屏障</summary>
    LogAtkBarrier = 44,
    /// <summary>法术伤害屏障</summary>
    LogMgcBarrier = 45,
    /// <summary>全伤害屏障</summary>
    LogAllBarrier = 46,
    /// <summary>禁止行动</summary>
    PauseAction = 47,
    /// <summary>大招专属沉默</summary>
    UbSilence = 48,
    /// <summary>法术易伤</summary>
    MagicDark = 49,
    /// <summary>治疗量降低</summary>
    HealDown = 50,
    /// <summary>NPC专属眩晕</summary>
    NpcStun = 51,
    /// <summary>治疗衰减</summary>
    DecreaseHeal = 52,
    /// <summary>行为触发型中毒</summary>
    PoisonByBehaviour = 53,
    /// <summary>晶化禁锢</summary>
    Crystalize = 54,
    /// <summary>物理伤害上限限制</summary>
    DamageLimitAtk = 55,
    /// <summary>法术伤害上限限制</summary>
    DamageLimitMgc = 56,
    /// <summary>全伤害上限限制</summary>
    DamageLimitAll = 57,
    /// <summary>第二层眩晕叠加</summary>
    Stun2 = 58,
    /// <summary>二层中毒叠加</summary>
    Poison2 = 59,
    /// <summary>二层诅咒叠加</summary>
    Curse2 = 60,
    /// <summary>二层混乱叠加</summary>
    Confusion2 = 61,
    /// <summary>二层受伤无僵直</summary>
    NoDamageMotion2 = 62,
    /// <summary>二层再生</summary>
    Regeneration2 = 63,
    /// <summary>二层临时再生</summary>
    TpRegeneration2 = 64,
    /// <summary>可叠加减速</summary>
    SlowOverlap = 65,
    /// <summary>可叠加加速</summary>
    HasteOverlap = 66,
    /// <summary>侦察/暴露隐身</summary>
    Spy = 67,
    /// <summary>能量伤害减免</summary>
    EnergyDamageReduce = 68,
    /// <summary>黑屏镜头效果</summary>
    BlackFrame = 69,
    /// <summary>异常状态免疫护盾</summary>
    UnableStateGuard = 70,
    /// <summary>浮空/飞行状态</summary>
    Flight = 71,
    /// <summary>全体敌方累积伤害</summary>
    AccumulativeDamageForAllEnemy = 72,
    /// <summary>全域雷电持续伤害</summary>
    WorldLightning = 73,
    /// <summary>法术闪避提升</summary>
    MagicDodge = 74,
    /// <summary>嘲讽强制攻击自身</summary>
    Taunt = 75,
    /// <summary>血量最低锁血下限</summary>
    HpLowerLimit = 76,
    /// <summary>强化锁链禁锢</summary>
    ChainedAcn = 77,
    /// <summary>傀儡控制</summary>
    Puppet = 78
}