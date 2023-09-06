using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReadyManager : MonoBehaviour
{
    public static ReadyManager instance;
    [SerializeField] private Text leadershiptext;
    [SerializeField] private Button battleStart;
    [SerializeField] private Button leadershipAdd;
    [SerializeField] private Text stagechoose;
    [SerializeField] private Text catCamp;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button copyBackBtn;
    [SerializeField] private Text xp;
    [SerializeField] private Image xpImg;
    [SerializeField] private Text xpText;
    [SerializeField] private Button xpAdd;
    [SerializeField] private Text copyXp;
    [SerializeField] private Image copyXpImg;
    [SerializeField] private Text copyXpText;
    [SerializeField] private Button copyXpAdd;
    [SerializeField] private Text canned;
    [SerializeField] private Image cannedImg;
    [SerializeField] private Image cannedTextImg;
    [SerializeField] private Button cannedAdd;
    [SerializeField] private Text copyCanned;
    [SerializeField] private Image copyCannedImg;
    [SerializeField] private Image copyCannedTextImg;
    [SerializeField] private Button copyCannedAdd;
    [SerializeField] private GameObject gameob;
    [SerializeField] private Rigidbody2D rigid;
    private bool istrue = false;
    private bool istrue2 = true;
    public float jumpPower;
    private float leadership;
    private float maxLeadership;
    private float time = 1f;
    private bool istrue3 = false;
    private bool istrue4 = false;
    private List<GameObject> listgame = new List<GameObject>();
    private List<Transform> battlegame = new List<Transform>();
    public GameObject[] game;
    public string str;
    public List<GameObject> list = new List<GameObject>();
    public AudioSource audioS;
    private bool istrue5 = true;
    public GameObject open;
    public Text openText;
    private bool istrue6;
    public Transform CountryChild;
    public TextMesh countryText;
    public bool istrue7;
    private void Awake()
    {
        instance = this;
        leadership = GameManager.instanc.leaderShipP;
        maxLeadership = GameManager.instanc.maxLeaderShipP;
        if (leadership == maxLeadership)
        {
            leadershiptext.color = new Color(0 / 255f, 1f, 38 / 255f);
            leadershiptext.text = leadership.ToString();
        }
        else if (leadership < maxLeadership)
        {
            leadershiptext.text = leadership.ToString();
        }
    }
    private void Start()
    {
        GameObject[] gameOb = GameObject.FindGameObjectsWithTag("Item");
        for(int i = 0; i<gameOb.Length; i++)
        {
            listgame.Add(gameOb[i]);
        }
        for (int i = 0; i < 5; i++) {
            battlegame.Add(GameObject.Find("battleText").transform.GetChild(i));
        }
        game = GameObject.FindGameObjectsWithTag("Country");

    }
    IEnumerator BattleCoroutine()
    {
        while (true)
        {
            battleStart.gameObject.SetActive(false);
            leadershipAdd.gameObject.SetActive(false);
            for (int i = 0; i < listgame.Count; i++)
            {
                listgame[i].gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
            stagechoose.transform.position = Vector3.MoveTowards(stagechoose.transform.position, catCamp.transform.position, 13f);
            backBtn.transform.position = Vector3.MoveTowards(backBtn.transform.position, copyBackBtn.transform.position, 13f);
            xp.transform.position = Vector3.MoveTowards(xp.transform.position, copyXp.transform.position, 13f);
            xpImg.transform.position = Vector3.MoveTowards(xpImg.transform.position, copyXpImg.transform.position, 13f);
            xpText.transform.position = Vector3.MoveTowards(xpText.transform.position, copyXpText.transform.position, 13f);
            xpAdd.transform.position = Vector3.MoveTowards(xpAdd.transform.position, copyXpAdd.transform.position, 13f);
            canned.transform.position = Vector3.MoveTowards(canned.transform.position, copyCanned.transform.position, 13f);
            cannedImg.transform.position = Vector3.MoveTowards(cannedImg.transform.position, copyCannedImg.transform.position, 13f);
            cannedTextImg.transform.position = Vector3.MoveTowards(cannedTextImg.transform.position, copyCannedTextImg.transform.position, 13f);
            cannedAdd.transform.position = Vector3.MoveTowards(cannedAdd.transform.position, copyCannedAdd.transform.position, 13f);
            JumpMo();   
            yield return new WaitForSeconds(0.8f);
            gameob.GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(0.75f);
            for (int i = 0; i < battlegame.Count; i++)
            {
                battlegame[i].gameObject.SetActive(true);
                while (!istrue4)
                {
                    
                    if (battlegame[i].transform.localScale.x >= 0 && battlegame[i].transform.localScale.y >= 0.6 && !istrue3)
                    {
                        battlegame[i].transform.localScale = new Vector3
                        (battlegame[i].transform.localScale.x - 1f * time * Time.deltaTime,
                        battlegame[i].transform.localScale.y - 1f * time * Time.deltaTime, 0);
                    }
                    else
                    {
                        istrue3 = true;
                    }
                    istrue4 = true;
                }
                istrue3 = false;
                istrue4 = false;
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(0.6f);
            istrue7 = true;
            CheckCountryName();
            istrue = false;
        }
    }

    private void CheckCountryName()
    {
        for (int i = 0; i < game.Length; i++)
        {
            if (game[i].name == OnMatch.instance.str)
            {
                BackMove.instance.strP = game[i].name;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].name == game[i].name)
                    {
                        BackMove.instance.gm = list[j];
                    }
                }
                BackMove.instance.FadeNextScene();
            }
        }
    }

    private void JumpMo()
    {
        if (istrue2)
        {
            gameob.GetComponent<BoxCollider2D>().enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            istrue2 = false;
        }
    }
    public void GameStartToClick()
    {
        istrue = true;
        if (OnMatch.instance.str == "Korea")
        {
            if (istrue && leadership >= OnMatch.instance.n)
            {
                if (istrue5)
                {
                    audioS.Play();
                    istrue5 = false;
                }
                StartCoroutine("BattleCoroutine");
            }
        }
        else
        {
            for(int i = 0;i<game.Length; i++)
            {
                if(OnMatch.instance.str == game[i].name)
                {
                    CountryChild = game[i].transform.GetChild(2);
                    countryText = CountryChild.GetComponent<TextMesh>();
                }
            }
            open.SetActive(true);

            openText.text = "현재 "+ countryText.text + "은 개발 중 입니다. 조금 많이 기다려주세요.";

            OpenReadyAnimation.instance.FadeAnimation();

            istrue = false;
        }
    }
    private void Update()
    {
        if (istrue)
        {
           GameStartToClick();
        }
    }
}
