using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGameStart : BaseState
{
    public RunGameStart(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {

    }

    public override void OnEnter()
    {
        unit.PlayAnim(unit.GetAnimName("run_game_start"), true);
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
            stateMachine.SwitchState(StateType.StandBy);
        }
    }
}
