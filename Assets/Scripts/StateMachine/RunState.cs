using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {

    }

    public override void OnEnter()
    {
        unit.PlayAnim("01_run", true);
    }

    public override void OnTick()
    {
        unit.Move();
    }

    public override void OnExit()
    {

    }
    public override void CheckSwitchState()
    {
        if (Detect())
        {
            stateMachine.SwitchState(StateType.Attack);
        }
    }

    private bool Detect()
    {
        float selfX = unit.LogicX;
        int dir = unit.XDir;
        int range = unit.AttackRange;

        List<BaseUnit> targets = BattleManager.Instance.GetOppositeUnits(unit.CampType);
        foreach (BaseUnit enemy in targets)
        {
            float enemyX = enemy.LogicX;
            float distance = Mathf.Abs(enemyX - selfX);

            if (distance > range)
                continue;

            bool isFront = dir == 1 ? enemyX > selfX : enemyX < selfX;
            if (isFront)
            {
                return true;
            }
        }
        return false;
    }
}
