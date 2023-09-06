using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateIdle : IState
{
    public EnemyFirstUnitAnimation enemyfirst = new EnemyFirstUnitAnimation(EnemyFirstUnit.instance.animator);
    public void OperateEnter()
    {
        enemyfirst.IdleSetAnimator();
    }
    public void OperateUpdate()
    {

    }

    public void OperateExit()
    {
    }
}
