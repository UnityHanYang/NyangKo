using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageAnimation : MonoBehaviour
{
    public static StorageAnimation instance;
    public Animator animator;

    private void Awake()
    {
        instance = this;
    }
    public void ClickToAni()
    {
        animator.SetTrigger("OnClick");
    }

    public void ClickToCancel()
    {
        gameObject.SetActive(false);
        animator.SetTrigger("OnState");
    }
}
