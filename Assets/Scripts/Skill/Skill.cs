using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
    public bool IsPrincessForm;
    private List<ActionParameter> actionParameters;
    public List<ActionParameterOnPrefab> ActionParametersOnPrefab;
    public List<NormalSkillEffect> SkillEffects;
    public List<ShakeEffect> ShakeEffects;
    public List<BlurEffect.BlurEffectData> BlurEffects;
    public BattleDefine.ZoomEffect ZoomEffect;
    public BattleDefine.SlowEffect SlowEffect;
    public bool ForcePlayNoTarget;
    public int ParameterTarget;
    public int SkillId;
    public float skillAreaWidth;
    public bool Cancel;
    public bool DisableOtherCharaOnStart;
    private List<SkillEffectCtrl> effectObjs;
    private List<SkillEffectCtrl> loopEffectObjs;
    public float BlackOutTime;
    public bool BlackoutEndWithMotion;
    public bool ForceComboDamage;
    public Color BlackoutColor;
    public float CutInMovieFadeStartTime;
    public float CutInMovieFadeDurationTime;
    public float CutInSkipTime;
    public bool ForceCutinOff;
    public int Level;
    public string SkillName;
    public List<int> BranchIds;
    public List<Skill> OverrideSkillList;
    public List<ActionParameter> ActionParameters { get; set; }
    public float CastTime { get; set; }
    public float UnionBurstCoolDownTime { get; set; }
    public int Slot { get; set; }
    public int SkillNum { get; set; }
    public List<SkillEffectCtrl> EffectObjs { get; }
    public List<SkillEffectCtrl> LoopEffectObjs { get; }
    public List<int> HasParentIndexes { get; set; }
    public Vector3 OwnerReturnPosition { get; set; }
    public bool IsModeChange { get; set; }
    public Dictionary<UnitCtrl, double> AccumulatedTpRecovery { get; set; }
    public long AccumulatedLifeSteal { get; set; }
    public bool UseAccumulatedDamage { get; set; }
    public int DefeatEnemyCount { get; set; }
    public bool DefeatByThisSkill { get; set; }
    public bool AlreadyAddAttackSelfSeal { get; set; }
    public bool AlreadyExexActionByHit { get; set; }
    public bool AlreadyAddAttackSealForAllEnemy { get; set; }
    public int LifeSteal { get; set; }
    public bool CountBlind { get; set; }
    public int EffectBranchId { get; set; }
    public bool HasAttack { get; set; }
    public bool LoopEffectAlreadyDone { get; set; }
    public long TotalDamage { get; set; }
    public double AweValue { get; set; }
    public bool IsLifeStealEnabled { get; set; }
    public long AbsorberValue { get; set; }
    public int BonusId { get; set; }

    public SkillDataConfig Data { get; set; }

    public string AnimName { get; set; }

    public string DisplayName => !string.IsNullOrEmpty(SkillName) ? SkillName : Data?.name;

    /// <summary>优先取 Data.skill_cast_time，若 Data 为 null（如普攻）则回退到 CastTime（来自 normal_atk_cast_time）。</summary>
    public float DefaultCastTime => Data?.skill_cast_time ?? CastTime;

    public void SetLevel(int _level)
    {
        Level = _level;
    }

    public float GetFirstExecTime()
    {
        if (ActionParametersOnPrefab == null) return 0f;

        foreach (var action in ActionParametersOnPrefab)
        {
            if (action.Details == null) continue;
            foreach (var detail in action.Details)
            {
                if (detail.ExecTimeForPrefab != null && detail.ExecTimeForPrefab.Count > 0)
                    return detail.ExecTimeForPrefab[0].Time;
            }
        }
        return 0f;
    }

    /// <summary>获取 (frame, actionId) 调度表。空列表 = 无 Prefab 数据，需走 CSV 回退。</summary>
    public List<(int frame, int actionId)> GetExecSchedule()
    {
        var schedule = new List<(int frame, int actionId)>();
        if (ActionParametersOnPrefab == null) return schedule;

        foreach (var action in ActionParametersOnPrefab)
        {
            if (action.Details == null) continue;
            foreach (var detail in action.Details)
            {
                if (detail.ExecTimeForPrefab == null) continue;
                int actionId = detail.ActionId;
                foreach (var et in detail.ExecTimeForPrefab)
                {
                    int frame = Mathf.RoundToInt(et.Time * 60f);
                    schedule.Add((frame, actionId));
                }
            }
        }
        schedule.Sort((a, b) => a.frame.CompareTo(b.frame));
        return schedule;
    }

    public void ReadySkill() { }
}
