using Spine;

public class ActionState : BaseState
{
    private Skill currentSkill;
    private string animName;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    public ActionState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
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

        animName = currentSkill.Config.AnimName;
        unit.PlayAnim(animName, false);
        unit.PlaySound(currentSkill.Config.SoundName);

        if (!unit.Skill.IsAttack(currentSkill) && !string.IsNullOrEmpty(currentSkill.Config.Name))
            unit.ShowBubble(currentSkill.Config.Name);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;
        unit.spine.AnimationState.Complete += OnAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedFrames++;

        if (!effectsApplied)
        {
            unit.Skill.ApplyPendingEffects(currentSkill, elapsedFrames);
            if (unit.Skill.AllEffectsApplied(currentSkill))
                effectsApplied = true;
        }
    }

    public override void OnExit()
    {
        unit.spine.AnimationState.Complete -= OnAnimComplete;
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

    private void OnAnimComplete(TrackEntry trackEntry)
    {
        if (currentSkill != null && trackEntry.Animation.Name == animName)
            animDone = true;
    }
}
