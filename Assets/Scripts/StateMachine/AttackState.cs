using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class AttackState : BaseState
{
    private bool attackDone;

    public AttackState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.PlayAnim(unit.GetAnimName("attack"), false);
        attackDone = false;
        unit.spine.AnimationState.Complete += OnAttackComplete;
    }
    public override void OnTick()
    {

    }
    public override void OnExit()
    {
        unit.spine.AnimationState.Complete -= OnAttackComplete;
    }
    public override void CheckSwitchState()
    {
        if (attackDone)
        {
            if (!unit.Detect()) stateMachine.SwitchState(StateType.Run);
            else stateMachine.SwitchState(StateType.Idle);
        }
    }

    private void OnAttackComplete(TrackEntry trackEntry)
    {
        if(trackEntry.Animation.Name == unit.GetAnimName("attack"))
        {
            attackDone = true;
            unit.Skill?.OnAttackPerformed();
        }
    }
}
