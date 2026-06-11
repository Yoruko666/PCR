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
        unit.PlayAnim(unit.GetAnimName("run"), true);
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
        if (unit.Detect())
        {
            stateMachine.SwitchState(StateType.Attack);
        }
    }
}
