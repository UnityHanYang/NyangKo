using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateDie : IState
{
    public EnemyFirstUnitAnimation enemyfirst = new EnemyFirstUnitAnimation(EnemyFirstUnit.instance.animator);
    public void OperateEnter()
    {
        enemyfirst.DieAnimation();
    }

    public void OperateUpdate()
    {

    }

    public void OperateExit()
    {
    }
}
