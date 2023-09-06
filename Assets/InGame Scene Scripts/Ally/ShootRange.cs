using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRange : MonoBehaviour
{
    public static ShootRange instance;
    public Animator animator;
    public GameObject shoot;

    private void Awake()
    {
        instance = this;
    }

    public void DownAnimation()
    {
        animator.SetTrigger("OnDown");
    }

    public void StateAnimation()
    {
        animator.SetTrigger("OnState");
        shoot.SetActive(false);
    }
}
