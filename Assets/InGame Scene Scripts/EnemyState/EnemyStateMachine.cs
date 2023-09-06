using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public IState CurrentStatet { get; private set; }

    public EnemyStateMachine(IState defaultState)
    {
        CurrentStatet = defaultState;
    }
    public void SetState(IState state)
    {

        CurrentStatet.OperateExit();

        CurrentStatet = state;

        CurrentStatet.OperateEnter();
    }

    public void DoOperateUpdate()
    {
        CurrentStatet.OperateUpdate();
    }
}
