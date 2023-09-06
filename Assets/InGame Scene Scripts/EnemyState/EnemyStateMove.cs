using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMove : IState
{
    public Vector3 dir;
    private float speed;
    private GameObject ga;
    public EnemyFirstUnitAnimation enemyfirst = new EnemyFirstUnitAnimation(EnemyFirstUnit.instance.animator);

    public EnemyStateMove(GameObject game)
    {
        ga = game;
    }
    public void OperateEnter()
    {
        enemyfirst.OnMoveAnimator();
        dir = Vector3.left;
    }

    public void OperateUpdate()
    {
        speed = EnemyFirstUnit.instance.speedP;
        ga.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void OperateExit()
    {
    }
}
