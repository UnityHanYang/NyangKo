using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTowerDestroy : MonoBehaviour
{
    public static EnemyTowerDestroy instance;
    public GameObject pauseBtn;
    public GameObject copyPauseBtn;
    public GameObject storageBtn;
    public GameObject copyStorageBtn;
    public GameObject shootBtn;
    public GameObject copyShootBtn;
    public GameObject unitBtn;
    public GameObject copyUnitBtn;
    public GameObject money;
    public GameObject copyMoney;
    public Transform cameraT;
    private Vector3 vec;
    public bool islive = true;
    private bool istrue;
    private bool istrue2;
    private bool istrue3;
    public GameObject rangeObject;
    private BoxCollider2D rangeCollider;
    public GameObject capsul;
    public float time;
    private float current = 0.3f;
    private float a = 6f;
    private float b = 6f;
    private float c = 10f;
    private float d = 10f;
    public GameObject victory;
    public GameObject copyVictory;
    public GameObject xpGet;
    public GameObject copyXpGet;
    public GameObject treasure;
    private bool isUp;
    public Text xpValue;
    public Text xp;
    private int count = 0;
    public bool isnew = false;
    public AudioSource audioS;
    private bool istrue4;
    private void Awake()
    {
        instance = this;
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        vec = new Vector3(-20, 0, -10f);
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector3 RandomPostion = new Vector3(range_X, range_Y, 0f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    void TrySpawnObject()
    {
        if (Time.time - time >= current)
        {
            StartCoroutine(RandomRespawn_Coroutine());
            time = Time.time;
        }
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        GameObject instantCapsul = Instantiate(capsul, Return_RandomPosition(), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(instantCapsul);
        yield return null;
    }

    IEnumerator MoveCou()
    {
        yield return new WaitForSeconds(1.2f);
        float x = Mathf.SmoothDamp(victory.transform.position.x, copyVictory.transform.position.x, ref c, 0.2f);
        victory.transform.position = new Vector2(x, victory.transform.position.y);
        yield return new WaitForSeconds(0.3f);
        float x2 = Mathf.SmoothDamp(xpGet.transform.position.x, copyXpGet.transform.position.x, ref d, 0.2f);
        xpGet.transform.position = new Vector2(x2, xpGet.transform.position.y);
        yield return new WaitForSeconds(2f);
        
        if (!VictoryAnimaitonPause.instance.istrue && isnew)
        {
            treasure.SetActive(true);
            VictoryAnimation.instance.FadeAnimation();
        }
    }
    void Update()
    {
        if (EnemyTowerDamage.instance.m <= 0)
        {
            islive = false;
            if (!istrue4)
            {
                audioS.Play();
                istrue4 = true;
            }
            if (!istrue3)
            {
                xp.text = (XpManager.instance.xpP + int.Parse(xpValue.text)).ToString();
                if (cameraT.position == vec)
                {
                    istrue = true;
                }
                else
                {
                    istrue2 = true;
                }
            }
            istrue3 = true;
            if (istrue)
            {
                ObjectsMove();
            }
            else if (istrue2)
            {
                cameraT.position = Vector3.MoveTowards(cameraT.position, vec, 6f);
                Invoke("ObjectsMove", 0.2f);
            }
            TrySpawnObject();
            if (!isUp)
            {
                if (CountryCount.instance.clearCountryP.Count == 0)
                {
                    isnew = true;
                    CountryCount.instance.clearCountryP.Add(BackMove.instance.strP);
                    CountryCount.instance.countryClearCountP = 1;
                }
                else 
                {
                    for (int i = 0; i < CountryCount.instance.clearCountryP.Count; i++)
                    {
                        if (CountryCount.instance.clearCountryP[i] != BackMove.instance.strP)
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        isnew = true;
                        CountryCount.instance.clearCountryP.Add(BackMove.instance.strP);
                        CountryCount.instance.countryClearCountP = 1;
                    }
                    else
                    {
                        VictoryAnimaitonPause.instance.ClickToPause();
                    }
                }
                XpManager.instance.XpPlus = int.Parse(xpValue.text);
                isUp = true;
            }
            StartCoroutine("MoveCou");
        }
    }

    void ObjectsMove()
    {
        pauseBtn.transform.position = Vector3.MoveTowards(pauseBtn.transform.position, copyPauseBtn.transform.position, 7f);
        float y = Mathf.SmoothDamp(storageBtn.transform.position.y, copyStorageBtn.transform.position.y, ref a, 0.4f);
        storageBtn.transform.position = new Vector2(storageBtn.transform.position.x, y);
        float y2 = Mathf.SmoothDamp(shootBtn.transform.position.y, copyShootBtn.transform.position.y, ref b, 0.4f);
        shootBtn.transform.position = new Vector2(shootBtn.transform.position.x, y2);
        money.transform.position = Vector3.MoveTowards(money.transform.position, copyMoney.transform.position, 7f);
        unitBtn.transform.position = Vector3.MoveTowards(unitBtn.transform.position, copyUnitBtn.transform.position, 7f);
    }
}
