using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
    // Fields
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

    // Properties
    public List<ActionParameter> ActionParameters { get; set; }
    public float CastTime { get; set; }
    public float UnionBurstCoolDownTime { get; set; }
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

    // ====== 新的 CSV 数据源 ======

    /// <summary>对应的 skill_data.csv 数据。</summary>
    public SkillDataConfig Data { get; set; }

    /// <summary>Spine 动画名，根据技能类型自动推断。</summary>
    public string AnimName { get; set; }

    /// <summary>音效 key。</summary>
    public string SoundName { get; set; }

    /// <summary>显示名（优先用 SkillName，否则用 Data.name）。</summary>
    public string DisplayName => !string.IsNullOrEmpty(SkillName) ? SkillName : Data?.name;

    /// <summary>将 Data.skill_cast_time 作为默认 CastTime。</summary>
    public float DefaultCastTime => Data?.skill_cast_time ?? 0f;

    public void SetLevel(int _level)
    {
        Level = _level;
    }

    /// <summary>从 ActionParametersOnPrefab 获取首次动作时间（秒）。</summary>
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

    /// <summary>从 ActionParametersOnPrefab 获取所有 ExecTime（秒），按帧对齐取整。</summary>
    public List<int> GetExecFrames()
    {
        var frames = new List<int>();
        if (ActionParametersOnPrefab == null) return frames;

        foreach (var action in ActionParametersOnPrefab)
        {
            if (action.Details == null) continue;
            foreach (var detail in action.Details)
            {
                if (detail.ExecTimeForPrefab == null) continue;
                foreach (var et in detail.ExecTimeForPrefab)
                {
                    int frame = Mathf.RoundToInt(et.Time * 60f);
                    if (!frames.Contains(frame))
                        frames.Add(frame);
                }
            }
        }
        frames.Sort();
        return frames;
    }

    public void ReadySkill() { }
}
