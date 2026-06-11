using Spine;
using UnityEngine;

/// <summary>
/// Idle 状态 = 行动决策中枢
/// 1. 检查 UB → UbState
/// 2. 否则按序列取下一个动作
/// 3. 等待对应间隔/前摇 → 分发至 Attack / Skill
/// </summary>
public class IdleState : BaseState
{
    private char currentAction; // 'A'=普攻, '1'=技能1, '2'=技能2, 'U'=UB
    private float waitTimer;

    public IdleState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.PlayAnim(unit.GetAnimName("idle"), true);

        // 1. UB 优先级最高
        if (unit.Skill.TryGetUbSkill())
        {
            currentAction = 'U';
            waitTimer = unit.Skill.PendingSkill.Config.CastTime;
            return;
        }

        // 2. 按序列取下一个动作
        currentAction = unit.Skill.AdvanceSequence();

        if (currentAction == 'A')
        {
            waitTimer = unit.Config.AttackInterval;
        }
        else // '1' 或 '2'
        {
            string skillId = currentAction == '1'
                ? unit.Config.Skill1Id
                : unit.Config.Skill2Id;

            var cfg = ConfigManager.Instance.GetSkillConfig(skillId);
            unit.Skill.PendingSkill = cfg != null ? new Skill { Config = cfg } : null;
            waitTimer = cfg?.CastTime ?? 0;
        }
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

        if (!unit.Detect() && currentAction != 'U')
        {
            stateMachine.SwitchState(StateType.Run);
            return;
        }

        switch (currentAction)
        {
            case 'U':
                stateMachine.SwitchState(StateType.Ub);
                break;
            case '1':
            case '2':
                stateMachine.SwitchState(StateType.Skill);
                break;
            case 'A':
                stateMachine.SwitchState(StateType.Attack);
                break;
        }
    }
}
