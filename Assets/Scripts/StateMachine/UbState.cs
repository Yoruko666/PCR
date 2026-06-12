using Spine;

public class UbState : BaseState
{
    private Skill ubSkill;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    public UbState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.Skill.ResetAppliedEffects();

        ubSkill = unit.Skill.PendingSkill;
        if (ubSkill == null)
        {
            BattleManager.Instance.ResumeAll();
            animDone = true;
            return;
        }

        BattleManager.Instance.PauseAllExcept(unit);
        unit.PlayAnim(ubSkill.Config.AnimName, false);
        unit.PlaySound(ubSkill.Config.SoundName);

        if (!string.IsNullOrEmpty(ubSkill.Config.Name))
            unit.ShowBubble(ubSkill.Config.Name);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;
        unit.spine.AnimationState.Complete += OnUbAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedFrames++;

        if (!effectsApplied)
        {
            unit.Skill.ApplyPendingEffects(ubSkill, elapsedFrames);
            if (unit.Skill.AllEffectsApplied(ubSkill))
            {
                BattleManager.Instance.ResumeAll();
                unit.SpendTP(1000);
                effectsApplied = true;
            }
        }
    }

    public override void OnExit()
    {
        unit.spine.AnimationState.Complete -= OnUbAnimComplete;
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

    private void OnUbAnimComplete(TrackEntry trackEntry)
    {
        if (ubSkill != null && trackEntry.Animation.Name == ubSkill.Config.AnimName)
            animDone = true;
    }
}
