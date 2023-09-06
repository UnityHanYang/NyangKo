using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : IState
{
    public Vector3 dir;
    public float speed;
    private GameObject ga;
    public StateMove(GameObject game)
    {
        ga = game;
    }
    public FirstUnitAnimation firstAni = new FirstUnitAnimation(FirstUnit.instance.animator);
    public Evol_FirstUnitAnimation evolAni = new Evol_FirstUnitAnimation(FirstUnit.instance.animator);
    public void OperateEnter()
    {
        if(FirstUnit.instance.levelClass.GetLevel < 10)
        {
            firstAni.OnMoveAnimator();
        }
        else
        {
            evolAni.OnMoveAnimator();
        }
        dir = Vector3.left;
        speed = FirstUnit.instance.speedClass.GetSpeed;
    }
        
    public void OperateUpdate()
    {
        ga.transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void OperateExit()
    {
    }
}
