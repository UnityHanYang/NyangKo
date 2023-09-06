    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUpGradeAnimation : MonoBehaviour
{
    public static UnitUpGradeAnimation Instance;
    public Animator animator;
    private void Awake()
    {
        Instance = this;
    }

    public void FadeAnimation()
    {
        animator.SetTrigger("OnFade");
    }
    public void StateAnimation()
    {
        animator.gameObject.SetActive(false);
        animator.SetTrigger("OnState");
    }
}
