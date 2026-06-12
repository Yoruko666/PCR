public class IdleState : BaseState
{
    private bool isUb;
    private float waitTimer;

    public IdleState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.PlayAnim(unit.GetAnimName("idle"), true);

        if (unit.Skill.TryGetUbSkill())
        {
            isUb = true;
            waitTimer = unit.Skill.PendingSkill.Config.CastTime;
            return;
        }

        isUb = false;
        unit.Skill.PendingSkill = unit.Skill.AdvanceSequence() ?? unit.Skill.Attack;
        waitTimer = unit.Skill.PendingSkill?.Config.CastTime ?? 0;
    }

    public override void OnTick()
    {
        waitTimer -= BattleManager.TickTime;
    }

    public override void OnExit()
    {
    }

    public override void CheckSwitchState()
    {
        if (waitTimer > 0) return;

        if (!unit.Detect() && !isUb)
        {
            stateMachine.SwitchState(StateType.Run);
            return;
        }

        stateMachine.SwitchState(isUb ? StateType.Ub : StateType.Action);
    }
}
