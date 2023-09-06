using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyTowerShoot : MonoBehaviour
{
    public Animator animator;
    public static AllyTowerShoot instance;
    public ShootDamage[] sd;
    public ParticleSystem[] ps;
    public bool istrue;

    private void Awake()
    {
        instance = this;
    }

    public void ShootAnimation()
    {
        StartCoroutine("Shoot");
    }
    IEnumerator Shoot()
    {
        ClickToShoot();
        for(int i = 0;i< ps.Length; i++)
        {
            ps[i].Play();
            if (!istrue)
            {
                ShootDamage.instance.EnemyHit();
                istrue = true;
            }
        }
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        OnIdle();
    }

    void ClickToShoot()
    {
        animator.SetTrigger("OnAttack");
    }

    void OnIdle()
    {
        animator.SetTrigger("OnIdle");
    }
}
