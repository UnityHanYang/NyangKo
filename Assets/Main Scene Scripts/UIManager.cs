using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
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
    public AudioSource audios;
    private bool istrue = false;
    private bool istrue2 = true;
    private bool istrue3 = true;
    public float jumpPower;
    private string str = "고양이 기지에 온 걸 환영해! 파워 업 화면에서 새로운 캐릭터를 획득하는거다냥";
    private string[] arr = new string[] { "숙제를 빨리 끝내지 않으면 엄마한테 혼난다냥!", "공격력 다운 스킬을 가졌거나 체력이 없어도 생존할 수 있는 적들이 있는 것 같다냥", "'냥코대원' 은 탐험할 때 발굴 아이템을 발견하기 쉽게 서포트 해주는 캐릭터다냥", "울고 싶을 땐 울어도 돼. 도망치고 싶을 땐 도망쳐도 돼. 사람이란 그렇게 강한 동물이 아니니까", "오랫동안 꿈을 그리는 자는 마침내 그 꿈과 닮아가는 법이다냥", "마음을 전하지 않으면 알 수 없다냥", "누구라도 칭찬받으면 기쁜거다냥 가끔씩은 노력하는 모습을 자랑스럽게 내보여도 좋다냥" };
    Vector3 vec = new Vector3();
    public GameObject powerUp;
    void Awake()
    {
        vec = catCamp.transform.position;
        text.text = str;
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
            powerUp.SetActive(false);
            powerUpButton.transform.position = Vector3.MoveTowards(powerUpButton.transform.position, CopyBtn2.transform.position, 19f);
            yield return new WaitForSeconds(0.1f);
            startButton.transform.position = Vector3.MoveTowards(startButton.transform.position, CopyBtn1.transform.position, 19f);
            TextMessage.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.15f);
            Jumpfun();
            yield return new WaitForSeconds(0.6f);
            catCamp.transform.position = Vector3.MoveTowards(catCamp.transform.position, CopyCatCamp.transform.position, 16f);
            leftdoor.transform.position = Vector3.MoveTowards(leftdoor.transform.position, CopyDoor1.transform.position, 24f);
            rightdoor.transform.position = Vector3.MoveTowards(rightdoor.transform.position, CopyDoor2.transform.position, 24f);
            yield return new WaitForSeconds(0.15f);
            CatCamp2.transform.position = Vector3.MoveTowards(CatCamp2.transform.position, vec, 20f);
            yield return new WaitForSeconds(0.4f);
            SceneManager.LoadScene("BattleReady");
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
            audios.Play();
            istrue3 = false;
        }
        if (istrue)
        {
            StartCoroutine("terpCoroutine");
        }
    }
    
    public void TextClick()
    {
        if (!GameExit.instance.isend)
        {
            int num = Random.Range(0, arr.Length);
            text.text = arr[num];
        }
    }
}
