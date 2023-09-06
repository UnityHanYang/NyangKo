using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCountry : MonoBehaviour
{
    public static ClearCountry instance;
    public GameObject[] countryArr;
    public GameObject[] clearArr;
    public  GameObject[] treasureArr;
    private TextMesh clearObject;
    private SpriteRenderer treasureObject;
    public GameObject[] treasuresArr;
    public GameObject[] Country;
    public string s;
    private void Awake()
    {
        instance = this;
    }
    public void Clear(string str)
    {
        GameObject.Find("Country").transform.GetChild(CountryCount.instance.countryClearCountP).gameObject.SetActive(true);
        countryArr = GameObject.FindGameObjectsWithTag("Country");
        clearArr = GameObject.FindGameObjectsWithTag("Clear");
        treasureArr = GameObject.FindGameObjectsWithTag("Treasure");

        s = str;
        for (int i = 0; i < countryArr.Length; i++)
        {
            if (str == countryArr[i].name)
            {
                clearObject = clearArr[i].GetComponent<TextMesh>();
                treasureObject = treasureArr[i].GetComponent<SpriteRenderer>();
                break;
            }
        }

        clearObject.color = new Color(1f, 0f, 0f, 1f);

        if (CountryCount.instance.countryClearCountP == 1)
        {
            treasureObject.sprite = treasuresArr[0].GetComponent<SpriteRenderer>().sprite;
        }
        else if (CountryCount.instance.countryClearCountP > 1)
        {
        }
    }

}
