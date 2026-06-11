using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 技能运行时管理器 + 行动序列管理
/// </summary>
public class SkillManager
{
    private BaseUnit owner;

    // 技能缓存
    private Skill ubSkill;
    private Skill skill1;
    private Skill skill2;

    // 行动序列
    private string startSeq;
    private string loopSeq;
    private string fullSeq;
    private int seqIndex;

    /// <summary>当前待施放的技能（由IdleState设置，SkillState消费）</summary>
    public Skill PendingSkill { get; set; }

    public SkillManager(BaseUnit owner, string ubSkillId, string skill1Id, string skill2Id)
    {
        this.owner = owner;

        ubSkill = TryLoadSkill(ubSkillId);
        skill1 = TryLoadSkill(skill1Id);
        skill2 = TryLoadSkill(skill2Id);

        // 初始化行动序列
        startSeq = owner.Config.StartSequence ?? "";
        loopSeq = owner.Config.LoopSequence ?? "";
        fullSeq = startSeq + loopSeq;
        seqIndex = 0;
    }

    private Skill TryLoadSkill(string skillId)
    {
        if (string.IsNullOrEmpty(skillId)) return null;
        var cfg = ConfigManager.Instance.GetSkillConfig(skillId.Trim());
        return cfg != null ? new Skill { Config = cfg } : null;
    }

    // ============ 行动序列 ============

    /// <summary>推进序列，返回下一个动作类型：'A'=普攻, '1'=技能1, '2'=技能2</summary>
    public char AdvanceSequence()
    {
        if (string.IsNullOrEmpty(fullSeq))
            return 'A'; // 无序列则默认普攻

        char action = fullSeq[seqIndex];
        seqIndex++;

        // 到达末尾 → 循环 loopSeq 部分
        if (seqIndex >= fullSeq.Length)
        {
            seqIndex = startSeq.Length;
            if (seqIndex >= fullSeq.Length)
                seqIndex = 0;
        }

        return action;
    }

    public void ResetSequence()
    {
        seqIndex = 0;
    }

    // ============ UB 判定 ============

    /// <summary>检查UB是否就绪，就绪时设置 PendingSkill</summary>
    public bool TryGetUbSkill()
    {
        if (ubSkill == null) return false;
        if (owner.TP < 1000) return false;

        PendingSkill = ubSkill;
        return true;
    }

    // ============ 攻击/受击回调 ============

    public void OnAttackPerformed()
    {
        owner.AddTP(50);
    }

    public void OnHit()
    {
        owner.AddTP(30);
    }

    // ============ 技能执行 ============

    public void ExecuteSkill(Skill skill)
    {
        var cfg = skill.Config;

        // 按序执行效果
        var effects = ConfigManager.Instance.GetSkillEffects(cfg.Id);
        foreach (var effect in effects.OrderBy(e => e.EffectIndex))
            ApplyEffect(effect);
    }

    public void Tick(float deltaTime)
    {
    }

    // ============ 效果执行 ============

    private void ApplyEffect(SkillEffectConfig effect)
    {
        var targets = GetTargets(effect.EffectTarget);
        foreach (var target in targets)
        {
            switch (effect.EffectType)
            {
                case "Damage":
                    int damage = (int)(owner.AttackPower * effect.SkillMulti + effect.EffectValue);
                    target.TakeDamage(damage);
                    break;

                case "Heal":
                    int heal = (int)(owner.AttackPower * effect.SkillMulti + effect.EffectValue);
                    target.Heal(heal);
                    break;
            }
        }
    }

    private List<BaseUnit> GetTargets(string targetType)
    {
        var battle = BattleManager.Instance;
        return targetType switch
        {
            "SingleEnemy" => new() { GetSingleEnemy() },
            "AllEnemies"  => battle.GetOppositeUnits(owner.CampType),
            "Self"        => new() { owner },
            "AllAllies"   => battle.GetAllies(owner.CampType),
            _             => new() { GetSingleEnemy() },
        };
    }

    private BaseUnit GetSingleEnemy()
    {
        return BattleManager.Instance.GetOppositeUnits(owner.CampType)
            .OrderBy(e => System.Math.Abs(e.LogicX - owner.LogicX))
            .FirstOrDefault();
    }
}

public class Skill
{
    public SkillConfig Config { get; set; }
}
