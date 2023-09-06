using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatAnimation : MonoBehaviour
{
    public Animator animator;
    public GameObject go;
    public static DefeatAnimation instance;

    private void Awake()
    {
        instance = this;
    }
    public void FadeInAnimation()
    {
        animator.SetTrigger("FadeIn");
    }
    public void OnStateAnimaion()
    {
        animator.SetTrigger("OnState");
    }

    public void MessageShow()
    {
        go.SetActive(true);
    }
}
