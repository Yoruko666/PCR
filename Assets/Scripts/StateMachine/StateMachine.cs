using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private BaseState currentState;
    private Dictionary<StateType, BaseState> states = new();

    private BaseUnit unit;

    public StateMachine(BaseUnit unit)
    {
        this.unit = unit;
        states.Add(StateType.RunGameStart, new RunGameStart(this, unit));
        states.Add(StateType.StandBy, new StandByState(this, unit));
        states.Add(StateType.Run, new RunState(this, unit));
        states.Add(StateType.Idle, new IdleState(this, unit));
        states.Add(StateType.Attack, new AttackState(this, unit));
        states.Add(StateType.Skill, new SkillState(this, unit));
        states.Add(StateType.Ub, new UbState(this, unit));
    }

    public void OnTick()
    {
        currentState.OnTick();
    }

    public void CheckSwitchState()
    {
        currentState.CheckSwitchState();
    }

    public void SwitchState(StateType stateType)
    {
        currentState.OnExit();
        currentState = states[stateType];
        currentState.OnEnter();
    }

    public void SetDefaultState(StateType stateType)
    {
        currentState = states[stateType];
        currentState.OnEnter();
    }
}

public enum StateType
{
    RunGameStart, StandBy, Idle, Run, Attack, Skill, Ub
}