using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyFirstUnit : MonoBehaviour
{
    private enum EnemyUnitState
    {
        Idle,
        Move,
        Attack,
        Hit,
        Die
    }
    private EnemyStateMachine EstateMachine;
    private Dictionary<EnemyUnitState, IState> dicState = new Dictionary<EnemyUnitState, IState>();
    public GameObject go;
    public static EnemyFirstUnit instance;
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
    public AudioSource audioS;
    private string str;
    public BoxCollider2D box;
    private float Hpvalue;
    private float nowHp;
    private int a;
    private bool istrue2;
    private bool istrue3;
    private bool istrue4;
    private bool istrue6;
    public bool isdie;
    private float Debufftime;
    private float currenttime = 5f;
    private bool istrue5;
    private float attackspeed;
    private static float speedcopy;
    private FirstUnit firstunit;
    private Rigidbody2D rigidbody2;
    public float speedP
    {
        get => speedcopy;
    }
    private void Awake()
    {
        instance = this;
        hpclass = new HpClass(250);
        attackClass = new AttackClass(20);
        hitBackClass = new HitBackClass(3);
        rangeClass = new RangeClass(1.07f);
        speedClass = new SpeedClass(2f);
        go = gameObject;
        animator = go.GetComponent<Animator>();
        rigidbody2 = go.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Hpvalue = hpclass.GetHp / hitBackClass.GetHitBack;
        nowHp = hpclass.GetHp - Hpvalue;
        box.size = new Vector2(rangeClass.GetRange, 1f);

        IState idle = new EnemyStateIdle();
        IState move = new EnemyStateMove(go);
        IState attack = new EnemyStateAttack();
        IState hit = new EnemyStateHit();
        IState die = new EnemyStateDie();

        dicState.Add(EnemyUnitState.Idle, idle);
        dicState.Add(EnemyUnitState.Move, move);
        dicState.Add(EnemyUnitState.Attack, attack);
        dicState.Add(EnemyUnitState.Hit, hit);
        dicState.Add(EnemyUnitState.Die, die);

        EstateMachine = new EnemyStateMachine(idle);
    }

    public void SpeedSlow()
    {
        speedClass = new SpeedClass(speedClass.GetSpeed / 2);
        istrue5 = true;
    }
    void Update()
    {
        if (go.transform.position.x > 9.2)
        {
            istrue6 = true;
        }
        if (!istrue)
        {
            rigidbody2.constraints &= ~(RigidbodyConstraints2D.FreezePositionX & RigidbodyConstraints2D.FreezePositionY);
        }
        else
        {
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (istrue5)
        {
            attackspeed = 3.2f;
            Debufftime += Time.deltaTime;
            if (Debufftime >= currenttime)
            {
                speedClass = new SpeedClass(2f);
                Debufftime = 0;
                istrue5 = false;
            }
        }
        else
        {
            attackspeed = 1.6f;
        }
        speedcopy = speedClass.GetSpeed;
        if (!AllyTowerDestroy.instance.islive)
        {
            audioS.Stop();
        }
        if (!MoneyManager.Instance.isPauseP)
        {
            EstateMachine.DoOperateUpdate();
            if (!istrue4)
            {
                UnitMove();
            }
            if (FirstUnit.instance != null)
            {
                if (FirstUnit.instance.isdie)
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
            isdie = true;
            StartCoroutine("DieExit");
            istrue4 = true;
        }

        if (FirstUnit.instance != null)
        {
            if(hpclass.GetHp <= 0)
            {
                StartCoroutine("DieExit");
            }
            else if (hpclass.GetHp > 0 && hpclass.GetHp <= nowHp && hpclass.GetHp + FirstUnit.instance.attackClass.GetAttack > nowHp - Hpvalue)
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
            EstateMachine.SetState(dicState[EnemyUnitState.Die]);
            EnemyManager.Instance.list.Remove(gameObject);
            istrue3 = true;
            yield return null;
        }
    }
    IEnumerator HitAtt()
    {
        if (!istrue2)
        {
            EstateMachine.SetState(dicState[EnemyUnitState.Hit]);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            istrue2 = true;
            istrue4 = false;
        }
    }
    private void UnitMove()
    {
        if (!istrue)
        {
            EstateMachine.SetState(dicState[EnemyUnitState.Move]);
        }
        else if (istrue6)
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
            EstateMachine.SetState(dicState[EnemyUnitState.Attack]);
            audioS.Play();
            if (str == "AllyTower")
            {
                TowerDamage.instance.HitTower(attackClass.GetAttack);
            }
            else if (str == "AllyUnit")
            {
                firstunit.hpclass.HpMinus(attackClass.GetAttack);
            }
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            EstateMachine.SetState(dicState[EnemyUnitState.Idle]);
            yield return new WaitForSeconds(attackspeed);
            islife = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AllyUnit" || collision.gameObject.tag == "AllyTower")
        {
            firstunit = collision.gameObject.GetComponent<FirstUnit>();
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
