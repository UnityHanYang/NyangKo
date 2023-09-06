using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FirstUnit : MonoBehaviour
{
    private enum UnitState
    {
        Idle,
        Move,
        Attack,
        Hit,
        Die
    }
    public StateMachine stateMachine;
    private Dictionary<UnitState, IState> dicState = new Dictionary<UnitState, IState>();
    public GameObject go;
    public static FirstUnit instance;
    public HpClass hpclass;
    public AttackClass attackClass;
    public SpeedClass speedClass;
    public RangeClass rangeClass;
    public HitBackClass hitBackClass;
    public LevelClass levelClass;
    public PriceClass priceClass;
    public bool istrue = false;
    public ParticleSystem ps;
    public Animator animator;
    private bool islife = false;
    public AudioSource audios;
    private string str;
    public BoxCollider2D box;
    private float Hpvalue;
    private float nowHp;
    private int a;
    private bool istrue2;
    private bool istrue3;
    private bool istrue4;   
    private bool istrue5;
    public bool isdie;
    private EnemyFirstUnit enemyunit;
    private Rigidbody2D rigidbody2;
    private void Awake()
    {
        instance = this;

        hpclass = new HpClass(250);
        attackClass = new AttackClass(20);
        hitBackClass = new HitBackClass(3);
        levelClass = new LevelClass(1);
        priceClass = new PriceClass(400);
        rangeClass = new RangeClass(1.07f);
        speedClass = new SpeedClass(2f);
        hpclass.HpUpdate();
        attackClass.attUpdate();
        levelClass.attUpdate();

        go = gameObject;
        animator = go.GetComponent<Animator>();
        rigidbody2 = go.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Hpvalue = hpclass.GetHp / hitBackClass.GetHitBack;
        nowHp = hpclass.GetHp - Hpvalue;
        box.size = new Vector2(rangeClass.GetRange, 1f);

        IState idle = new StateIdle();
        IState move = new StateMove(go);
        IState attack = new StateAttack();
        IState hit = new StateHit();
        IState die = new StateDie();

        dicState.Add(UnitState.Idle, idle);
        dicState.Add(UnitState.Move, move);
        dicState.Add(UnitState.Attack, attack);
        dicState.Add(UnitState.Hit, hit);
        dicState.Add(UnitState.Die, die);


        stateMachine = new StateMachine(idle);
    }

    void Update()
    {
        if (go.transform.position.x < -28.74)
        {
            istrue5 = true;
        }
        if (!istrue)
        {
            rigidbody2.constraints &= ~(RigidbodyConstraints2D.FreezePositionX & RigidbodyConstraints2D.FreezePositionY);
        }
        else
        {
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (!EnemyTowerDestroy.instance.islive)
        {
            audios.Stop();
        }
        if (!MoneyManager.Instance.isPauseP)
        {
            stateMachine.DoOperateUpdate();
            if (!istrue4)
            {
                UnitMove();
            }
            if (EnemyFirstUnit.instance != null)
            {
                if (EnemyFirstUnit.instance.isdie)
                {
                    istrue = false;
                }
            }
            DamageHit();
        }
    }
    private void DamageHit()
    {
        if (hpclass.GetHp <= 0)
        {
            box.enabled = false;
            StartCoroutine("DieExit");
            isdie = true;
            istrue4 = true;
        }

        if (EnemyFirstUnit.instance != null)
        {
            if (hpclass.GetHp <= 0)
            {
                StartCoroutine("DieExit");
            }
            else if (hpclass.GetHp > 0 && hpclass.GetHp <= nowHp && hpclass.GetHp + EnemyFirstUnit.instance.attackClass.GetAttack > nowHp - Hpvalue)
            {
                istrue4 = true;
                nowHp -= Hpvalue;
                istrue2 = false;
                StartCoroutine("HitAtt");
            }
        }
        a = Mathf.Clamp(hpclass.GetHp, 0, hpclass.GetHp);
        hpclass = new HpClass(a);
    }
    IEnumerator DieExit()
    {
        if (!istrue3)
        {
            stateMachine.SetState(dicState[UnitState.Die]);
            UnitManager.Instance.list.Remove(gameObject);
            istrue3 = true;
            yield return null;
        }
    }
    IEnumerator HitAtt()
    {   
        if (!istrue2)
        {
            stateMachine.SetState(dicState[UnitState.Hit]);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            istrue2 = true;
            istrue4 = false;
        }
    }
    private void UnitMove()
    {
        if (!istrue && !istrue5)
        {
            stateMachine.SetState(dicState[UnitState.Move]);
        }else if (istrue5)
        {
            StartCoroutine("DieExit");
        }
        else if(istrue)
        {
            
            StartCoroutine("AttackIdle");
        }
    }
    IEnumerator AttackIdle()
    {
        if (!islife)
        {
            islife = true;
            stateMachine.SetState(dicState[UnitState.Attack]);
            audios.Play();
            if (str == "EnemyTower")
            {
                EnemyTowerDamage.instance.HitTower(attackClass.GetAttack);
            }
            else if (str == "EnemyUnit")
            {
                enemyunit.hpclass.HpMinus(attackClass.GetAttack);
            }
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            stateMachine.SetState(dicState[UnitState.Idle]);
            yield return new WaitForSeconds(1.8f);
            islife = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyUnit" || collision.gameObject.tag == "EnemyTower")
        {
            enemyunit = collision.gameObject.GetComponent<EnemyFirstUnit>();
            str = collision.gameObject.tag;
            istrue = true;
            ps.Stop();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!istrue)
        {
            ps.Play();
        }
    }
}
