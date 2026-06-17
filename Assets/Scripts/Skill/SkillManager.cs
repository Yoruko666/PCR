using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager
{
    private UnitCtrl owner;

    private Dictionary<int, Skill> skillMap = new();

    // 攻击序列：存储 pattern_value
    private List<int> startSeq;
    private List<int> loopSeq;
    private List<int> fullSeq;
    private int seqIndex;

    public Skill PendingSkill { get; set; }

    public Skill Attack => skillMap.GetValueOrDefault(1);
    public Skill UB => skillMap.GetValueOrDefault(1000);

    public SkillManager(UnitCtrl owner, UnitSkillDataConfig skillMapData)
    {
        this.owner = owner;

        skillMap[1] = CreateAttackSkill();

        TryAddSkill(1001, skillMapData?.main_skill_1 ?? 0, $"{owner.Id}_skill1");
        TryAddSkill(1002, skillMapData?.main_skill_2 ?? 0, $"{owner.Id}_skill2");
        TryAddSkill(1000, skillMapData?.union_burst ?? 0, $"{owner.Id}_skill0");

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
            Slot = patternKey,
            SkillId = skillId,
            SkillNum = 0,
            Data = data,
            AnimName = animName,
            SkillName = data.name,
        };
    }

    private Skill CreateAttackSkill()
    {
        string se = owner.SeType.ToString("D2");
        var skill = new Skill
        {
            Slot = 1,
            SkillId = 0,
            SkillNum = -1,
            Data = null,
            AnimName = $"{se}_attack",
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
                }
                mainIdx++;
            }
        }
    }

    private int popupIndex;

    public void ResetAppliedEffects()
    {
        popupIndex = 0;
    }

    /// <summary>按 actionId 触发单个效果。</summary>
    public void ApplyAction(Skill skill, int actionId)
    {
        if (actionId == 0)
        {
            var target = GetSingleEnemy();
            if (target != null)
            {
                int atk = owner.PhysicalAttack;
                int damage = Mathf.Max(1, Mathf.FloorToInt(atk * 1.0f + owner.SkillLevel * 0.5f));
                target.TakeDamage(damage, popupIndex, true);
            }
            popupIndex++;
            return;
        }

        var actions = ConfigManager.Instance.GetSkillActions(skill.SkillId);
        foreach (var action in actions)
        {
            if (action.action_id != actionId)
                continue;

            var targetType = (PriorityPattern)action.target_type;
            var targets = GetTargets(targetType, action.target_count, action.target_range);

            switch ((eActionType)action.action_type)
            {
                case eActionType.Attack:
                {
                    int atk = action.action_detail_2 == 2 ? owner.MagicAttack : owner.PhysicalAttack;
                    int damage = Mathf.FloorToInt(atk * action.action_value_1 + action.action_value_2 + owner.SkillLevel * action.action_value_3);
                    foreach (var t in targets)
                        t.TakeDamage(damage, popupIndex, true);
                    break;
                }
                case eActionType.Heal:
                {
                    int healAtk = action.action_detail_2 == 2 ? owner.MagicAttack : owner.PhysicalAttack;
                    int healAmt = Mathf.FloorToInt(healAtk * action.action_value_1 + action.action_value_2);
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
            }
            popupIndex++;
            return;
        }
    }

    /// <summary>无 Prefab 数据时，从 CSV 动作列表按 cast_time 均匀分布生成调度表。</summary>
    public List<(int frame, int actionId)> GetCsvExecSchedule(Skill skill)
    {
        var schedule = new List<(int frame, int actionId)>();
        if (skill == Attack)
        {
            int frame = Mathf.RoundToInt(skill.DefaultCastTime * 60f);
            schedule.Add((frame, 0));
            return schedule;
        }

        var actions = ConfigManager.Instance.GetSkillActions(skill.SkillId);
        if (actions.Count == 0) return schedule;

        float castTime = skill.DefaultCastTime;
        if (castTime <= 0) castTime = 1f;

        int totalFrames = Mathf.RoundToInt(castTime * 60f);
        for (int i = 0; i < actions.Count; i++)
        {
            int frame = (i + 1) * totalFrames / actions.Count;
            schedule.Add((frame, actions[i].action_id));
        }
        return schedule;
    }

    private List<UnitCtrl> GetTargets(PriorityPattern targetType, int targetCount, int range)
    {
        switch (targetType)
        {
            case PriorityPattern.Owner:
                return new() { owner };
            case PriorityPattern.Random:
            case PriorityPattern.Near:
            case PriorityPattern.Forward:
            case PriorityPattern.Back:
                return new() { GetSingleEnemy() };
            case PriorityPattern.HpAsc:
            case PriorityPattern.HpDesc:
            case PriorityPattern.Far:
            default:
                return targetCount > 1
                    ? owner.GetEnemyList()
                        .Where(e => e.IsAlive)
                        .Take(targetCount)
                        .ToList()
                    : new() { GetSingleEnemy() };
        }
    }

    private UnitCtrl GetSingleEnemy()
    {
        return owner.GetEnemyList()
            .Where(e => e.IsAlive)
            .OrderBy(e => System.Math.Abs(e.LogicX - owner.LogicX))
            .FirstOrDefault();
    }
}
