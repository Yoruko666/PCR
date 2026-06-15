using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager
{
    private UnitCtrl owner;

    /// <summary>统一技能字典。key = pattern_value（1=普攻, 1001=skill1, 1002=skill2, 1000=UB）。</summary>
    private Dictionary<int, Skill> skillMap = new();

    // 攻击序列：存储 pattern_value
    private List<int> startSeq;
    private List<int> loopSeq;
    private List<int> fullSeq;
    private int seqIndex;

    public Skill PendingSkill { get; set; }

    /// <summary>普攻 Skill。</summary>
    public Skill Attack => skillMap.GetValueOrDefault(1);
    /// <summary>UB Skill。</summary>
    public Skill UB => skillMap.GetValueOrDefault(1000);

    public SkillManager(UnitCtrl owner, UnitSkillDataConfig skillMapData)
    {
        this.owner = owner;

        // 加载普攻
        skillMap[1] = CreateAttackSkill();

        // 加载技能（skill_data）
        TryAddSkill(1001, skillMapData?.main_skill_1 ?? 0, $"{owner.Id}_skill1");
        TryAddSkill(1002, skillMapData?.main_skill_2 ?? 0, $"{owner.Id}_skill2");
        TryAddSkill(1000, skillMapData?.union_burst ?? 0, $"{owner.Id}_skill0");

        // 从 unit_attack_pattern 加载攻击序列
        var pattern = ConfigManager.Instance.GetAttackPatternByUnitId(owner.Id);
        if (pattern != null)
        {
            startSeq = pattern.GetStartSequence();
            loopSeq = pattern.GetLoopSequence();
        }
        else
        {
            startSeq = new List<int>();
            loopSeq = new List<int>();
        }
        fullSeq = new List<int>(startSeq.Concat(loopSeq));
        seqIndex = 0;
    }

    public bool IsAttack(Skill skill) => skill == Attack;

    private void TryAddSkill(int patternKey, int skillId, string animName)
    {
        if (skillId == 0) return;
        var data = ConfigManager.Instance.GetSkillDataConfig(skillId);
        if (data == null)
        {
            Debug.LogWarning($"[SkillManager] 找不到 skill_data: {skillId}");
            return;
        }
        skillMap[patternKey] = new Skill
        {
            SkillId = skillId,
            SkillNum = 0,
            Data = data,
            AnimName = animName,
            SoundName = animName,
        };
    }

    private Skill CreateAttackSkill()
    {
        string se = owner.SeType.ToString("D2");
        var skill = new Skill
        {
            SkillId = 0,
            SkillNum = -1,
            Data = null,
            AnimName = $"{se}_attack",
            SoundName = $"{se}_attack",
        };
        if (owner.DataConfig != null)
            skill.CastTime = owner.DataConfig.normal_atk_cast_time;
        return skill;
    }

    public Skill AdvanceSequence()
    {
        if (fullSeq.Count == 0)
            return Attack;

        if (Attack == null)
            return null;

        if (seqIndex >= fullSeq.Count)
        {
            seqIndex = startSeq.Count;
            if (seqIndex >= fullSeq.Count)
                seqIndex = 0;
        }

        int patternVal = fullSeq[seqIndex];
        seqIndex++;
        return skillMap.GetValueOrDefault(patternVal, Attack);
    }

    public void ResetSequence() => seqIndex = 0;

    public bool TryGetUbSkill()
    {
        var ub = UB;
        if (ub == null || owner.TP < 1000) return false;
        PendingSkill = ub;
        return true;
    }

    /// <summary>获取技能的动画名。优先使用技能自身设定的名称，否则按类型回退。</summary>
    public string GetSkillAnimName(Skill skill)
    {
        if (!string.IsNullOrEmpty(skill.AnimName))
            return skill.AnimName;

        string se = owner.SeType.ToString("D2");
        if (skill == Attack) return $"{se}_attack";
        if (skill == UB)     return $"{owner.Id.ToString()}_skill0";
        return $"{se}_attack";
    }

    public void OnHit() => owner.AddTP(30);

    /// <summary>将 JSON 的 ActionParametersOnPrefab 合并到对应的 Skill 上。</summary>
    public void MergeJsonData(UnitActionController controller)
    {
        if (controller == null) return;

        // 普攻
        if (skillMap.TryGetValue(1, out var atk) && controller.Attack != null)
            atk.ActionParametersOnPrefab = controller.Attack.ActionParametersOnPrefab;

        // UB
        if (skillMap.TryGetValue(1000, out var ub))
        {
            var ubSrc = controller.UnionBurstList?.Count > 0 ? controller.UnionBurstList[0] : null;
            if (ubSrc != null)
            {
                ub.ActionParametersOnPrefab = ubSrc.ActionParametersOnPrefab;
                ub.AnimName = ubSrc.AnimName;
                ub.SoundName = ubSrc.SoundName;
            }
        }

        // 主技能 → 依次匹配 skillMap 中的 skill1(1001)/skill2(1002)
        int mainIdx = 0;
        foreach (var kv in skillMap)
        {
            if (kv.Key == 1 || kv.Key == 1000) continue; // 跳过普攻和UB
            if (mainIdx < controller.MainSkillList.Count)
            {
                var src = controller.MainSkillList[mainIdx];
                if (src != null)
                {
                    kv.Value.ActionParametersOnPrefab = src.ActionParametersOnPrefab;
                    kv.Value.AnimName = src.AnimName;
                    kv.Value.SoundName = src.SoundName;
                }
                mainIdx++;
            }
        }
    }

    private HashSet<int> appliedActionIds = new();
    private int popupIndex;

    public void ResetAppliedEffects()
    {
        appliedActionIds.Clear();
        popupIndex = 0;
    }

    public void ApplyPendingEffects(Skill skill, int elapsedFrames)
    {
        if (skill.Data != null)
        {
            var actions = ConfigManager.Instance.GetSkillActions(skill.SkillId);
            ApplySkillActions(actions);
        }
        else if (skill == Attack && !appliedActionIds.Contains(-1))
        {
            // 普攻：对最近敌人造成一次伤害
            var target = GetSingleEnemy();
            if (target != null)
            {
                int atk = owner.PhysicalAttack;
                int damage = Mathf.Max(1, (int)(atk * 1.0f + owner.SkillLevel * 0.5f));
                target.TakeDamage(damage, popupIndex, true);
            }
            appliedActionIds.Add(-1);
            popupIndex++;
        }
    }

    private void ApplySkillActions(List<SkillActionConfig> actions)
    {
        foreach (var action in actions)
        {
            if (appliedActionIds.Contains(action.action_id))
                continue;

            appliedActionIds.Add(action.action_id);

            var targetType = (eTargetType)action.target_type;
            var targets = GetTargets(targetType, action.target_count, action.target_range);

            switch ((eActionType)action.action_type)
            {
                case eActionType.Attack:
                {
                    int atk = action.action_detail_2 == 2 ? owner.MagicAttack : owner.PhysicalAttack;
                    int damage = (int)(atk * action.action_value_1 + action.action_value_2 + owner.SkillLevel * action.action_value_3);
                    foreach (var t in targets)
                        t.TakeDamage(damage, popupIndex, true);
                    break;
                }
                case eActionType.Heal:
                {
                    int healAtk = action.action_detail_2 == 2 ? owner.MagicAttack : owner.PhysicalAttack;
                    int healAmt = (int)(healAtk * action.action_value_1 + action.action_value_2);
                    foreach (var t in targets)
                        t.Heal(healAmt);
                    break;
                }
                case eActionType.ChargeEnergy:
                    owner.AddTP((int)action.action_value_1);
                    break;
                case eActionType.Knock:
                    foreach (var t in targets)
                    {
                        float knockDist = action.action_value_1;
                        t.SetLogicPosition(t.LogicX + knockDist * owner.XDir);
                    }
                    break;
                default:
                    break;
            }
            popupIndex++;
        }
    }

    public bool AllEffectsApplied(Skill skill)
    {
        if (skill.Data != null)
        {
            var actions = ConfigManager.Instance.GetSkillActions(skill.SkillId);
            return actions.All(a => appliedActionIds.Contains(a.action_id));
        }
        return skill == Attack && appliedActionIds.Contains(-1);
    }

    private List<UnitCtrl> GetTargets(eTargetType targetType, int targetCount, int range)
    {
        switch (targetType)
        {
            case eTargetType.Owner:
                return new() { owner };
            case eTargetType.Random:
            case eTargetType.Near:
            case eTargetType.Forward:
            case eTargetType.Back:
                return new() { GetSingleEnemy() };
            case eTargetType.HpAsc:
            case eTargetType.HpDesc:
            case eTargetType.Far:
            default:
                return targetCount > 1
                    ? BattleManager.Instance.GetOppositeUnits(owner.CampType)
                        .Where(e => e.IsAlive)
                        .Take(targetCount)
                        .ToList()
                    : new() { GetSingleEnemy() };
        }
    }

    private UnitCtrl GetSingleEnemy()
    {
        return BattleManager.Instance.GetOppositeUnits(owner.CampType)
            .Where(e => e.IsAlive)
            .OrderBy(e => System.Math.Abs(e.LogicX - owner.LogicX))
            .FirstOrDefault();
    }
}
