public class IdleState : BaseState
{
    private bool isUb;
    private float waitTimer;

    public IdleState(StateMachine stateMachine, UnitCtrl unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.PlayAnim(unit.GetAnimName("idle"), true);

        if (unit.Skill.TryGetUbSkill())
        {
            isUb = true;
            waitTimer = unit.Skill.PendingSkill?.DefaultCastTime ?? 1.5f;
            return;
        }

        isUb = false;
        unit.Skill.PendingSkill = unit.Skill.AdvanceSequence() ?? unit.Skill.Attack;
        waitTimer = unit.Skill.PendingSkill?.DefaultCastTime ?? 0f;
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

        // UB 时跳过待机直接进入动作
        stateMachine.SwitchState(isUb ? StateType.Ub : StateType.Action);
    }
}
