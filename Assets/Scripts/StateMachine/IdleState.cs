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
            waitTimer = unit.Skill.PendingSkill?.Data?.skill_cast_time ?? 1.5f;
            return;
        }

        isUb = false;
        unit.Skill.PendingSkill = unit.Skill.AdvanceSequence() ?? unit.Skill.Attack;
        waitTimer = unit.Skill.IsAttack(unit.Skill.PendingSkill)
            ? unit.Data.normal_atk_cast_time
            : unit.Skill.PendingSkill?.Data?.skill_cast_time ?? 0;
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
