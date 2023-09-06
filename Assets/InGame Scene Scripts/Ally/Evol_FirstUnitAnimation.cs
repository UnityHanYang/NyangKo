using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evol_FirstUnitAnimation
{
    public Animator animator;

    public Evol_FirstUnitAnimation(Animator ani)
    {
        animator = ani;
    }
    public void OnMoveAnimator()
    {
        animator.SetTrigger("doMove");
    }
    public void IdleSetAnimator()
    {
        animator.SetTrigger("doIdle");
    }
    public void AttackAnimator()
    {
        animator.SetTrigger("doAttack");
    }
    public void HitAnimation()
    {
        animator.SetTrigger("doHit");
    }
    public void DieAnimation()
    {
        animator.SetTrigger("doDie");
    }
}
