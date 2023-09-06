using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirstUnitAnimation
{
    private Animator animator;

    public EnemyFirstUnitAnimation(Animator ani)
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
