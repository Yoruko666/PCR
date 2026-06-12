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
    public Skill MainSkill1 => skill1;
    public Skill MainSkill2 => skill2;

    private Dictionary<int, int> actionTriggerIndex = new();
    private int popupIndex;

    public SkillManager(BaseUnit owner, int ubSkillId, int skill1Id, int skill2Id)
    {
        this.owner = owner;

        ubSkill = LoadSkill(ubSkillId);
        skill1 = LoadSkill(skill1Id);
        skill2 = LoadSkill(skill2Id);
        attack = LoadAttack();

        var patterns = GetAttackPatterns();
        if (patterns.Count > 0)
        {
            var pattern = patterns[0];
            var slotValues = new List<int>
            {
                pattern.atk_pattern_1, pattern.atk_pattern_2, pattern.atk_pattern_3,
                pattern.atk_pattern_4, pattern.atk_pattern_5, pattern.atk_pattern_6,
                pattern.atk_pattern_7, pattern.atk_pattern_8, pattern.atk_pattern_9,
                pattern.atk_pattern_10, pattern.atk_pattern_11, pattern.atk_pattern_12,
                pattern.atk_pattern_13, pattern.atk_pattern_14, pattern.atk_pattern_15,
                pattern.atk_pattern_16, pattern.atk_pattern_17, pattern.atk_pattern_18,
                pattern.atk_pattern_19, pattern.atk_pattern_20
            };

            startSeq = string.Concat(slotValues.Take(pattern.loop_start - 1).Select(v => MapPatternSlot(v)));
            loopSeq = string.Concat(slotValues.Skip(pattern.loop_start - 1).Take(pattern.loop_end - pattern.loop_start + 1).Select(v => MapPatternSlot(v)));
            fullSeq = startSeq + loopSeq;
        }
        else
        {
            startSeq = loopSeq = "";
            fullSeq = "";
        }

        seqIndex = 0;
    }

    public bool IsAttack(Skill skill) => skill == attack;

    private Skill LoadSkill(int skillId)
    {
        if (skillId <= 0) return null;
        var data = ConfigManager.Instance.GetSkillData(skillId);
        if (data == null) return null;
        return new Skill
        {
            Data = data,
            Actions = ConfigManager.Instance.GetSkillActions(skillId)
        };
    }

    private Skill LoadAttack()
    {
        var action = new SkillAction
        {
            action_id = 0,
            action_type = 1,       
            action_value_1 = 100,   
            action_value_2 = 0,    
            target_type = 1,        
            target_count = 1,
        };
        return new Skill { Actions = new List<SkillAction> { action } };
    }

    private List<UnitAttackPattern> GetAttackPatterns()
    {
        var result = new List<UnitAttackPattern>();
        // 查找该角色所有 pattern
        int baseId = owner.UnitId;
        for (int pid = baseId * 100 + 1; ; pid++)
        {
            var p = ConfigManager.Instance.GetAttackPattern(pid);
            if (p != null && p.unit_id == baseId)
                result.Add(p);
            else
                break;
        }
        return result;
    }

    private char MapPatternSlot(int slotValue)
    {
        return slotValue switch
        {
            1    => 'A',          // 普攻
            1001 => '1',          // 技能槽1
            1002 => '2',          // 技能槽2
            _    => 'A',
        };
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

    public void ResetAppliedEffects()
    {
        actionTriggerIndex.Clear();
        popupIndex = 0;
    }

    public void ApplyPendingEffects(Skill skill, float elapsedTime)
    {
        if (skill?.Actions == null) return;

        var timingData = ConfigManager.Instance.GetSkillTimeData(owner.UnitId);
        var execTimes = GetExecTimes(skill, timingData);

        foreach (var action in skill.Actions)
        {
            int idx = actionTriggerIndex.GetValueOrDefault(action.action_id, 0);
            var times = GetExecTimeList(action.action_id, execTimes);
            if (times == null || idx >= times.Length) continue;

            float triggerTime = times[idx];
            // 飞行特效自身的发射延迟
            if (NeedsProjectile(skill, action, timingData))
                triggerTime += GetProjectileExecDelay(action, timingData);
            if (elapsedTime < triggerTime) continue;

            // 检查是否需要生成飞行物
            if (NeedsProjectile(skill, action, timingData))
            {
                SpawnProjectile(action, skill, timingData);
                actionTriggerIndex[action.action_id] = idx + 1;
                popupIndex++;
            }
            else
            {
                ApplyActionEffect(action, popupIndex);
                actionTriggerIndex[action.action_id] = idx + 1;
                popupIndex++;
            }
        }
    }

    public bool AllEffectsApplied(Skill skill)
    {
        if (skill?.Actions == null) return true;

        var timingData = ConfigManager.Instance.GetSkillTimeData(owner.UnitId);
        var execTimes = GetExecTimes(skill, timingData);

        foreach (var action in skill.Actions)
        {
            var times = GetExecTimeList(action.action_id, execTimes);
            int totalTriggers = times?.Length ?? 1;
            int applied = actionTriggerIndex.GetValueOrDefault(action.action_id, 0);
            if (applied < totalTriggers) return false;
        }
        return true;
    }

    public void ApplyActionEffect(SkillAction action, int popupIdx)
    {
        ApplyAction(action, popupIdx);
    }

    private bool NeedsProjectile(Skill skill, SkillAction action, UnitSkillTimeData timingData)
    {
        // 有无特效数据决定是否生成飞行物
        return timingData?.actionEffectDic != null &&
               timingData.actionEffectDic.ContainsKey(action.action_id);
    }

    private float GetProjectileExecDelay(SkillAction action, UnitSkillTimeData timingData)
    {
        if (timingData?.actionEffectDic == null) return 0;
        if (!timingData.actionEffectDic.TryGetValue(action.action_id, out var effects) || effects.Count == 0)
            return 0;
        var effectData = effects[0];
        return effectData.execTime != null && effectData.execTime.Length > 0 ? effectData.execTime[0] : 0;
    }

    private void SpawnProjectile(SkillAction action, Skill skill, UnitSkillTimeData timingData)
    {
        var target = GetSingleTarget();
        if (target == null) return;

        float moveRate = 30f;
        float hitDelay = 0;

        if (timingData?.actionEffectDic != null && timingData.actionEffectDic.TryGetValue(action.action_id, out var effects) && effects.Count > 0)
        {
            moveRate = effects[0].moveRate;
            hitDelay = effects[0].hitDelay;
        }

        BattleManager.Instance.SpawnProjectile(owner, target, action, skill, this, moveRate, hitDelay, popupIndex);
    }

    private BaseUnit GetSingleTarget()
    {
        return BattleManager.Instance.GetOppositeUnits(owner.CampType)
            .OrderBy(e => System.Math.Abs(e.LogicX - owner.LogicX))
            .FirstOrDefault();
    }


    private Dictionary<int, float[]> GetExecTimes(Skill skill, UnitSkillTimeData timingData)
    {
        if (timingData == null) return null;

        if (IsAttack(skill)) return timingData.actionExecTime_Attack;
        if (skill == ubSkill) return timingData.actionExecTime_UB;
        if (skill == skill1) return timingData.actionExecTime_MainSkill1;
        if (skill == skill2) return timingData.actionExecTime_MainSkill2;
        return null;
    }

    private float[] GetExecTimeList(int actionId, Dictionary<int, float[]> execTimes)
    {
        if (execTimes == null) return null;
        execTimes.TryGetValue(actionId, out var times);
        // 普攻 execTime key 可能为 1，兼容
        if (times == null && actionId == 0)
            execTimes.TryGetValue(1, out times);
        return times;
    }

    private void ApplyAction(SkillAction action, int popupIndex)
    {
        var targets = GetTargets(action.target_type, action.target_count, action.target_range, action.target_area);
        switch (action.action_type)
        {
            case 1: // 物理伤害
            {
                int damage = (int)(owner.PhysicalAttack * action.action_value_1 / 100f + action.action_value_2);
                foreach (var t in targets)
                    t.TakeDamage(damage, popupIndex);
                break;
            }
            case 2: // 魔法伤害
            {
                int damage = (int)(owner.MagicAttack * action.action_value_1 / 100f + action.action_value_2);
                foreach (var t in targets)
                    t.TakeDamage(damage, popupIndex);
                break;
            }
            case 3: // 回复
            {
                int amount = (int)(owner.PhysicalAttack * action.action_value_1 / 100f + action.action_value_2);
                foreach (var t in targets)
                    t.Heal(amount);
                break;
            }
            case 4: // TP 回复
                owner.AddTP((int)action.action_value_1);
                break;
        }
    }

    private List<BaseUnit> GetTargets(int targetType, int targetCount, int targetRange, int targetArea)
    {
        var battle = BattleManager.Instance;
        return targetType switch
        {
            1 => new() { GetNearestEnemy() },
            2 => battle.GetOppositeUnits(owner.CampType),
            3 => new() { owner },
            4 => battle.GetAllies(owner.CampType),
            _ => new() { GetNearestEnemy() },
        };
    }

    private BaseUnit GetNearestEnemy()
    {
        return BattleManager.Instance.GetOppositeUnits(owner.CampType)
            .OrderBy(e => System.Math.Abs(e.LogicX - owner.LogicX))
            .FirstOrDefault();
    }
}
