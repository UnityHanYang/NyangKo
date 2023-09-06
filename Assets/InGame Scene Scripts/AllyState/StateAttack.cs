using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack :  IState
{
    public FirstUnitAnimation firstAni = new FirstUnitAnimation(FirstUnit.instance.animator);
    public Evol_FirstUnitAnimation evolAni = new Evol_FirstUnitAnimation(FirstUnit.instance.animator);
    public void OperateEnter()
    {
        if (FirstUnit.instance.levelClass.GetLevel < 10)
        {
            firstAni.AttackAnimator();
        }
        else
        {
            evolAni.AttackAnimator();
        }
    }

    public void OperateUpdate()
    {
        
    }

    public void OperateExit()
    {
    }

}
