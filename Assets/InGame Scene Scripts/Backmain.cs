using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Backmain : MonoBehaviour
{
    [SerializeField] private Image bottomImg;
    [SerializeField] private Image topImg;
    [SerializeField] private Image rightdoor;
    [SerializeField] private Image leftdoor;
    [SerializeField] private Button BattleButton;
    [SerializeField] private Button PowerUpButton;
    [SerializeField] private Button textButton;
    [SerializeField] private Text CatCamp;
    [SerializeField] private Image Mascot;
    [SerializeField] private Image Copydoor1;
    [SerializeField] private Image Copydoor2;
    [SerializeField] private Button Copybtn1;
    [SerializeField] private Button Copybtn2;
    [SerializeField] private Text CopyCatCamp;
    [SerializeField] private GameObject gameob;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Text text;
    [SerializeField] private Canvas backCanvas;
    [SerializeField] private Canvas copyBackCanvas;
    [SerializeField] private Image copyBottomImg;
    [SerializeField] private Image copyTopImg;
    [SerializeField] private Button buttonCanvas;
    [SerializeField] private Button copyButtonCanvas;
    [SerializeField] private Text canned;
    [SerializeField] private Text copyCanned;
    [SerializeField] private Image img;
    [SerializeField] private Image copyImg;
    [SerializeField] private Image cannedImg;
    [SerializeField] private Image copyCannedImg;
    [SerializeField] private Text xp;
    [SerializeField] private Text copyXp;
    [SerializeField] private Image xpImg;
    [SerializeField] private Image copyXpImg;
    [SerializeField] private Text xpText;
    [SerializeField] private Text copyXpText;
    [SerializeField] private Button xpAdd;
    [SerializeField] private Button copyXpAdd;
    public AudioSource audioS;

    private int num;
    public float jumpPower;
    private bool istrue = false;
    private bool istrue2 = true;
    private string str = "고양이 기지에 온 걸 환영해! 파워 업 화면에서 새로운 캐릭터를 획득하는거다냥";
    void Awake()
    {
        text.text = str;
    }
    private void Start()
    {
        num = OnMatch.instance.n;

        PowerUpButton.gameObject.SetActive(false);
    }
    public void ClickToBack()
    {
        istrue = true;
        if (istrue)
        {
            if (TimeManager.instance.time > TimeManager.instance.current)
            {
                GameManager.instanc.leaderShipP = num;
            }
            TimeManager.instance.time = 0;
            audioS.Stop();
            StartCoroutine("BackCoroutine");
            EnemyTowerDestroy.instance.isnew = false;
            EnemyTowerDestroy.instance.audioS.Stop();
            AllyTowerDestroy.instance.audioS.Stop();
        }
    }
    void Update()
    {
        if (istrue)
        {
            ClickToBack();
        }
    }
    IEnumerator BackCoroutine()
    {
        if (CountryCount.instance.countryClearCountP > 0)
        {
            PowerUpButton.gameObject.SetActive(true);
        }
        leftdoor.transform.position = Vector3.MoveTowards(leftdoor.transform.position, Copydoor2.transform.position, 24f);
        rightdoor.transform.position = Vector3.MoveTowards(rightdoor.transform.position, Copydoor1.transform.position, 24f);
        topImg.transform.position = Vector3.MoveTowards(topImg.transform.position, copyTopImg.transform.position, 24f);
        bottomImg.transform.position = Vector3.MoveTowards(bottomImg.transform.position, copyBottomImg.transform.position, 24f);
        yield return new WaitForSeconds(0.1f);
        backCanvas.transform.position = Vector3.MoveTowards(backCanvas.transform.position, copyBackCanvas.transform.position, 22f);
        CatCamp.transform.position = Vector3.MoveTowards(CatCamp.transform.position, CopyCatCamp.transform.position, 22f);
        buttonCanvas.transform.position = Vector3.MoveTowards(buttonCanvas.transform.position, copyButtonCanvas.transform.position, 22f);
        canned.transform.position = Vector3.MoveTowards(canned.transform.position, copyCanned.transform.position, 22f);
        img.transform.position = Vector3.MoveTowards(img.transform.position, copyImg.transform.position, 22f);
        cannedImg.transform.position = Vector3.MoveTowards(cannedImg.transform.position, copyCannedImg.transform.position, 22f);
        xp.transform.position = Vector3.MoveTowards(xp.transform.position, copyXp.transform.position, 22f);
        xpImg.transform.position = Vector3.MoveTowards(xpImg.transform.position, copyXpImg.transform.position, 22f);
        xpText.transform.position = Vector3.MoveTowards(xpText.transform.position, copyXpText.transform.position, 22f);
        xpAdd.transform.position = Vector3.MoveTowards(xpAdd.transform.position, copyXpAdd.transform.position, 22f);
        yield return new WaitForSeconds(0.5f);
        BattleButton.transform.position = Vector3.MoveTowards(BattleButton.transform.position, Copybtn1.transform.position, 22f);
        yield return new WaitForSeconds(0.1f);
        JumpMo();
        PowerUpButton.transform.position = Vector3.MoveTowards(PowerUpButton.transform.position, Copybtn2.transform.position, 22f);
        yield return new WaitForSeconds(0.7f);
        gameob.GetComponent<BoxCollider2D>().enabled = true;                        
        yield return new WaitForSeconds(0.55f);
        textButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Main");
        istrue = false;
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
}
