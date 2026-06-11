using Spine;

/// <summary>
/// 技能施放状态：播动画 → 各效果按各自前摇时间依次触发 → 动画播完回Idle
/// </summary>
public class SkillState : BaseState
{
    private Skill currentSkill;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    public SkillState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.Skill.ResetAppliedEffects();

        currentSkill = unit.Skill.PendingSkill;
        if (currentSkill == null)
        {
            animDone = true;
            return;
        }

        unit.PlayAnim(currentSkill.Config.AnimName, false);
        unit.PlaySound(currentSkill.Config.SoundName);
        unit.ShowBubble(currentSkill.Config.Name);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;
        unit.spine.AnimationState.Complete += OnSkillAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedFrames++;

        if (!effectsApplied)
        {
            unit.Skill.ApplyPendingEffects(currentSkill.Config.Id, elapsedFrames);
            if (unit.Skill.AllEffectsApplied(currentSkill.Config.Id))
                effectsApplied = true;
        }
    }

    public override void OnExit()
    {
        unit.spine.AnimationState.Complete -= OnSkillAnimComplete;
        unit.Skill.PendingSkill = null;
    }

    public override void CheckSwitchState()
    {
        if (animDone)
        {
            if (!unit.Detect())
                stateMachine.SwitchState(StateType.Run);
            else
                stateMachine.SwitchState(StateType.Idle);
        }
    }

    private void OnSkillAnimComplete(TrackEntry trackEntry)
    {
        if (currentSkill != null && trackEntry.Animation.Name == currentSkill.Config.AnimName)
            animDone = true;
    }
}
