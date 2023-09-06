using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PowerUpScene : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Image rightdoor;
    [SerializeField] private Image leftdoor;
    [SerializeField] private Button startButton;
    [SerializeField] private Button powerUpButton;
    [SerializeField] private Image TextMessage;
    [SerializeField] private Image Mascot;
    [SerializeField] private Button CopyBtn1;
    [SerializeField] private Button CopyBtn2;
    [SerializeField] private Image CopyDoor1;
    [SerializeField] private Image CopyDoor2;
    [SerializeField] private Text catCamp;
    [SerializeField] private Text CatCamp2;
    [SerializeField] private Text CopyCatCamp;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private GameObject gameob;
    private bool istrue = false;
    private bool istrue2 = true;
    private bool istrue3 = true;
    public float jumpPower;
    Vector3 vec = new Vector3();
    public GameObject Battle;
    public GameObject Battle2;
    public GameObject Battle3;
    public GameObject Battle4;
    public Transform cameraGo;
    public AudioSource audioS;
    void Awake()
    {
        istrue2 = true;
    }

    void Update()
    {
        if (!GameExit.instance.isend && istrue)
        {

            NextScene();
        }
    }
    IEnumerator terpCoroutine()
    {
        while (true)
        {
            Battle.SetActive(false);
            Battle2.SetActive(false);
            Battle3.SetActive(false);   
            Battle4.SetActive(false);
            powerUpButton.transform.position = Vector3.MoveTowards(powerUpButton.transform.position, CopyBtn2.transform.position, 19f);
            yield return new WaitForSeconds(0.1f);
            startButton.transform.position = Vector3.MoveTowards(startButton.transform.position, CopyBtn1.transform.position, 19f);
            TextMessage.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.15f);
            Jumpfun();
            yield return new WaitForSeconds(0.6f);
            catCamp.transform.position = Vector3.MoveTowards(catCamp.transform.position, CopyCatCamp.transform.position, 17f);
            leftdoor.transform.position = Vector3.MoveTowards(leftdoor.transform.position, CopyDoor1.transform.position, 24f);
            rightdoor.transform.position = Vector3.MoveTowards(rightdoor.transform.position, CopyDoor2.transform.position, 24f);
            yield return new WaitForSeconds(0.15f);
            CatCamp2.transform.position = Vector3.MoveTowards(CatCamp2.transform.position, vec, 20f);
            yield return new WaitForSeconds(0.4f);
            SceneManager.LoadScene("PowerUp");
            istrue = false;
        }
    }
    private void Jumpfun()
    {
        if (istrue2)
        {
            gameob.GetComponent<BoxCollider2D>().enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            istrue2 = false;
        }
    }
    public void NextScene()
    {
        istrue = true;
        if (istrue3)
        {
            audioS.Play();
            istrue3 = false;
        }
        if (istrue)
        {
            cameraGo.position = new Vector3(0, 0, -10f);
            StartCoroutine("terpCoroutine");
        }
    }
}
