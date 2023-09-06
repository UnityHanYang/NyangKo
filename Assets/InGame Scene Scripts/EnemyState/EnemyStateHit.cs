using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHit : IState
{
    public EnemyFirstUnitAnimation enemyfirst = new EnemyFirstUnitAnimation(EnemyFirstUnit.instance.animator);
    public void OperateEnter()
    {
        enemyfirst.HitAnimation();
    }

    public void OperateUpdate()
    {

    }

    public void OperateExit()
    {
    }
}
