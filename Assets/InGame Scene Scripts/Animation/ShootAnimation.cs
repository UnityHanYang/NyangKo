using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnimation : MonoBehaviour
{
    public static ShootAnimation instance;
    public Animator animator;

    private void Awake()
    {
        instance = this;
    }
    public void AnimatonPlay()
    {
        animator.SetTrigger("OnShoot");
    }

    public void AnimatonPause()
    {
        gameObject.SetActive(false);
        animator.SetTrigger("OnState");
    }
}
