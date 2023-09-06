using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OnMatch : MonoBehaviour
{
    public static OnMatch instance;
    public GameObject gameO;
    private GameObject[] countryGo;
    private GameObject[] countryGo2;
    private GameObject[] countryGo3;
    private GameObject[] valueOb;
    private int num;
    public string str;
    public int n;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        valueOb = GameObject.FindGameObjectsWithTag("Value");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        countryGo = GameObject.FindGameObjectsWithTag("Country");

        GameObject go = collision.transform.parent.gameObject;

        for (int i = 0; i < countryGo.Length; i++)
        {
            if (countryGo[i].name == go.name)
            {
                num = i + 1;
            }
        }

        str = go.name;
        TextMesh tm = valueOb[num - 1].GetComponent<TextMesh>();
        n = -int.Parse(tm.text);
    }

}
