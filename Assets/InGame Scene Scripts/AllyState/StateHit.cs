using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHit : IState
{
    public FirstUnitAnimation firstAni = new FirstUnitAnimation(FirstUnit.instance.animator);
    public Evol_FirstUnitAnimation evolAni = new Evol_FirstUnitAnimation(FirstUnit.instance.animator);
    public void OperateEnter()
    {
        if (FirstUnit.instance.levelClass.GetLevel < 10)
        {
            firstAni.HitAnimation();
        }
        else
        {
            evolAni.HitAnimation();
        }
    }

    public void OperateUpdate()
    {

    }

    public void OperateExit()
    {
    }
}
