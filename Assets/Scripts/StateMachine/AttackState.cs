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
        unit.PlayAnim("01_attack", false);
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
            if (!Detect()) stateMachine.SwitchState(StateType.Run);
            else stateMachine.SwitchState(StateType.Attack);
        }
    }

    private void OnAttackComplete(TrackEntry trackEntry)
    {
        if(trackEntry.Animation.Name == "01_attack")
        {
            attackDone = true;
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
