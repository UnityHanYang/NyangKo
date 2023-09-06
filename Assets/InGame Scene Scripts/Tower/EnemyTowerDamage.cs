using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerDamage : MonoBehaviour
{
    public static EnemyTowerDamage instance;
    public TextMesh tm;
    private int n;
    public int m;
    public AudioSource audioS;
    public Animator animator;
    private int dam;
    private int num;

    private void Awake()
    {
        instance = this;
        n = int.Parse(tm.text.Split("/")[1]);
        m = int.Parse(tm.text.Split("/")[0]);
    }
    void Update()
    {
        if (m > 0)
        {
            tm.text = m + "/" + n;
        }
        else
        {
            tm.text = 0 + "/" + n;
        }

    }

    public void HitTower(int damage)
    {
        if (m > 0)
        {
            StartCoroutine("HitState");
            dam = damage;
            Invoke("DamageAcc", 0.2f);
        }
        else
        {
            StopCoroutine("HitState");
            audioS.Stop();
            EndAnimation();
        }
    }
    void DamageAcc()
    {
        m -= dam;
    }
    IEnumerator HitState()
    {
        HitAnimation();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        StateAnimation();
    }
    void HitAnimation()
    {
        animator.SetTrigger("OnHit");
    }

    public void StateAnimation()
    {
        animator.SetTrigger("OnState");
    }

    public void EndAnimation()
    {
        animator.SetTrigger("End");
    }
}
