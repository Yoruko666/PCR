using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class StandByState : BaseState
{
    private bool standByDone;

    public StandByState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {

    }

    public override void OnEnter()
    {
        unit.PlayAnim(unit.GetAnimName("stand_by"), true);
        standByDone = false;
        unit.spine.AnimationState.Complete += OnStandByComplete;
    }

    public override void OnTick()
    {
    }

    public override void OnExit()
    {

    }

    public override void CheckSwitchState()
    {
        if (standByDone)
        {
            if (!unit.Detect()) stateMachine.SwitchState(StateType.Run);
            else stateMachine.SwitchState(StateType.Idle);
        }
    }

    private void OnStandByComplete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == unit.GetAnimName("stand_by"))
        {
            standByDone = true;
        }
    }
}
