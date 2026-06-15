using System.Collections.Generic;

public class StateMachine
{
    private BaseState currentState;
    private Dictionary<StateType, BaseState> states = new();
    private UnitCtrl unit;

    public StateMachine(UnitCtrl unit)
    {
        this.unit = unit;
        states.Add(StateType.RunGameStart, new RunGameStartState(this, unit));
        states.Add(StateType.StandBy, new StandByState(this, unit));
        states.Add(StateType.Run, new RunState(this, unit));
        states.Add(StateType.Idle, new IdleState(this, unit));
        states.Add(StateType.Action, new ActionState(this, unit));
        states.Add(StateType.Ub, new UbState(this, unit));
    }

    public void OnTick() => currentState.OnTick();

    public void CheckSwitchState() => currentState.CheckSwitchState();

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