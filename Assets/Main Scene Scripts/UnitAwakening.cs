using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAwakening : MonoBehaviour
{
    public GameObject[] MaxArr;
    public GameObject[] XpArr;
    public GameObject[] UnitSR;
    public List<TextMesh> Levellist = new List<TextMesh>();
    public List<SpriteRenderer> Backlist = new List<SpriteRenderer>();
    public List<SpriteRenderer> Unitlist = new List<SpriteRenderer>();
    public List<SpriteRenderer> UnitSRlist = new List<SpriteRenderer>();
    public List<TextMesh> list = new List<TextMesh>();
    public List<string> strings = new List<string>();
    bool istrue2;
    bool istrue3;
    public GameObject upgradeBtn;


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
        if (!istrue2)
        {
            FirstUnitOption();
        }
        for (int i = 0; i < strings.Count; i++)
        {
            if (strings[i] == "FirstUnit")
            {
                upgradeBtn.SetActive(false);
            }
            else
            {
                upgradeBtn.SetActive(true);
            }
        }
    }

    void FirstUnitOption()
    {
        if (CountryCount.instance.countryClearCountP > 0)
        {
            Levellist[0].text = (FirstUnit.instance.levelClass.getLevelC+1).ToString();
            list[0].text = FirstUnit.instance.priceClass.GetPrice.ToString();
        }
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
}
