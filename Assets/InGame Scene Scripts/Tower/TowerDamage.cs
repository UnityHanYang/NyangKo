using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour
{
    public static TowerDamage instance;
    public TextMesh tm;
    private int n;
    public int m;
    public Animator animator;
    public AudioSource audioS;
    private int dam;

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

    void StateAnimation()
    {
        animator.SetTrigger("OnState");
    }
    public void EndAnimation()
    {
        animator.SetTrigger("End");
    }
}
