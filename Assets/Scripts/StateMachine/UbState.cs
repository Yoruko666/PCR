using Spine;

public class UbState : BaseState
{
    private Skill ubSkill;
    private float elapsedTime;
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
        unit.PlayAnim($"{unit.UnitId}_skill0", false);

        if (ubSkill.Data != null && !string.IsNullOrEmpty(ubSkill.Data.name))
            unit.ShowBubble(ubSkill.Data.name);

        elapsedTime = 0;
        effectsApplied = false;
        animDone = false;
        unit.spine.AnimationState.Complete += OnUbAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedTime += BattleManager.TickTime;

        if (!effectsApplied)
        {
            unit.Skill.ApplyPendingEffects(ubSkill, elapsedTime);
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
        if (ubSkill != null && trackEntry.Animation.Name == $"{unit.UnitId}_skill0")
            animDone = true;
    }
}
