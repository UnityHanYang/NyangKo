using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public StateMachine(IState defaultState)
    {
        CurrentState = defaultState;
    }
    public void SetState(IState state)
    {

        CurrentState.OperateExit();

        CurrentState = state;

        CurrentState.OperateEnter();
    }
    public void DoOperateUpdate()
    {
        CurrentState.OperateUpdate();
    }
}
