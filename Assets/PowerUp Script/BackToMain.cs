using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMain : MonoBehaviour
{
    [SerializeField] private Image rightdoor;
    [SerializeField] private Image leftdoor;
    [SerializeField] private Button BattleButton;
    [SerializeField] private Button PowerUpButton;
    [SerializeField] private Button textButton;
    [SerializeField] private Text CatCamp;
    [SerializeField] private Text CatCamp2;
    [SerializeField] private Image Mascot;
    [SerializeField] private Image Copydoor1;
    [SerializeField] private Image Copydoor2;
    [SerializeField] private Button Copybtn1;
    [SerializeField] private Button Copybtn2;
    [SerializeField] private Text CopyCatCamp;
    [SerializeField] private Text CopyCatCamp2;
    [SerializeField] private GameObject gameob;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private Text text;
    public GameObject[] unitArr;
    public float jumpPower;
    private bool istrue = false;
    private bool istrue2 = true;
    private string str = "����� ������ �� �� ȯ����! �Ŀ� �� ȭ�鿡�� ���ο� ĳ���͸� ȹ���ϴ°Ŵٳ�";
    public AudioSource audioS;
    private bool istrue3 = true;
    void Awake()
    {
        text.text = str;
    }
    public void ClickToBack()
    {
        istrue = true;
        if (istrue3)
        {
            audioS.Play();
            istrue3 = false;
        }
        if (istrue)
        {
            StartCoroutine("BackCoroutine");
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
        for(int i = 0; i < unitArr.Length; i++)
        {
            BoxCollider2D box = unitArr[i].GetComponent<BoxCollider2D>();
            box.enabled = false;
        }
        leftdoor.transform.position = Vector3.MoveTowards(leftdoor.transform.position, Copydoor2.transform.position, 25f);
        rightdoor.transform.position = Vector3.MoveTowards(rightdoor.transform.position, Copydoor1.transform.position, 25f);
        yield return new WaitForSeconds(0.1f);
        CatCamp.transform.position = Vector3.MoveTowards(CatCamp.transform.position, CopyCatCamp.transform.position, 21f);
        yield return new WaitForSeconds(0.1f);
        CatCamp2.transform.position = Vector3.MoveTowards(CatCamp2.transform.position, CopyCatCamp2.transform.position, 21f);
        yield return new WaitForSeconds(0.4f);
        BattleButton.transform.position = Vector3.MoveTowards(BattleButton.transform.position, Copybtn1.transform.position, 21f);
        yield return new WaitForSeconds(0.1f);
        JumpMo();
        PowerUpButton.transform.position = Vector3.MoveTowards(PowerUpButton.transform.position, Copybtn2.transform.position, 21f);
        yield return new WaitForSeconds(0.7f);
        gameob.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.6f);
        textButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.15f);
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
