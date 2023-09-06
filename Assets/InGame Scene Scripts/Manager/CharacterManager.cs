using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    public int n;
    private static bool istrue = false;
    private GameObject[] unitBtn;
    public bool istrue2;
    public GameObject canvas;
    private Image img;
    private int num;
    public bool istrueP
    {
        get => istrue;
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        unitBtn = GameObject.FindGameObjectsWithTag("UnitImg");
    }
    public void ClickToFirstUnit()
    {
        for (int i = 0; i < Characters.instance.strList.Count; i++)
        {
            if (Characters.instance.strList[i] == "FirstCharacter")
            {
                if (!MoneyManager.Instance.isPauseP && MoneyManager.Instance.num1P >= int.Parse(Characters.instance.list[i].text) && !UnitManager.Instance.istrue)
                {
                    string[] arr = MoneyManager.Instance.money.text.Split("/");
                    arr[0] = (int.Parse(arr[0]) - int.Parse(Characters.instance.list[i].text)).ToString();
                    MoneyManager.Instance.money.text = arr[0] + "/" + arr[1];
                    img = unitBtn[i].GetComponent<Image>();
                    if (img.sprite.name.Equals("BS Idle"))
                    {
                        n = i;
                    }
                    else
                    {
                        n = i + 1;
                    }
                    num = i;
                    Characters.instance.list[i].gameObject.SetActive(false);
                    Characters.instance.wonList[i].gameObject.SetActive(false);
                    istrue = true;
                    UnitManager.Instance.CreateUnit();
                    Characters.instance.scrollList[i].gameObject.SetActive(true);
                    if (int.Parse(arr[0]) < int.Parse(MoneyManager.Instance.amount.text))
                    {
                        MoneyManager.Instance.isClickP2 = false;
                    }
                }
                else if (!MoneyManager.Instance.isPauseP && MoneyManager.Instance.num1P >= int.Parse(Characters.instance.list[i].text) && UnitManager.Instance.istrue)
                {
                    canvas.SetActive(true);
                    UnitMaxManager.instance.UnitMax();
                }
                break;

            }
        }
    }
    private void Update()
    {
        if (Characters.instance.scrollList[num].size < 1 && istrue && UnitManager.Instance.list.Count < 8)
        {
            istrue2 = false;
            Characters.instance.scrollList[num].size += 0.17f * Time.deltaTime;
        }
        else
        {
            istrue = false;
            istrue2 = true;
            Characters.instance.scrollList[num].size = 0;
            Characters.instance.scrollList[num].gameObject.SetActive(false);
            Characters.instance.list[num].gameObject.SetActive(true);
            Characters.instance.wonList[num].gameObject.SetActive(true);
        }
    }
}
