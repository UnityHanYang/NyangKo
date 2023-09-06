using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAttack : IState
{
    public EnemyFirstUnitAnimation enemyfirst = new EnemyFirstUnitAnimation(EnemyFirstUnit.instance.animator);
    public void OperateEnter()
    {

        enemyfirst.AttackAnimator();
    }

    public void OperateUpdate()
    {

    }

    public void OperateExit()
    {
    }
}
