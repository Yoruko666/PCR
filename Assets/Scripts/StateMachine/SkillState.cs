using Spine;

/// <summary>
/// 技能施放状态：播动画 → 执行效果 → 回Idle
/// </summary>
public class SkillState : BaseState
{
    private Skill currentSkill;
    private bool animDone;

    public SkillState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        currentSkill = unit.Skill.PendingSkill;
        if (currentSkill == null)
        {
            animDone = true;
            return;
        }

        unit.PlayAnim(currentSkill.Config.AnimName, false);
        unit.PlaySound(currentSkill.Config.SoundName);
        unit.ShowBubble(currentSkill.Config.Name);
        animDone = false;
        unit.spine.AnimationState.Complete += OnSkillAnimComplete;
    }

    public override void OnTick()
    {
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
            unit.Skill.ExecuteSkill(currentSkill);

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
