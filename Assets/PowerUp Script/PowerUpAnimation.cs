using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimation : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        PowerButtonAnimation();
    }
    public void PowerButtonAnimation()
    {
        animator.SetTrigger("OnAnimation");
    }

    public void OnState()
    {
        animator.SetTrigger("OnState");
    }
}
