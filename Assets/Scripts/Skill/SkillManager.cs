using System.Collections.Generic;
using System.Linq;

public class SkillManager
{
    private BaseUnit owner;
    private Skill ubSkill;
    private Skill skill1;
    private Skill skill2;
    private Skill attack;

    private string startSeq;
    private string loopSeq;
    private string fullSeq;
    private int seqIndex;

    public Skill PendingSkill { get; set; }
    public Skill Attack => attack;

    public SkillManager(BaseUnit owner, string ubSkillId, string skill1Id, string skill2Id)
    {
        this.owner = owner;
        ubSkill = TryLoadSkill(ubSkillId);
        skill1 = TryLoadSkill(skill1Id);
        skill2 = TryLoadSkill(skill2Id);
        attack = TryLoadSkill(owner.Config.AttackId);

        startSeq = owner.Config.StartSequence ?? "";
        loopSeq = owner.Config.LoopSequence ?? "";
        fullSeq = startSeq + loopSeq;
        seqIndex = 0;
    }

    public bool IsAttack(Skill skill) => skill == attack;

    private Skill TryLoadSkill(string skillId)
    {
        if (string.IsNullOrEmpty(skillId)) return null;
        var cfg = ConfigManager.Instance.GetSkillConfig(skillId.Trim());
        return cfg != null ? new Skill { Config = cfg } : null;
    }

    public Skill AdvanceSequence()
    {
        if (string.IsNullOrEmpty(fullSeq))
            return attack;

        if (attack == null)
            return null;

        var action = fullSeq[seqIndex];
        seqIndex++;

        if (seqIndex >= fullSeq.Length)
        {
            seqIndex = startSeq.Length;
            if (seqIndex >= fullSeq.Length)
                seqIndex = 0;
        }

        return action switch
        {
            'A' => attack,
            '1' => skill1 ?? attack,
            '2' => skill2 ?? attack
        };
    }

    public void ResetSequence() => seqIndex = 0;

    public bool TryGetUbSkill()
    {
        if (ubSkill == null || owner.TP < 1000) return false;
        PendingSkill = ubSkill;
        return true;
    }

    public void OnHit() => owner.AddTP(30);

    private HashSet<int> appliedEffectIndices = new();
    private int popupIndex;

    public void ResetAppliedEffects()
    {
        appliedEffectIndices.Clear();
        popupIndex = 0;
    }

    public void ApplyPendingEffects(Skill skill, int elapsedFrames)
    {
        var effects = GetEffects(skill).OrderBy(e => e.EffectIndex);

        foreach (var effect in effects)
        {
            if (!appliedEffectIndices.Contains(effect.EffectIndex) && elapsedFrames >= effect.CastFrame)
            {
                ApplyEffect(effect, popupIndex);
                appliedEffectIndices.Add(effect.EffectIndex);
                popupIndex++;
            }
        }
    }

    public bool AllEffectsApplied(Skill skill)
    {
        return GetEffects(skill).All(e => appliedEffectIndices.Contains(e.EffectIndex));
    }

    private List<SkillEffectConfig> GetEffects(Skill skill)
    {
        if (skill.Effects != null)
            return skill.Effects;

        var effects = ConfigManager.Instance.GetSkillEffects(skill.Config.Id);
        if (effects.Count > 0)
            return effects;

        return IsAttack(skill) ? ConfigManager.Instance.GetSkillEffects("na_default") : effects;
    }

    private void ApplyEffect(SkillEffectConfig effect, int popupIndex)
    {
        var targets = GetTargets(effect.EffectTarget);
        foreach (var target in targets)
        {
            switch (effect.EffectType)
            {
                case "Damage":
                {
                    int atk = effect.DamageType == "Magic" ? owner.MagicAttack : owner.PhysicalAttack;
                    int damage = (int)(atk * effect.SkillMulti + effect.EffectValue + owner.SkillLevel * effect.SkillLevelMulti);
                    bool showVisual = effect.CastFrame > 0;
                    target.TakeDamage(damage, popupIndex, showVisual);
                    break;
                }
                case "Heal":
                {
                    int atk = effect.DamageType == "Magic" ? owner.MagicAttack : owner.PhysicalAttack;
                    int amount = (int)(atk * effect.SkillMulti + effect.EffectValue + owner.SkillLevel * effect.SkillLevelMulti);
                    target.Heal(amount);
                    break;
                }
                case "AddTP":
                    owner.AddTP((int)effect.EffectValue);
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
            "AllEnemies" => battle.GetOppositeUnits(owner.CampType),
            "Self" => new() { owner },
            "AllAllies" => battle.GetAllies(owner.CampType),
            _ => new() { GetSingleEnemy() },
        };
    }

    private BaseUnit GetSingleEnemy()
    {
        return BattleManager.Instance.GetOppositeUnits(owner.CampType)
            .OrderBy(e => System.Math.Abs(e.LogicX - owner.LogicX))
            .FirstOrDefault();
    }
}
