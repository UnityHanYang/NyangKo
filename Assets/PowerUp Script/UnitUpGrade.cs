using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitUpGrade : MonoBehaviour
{
    public static UnitUpGrade instance;
    public AudioSource audioS;
    private bool istrue = true;
    public GameObject[] LevelArr;
    public GameObject[] BackArr;
    public GameObject[] MaxArr;
    public GameObject[] XpArr;
    public GameObject[] UnitSR;
    public List<TextMesh> Levellist = new List<TextMesh>();
    public  List<SpriteRenderer> Backlist = new List<SpriteRenderer>();
    public List<SpriteRenderer> Unitlist = new List<SpriteRenderer>();
    public List<SpriteRenderer> UnitSRlist = new List<SpriteRenderer>();
    public List<TextMesh> list = new List<TextMesh>();
    public GameObject ani;
    public List<string> strings = new List<string>();
    bool istrue2;
    bool istrue3;
    string str = "FirstUnit";

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UnitSR = GameObject.FindGameObjectsWithTag("Awakening");
        for (int i = 0; i < UnitSR.Length; i++)
        {
            UnitSRlist.Add(UnitSR[i].GetComponent<SpriteRenderer>());
        }
    }

    private void Update()
    {
        Levellist[0].text = (FirstUnit.instance.levelClass.getLevelC + 1).ToString();
        list[0].text = FirstUnit.instance.priceClass.GetPrice.ToString();
        if (!istrue2)
        {
            FirstUnitOption();
        }
    }

    void FirstUnitOption()
    {
        if (int.Parse(Levellist[0].text) == 10)
        {
            Unitlist[0].sprite = UnitSRlist[0].sprite;
            Backlist[0].color = new Color(240 / 255f, 220 / 255f, 176 / 255f);
            Unitlist[0].color = new Color(1f, 244 / 255f, 230 / 255f);
            MaxArr[0].SetActive(true);
            XpArr[0].SetActive(false);
            if (!istrue3)
            {
                strings.Add("FirstUnit");
                istrue3 = true;
                istrue2 = true;
            }
        }
    }

    public void ClickToUpgrade()
    {
        switch (str)
        {
            case "FirstUnit":
                if (int.Parse(Levellist[0].text) < 10)
                {
                    if (int.Parse(list[0].text) <= XpCanndManager.instance.num)
                    {
                        if (istrue)
                        {
                            audioS.Play();
                            istrue = false;
                        }
                        ani.SetActive(true);
                        UnitUpGradeAnimation.Instance.FadeAnimation();
                        FirstUnit.instance.hpclass.HpPlus(50);
                        FirstUnit.instance.attackClass.AttackPlus(4);
                        FirstUnit.instance.levelClass.LevelPlus(1);
                        FirstUnit.instance.priceClass.PriceUp(300);
                        XpCanndManager.instance.num -= int.Parse(list[0].text);
                        XpManager.instance.XpMinus = int.Parse(list[0].text);
                    }
                }
                break;
            case "SecondUnit":
                break;
            case "ThirdUnit":
                break;
            case "FourthUnit":
                break;
            default:
                break;
        }
    }

}
