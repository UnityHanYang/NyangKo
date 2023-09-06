using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAnimation : MonoBehaviour
{
    public Animator animator;
    public static VictoryAnimation instance;

    private void Awake()
    {
        instance = this;
    }

    public void FadeAnimation()
    {
        animator.SetTrigger("OnFade");
    }

    public void StateAnimation()
    {
        animator.SetTrigger("OnState");
    }
}
