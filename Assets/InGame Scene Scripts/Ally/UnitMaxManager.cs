using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaxManager : MonoBehaviour
{
    public static UnitMaxManager instance;
    public Animator animator;

    private void Awake()
    {
        instance = this;
    }
    public void UnitMax()
    {
        animator.SetTrigger("OnClick");
    }
    public void BackState()
    {
        animator.gameObject.SetActive(false);
        animator.SetTrigger("OnState");
    }
}
