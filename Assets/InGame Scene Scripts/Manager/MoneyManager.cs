using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public Text money;
    public Text cooltime;
    public Text amount;
    private string[] arr;
    private string str;
    private int num1;
    private int num2;
    private float time = 0.2f;
    private float time2 = 1f;
    private float current;  
    private float current2;
    private bool isClick = true;
    private bool isClick2 = false;
    private bool isPause = false;
    private bool isCreate = false;
    private string[] levelArr;

    public int num1P
    {
        get => num1;
        set => num1 -= value;
    }
    public bool isClickP{
        get => isClick;
        set => isClick = value;
    }
    public bool isClickP2
    {
        get => isClick2;
        set => isClick2 = value;
    }
    public bool isPauseP
    {
        get => isPause;
        set => isPause = value;
    }
    public bool isCreateP
    {
        get => isCreate;
        set => isCreate = value;
    }
    private void Awake()
    {
        Instance = this;
        money = GameObject.Find("Money").GetComponent<Text>();
        amount = GameObject.Find("LevelPrice").GetComponent<Text>();
    }
    private void Start()
    {
        num2 = int.Parse(cooltime.text);
    }
    private void Update()
    {
        if (!isPauseP)
        {
            arr = money.text.Split("/");
            str = arr[1];
            num1 = int.Parse(arr[0]);
            current += Time.deltaTime;

            if (current > time && num1 < int.Parse(str))
            {
                num1 += 1;
                money.text = num1 + "/" + str;
                current = 0;
            }

            if (isClick)
            {
                current2 += Time.deltaTime;
                if (current2 > time2 && num2 >0)
                {
                    if (num2 != 0)
                    {
                        num2 -= 1;
                        cooltime.text = num2.ToString();
                    }
                    current2 = 0;
                }
                else if (num2 == 0)
                {
                    isClick = false;
                    cooltime.gameObject.SetActive(false);
                    cooltime.text = "50";
                    num2 = int.Parse(cooltime.text);
                    current2 = 0;
                }
            }
            levelArr = StorageManager.instance.Level.text.Split(" ");
            if (int.Parse(levelArr[1]) < 8 && num1 >= int.Parse(amount.text))
            {
                isClick2 = true;
            }

            for(int i =0;i< Characters.instance.list.Count; i++) 
            {
                if (int.Parse(Characters.instance.list[i].text) <= num1 && !CharacterManager.instance.istrueP)
                {
                    Characters.instance.goList[i].color = Color.white;
                    Characters.instance.imgList[i].color = Color.white;
                }
                else
                {
                    Characters.instance.goList[i].color = new Color(172 / 255f, 172 / 255f, 172 / 255f);
                    Characters.instance.imgList[i].color = new Color(172 / 255f, 172 / 255f, 172 / 255f);
                }
            }
        }
    }
}
