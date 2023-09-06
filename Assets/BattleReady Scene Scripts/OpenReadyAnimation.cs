using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenReadyAnimation : MonoBehaviour
{
    public Animator animator;
    public static OpenReadyAnimation instance;

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
        gameObject.SetActive(false);
        animator.SetTrigger("OnState");
    }
}
