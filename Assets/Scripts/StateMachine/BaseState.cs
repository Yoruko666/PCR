using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected StateMachine stateMachine;
    protected UnitCtrl unit;

    public BaseState(StateMachine stateMachine, UnitCtrl unit)
    {
        this.stateMachine = stateMachine;
        this.unit = unit;
    }

    public abstract void OnEnter();
    public abstract void OnTick();
    public abstract void OnExit();
    public abstract void CheckSwitchState();
}
