using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CountryCount : MonoBehaviour
{
    public static CountryCount instance;
    private static int countryClearCount = 0;
    public Transform trans;
    private static List<string> clearCountry = new List<string>();

    public int countryClearCountP
    {
        get
        {
            return countryClearCount;
        }
        set
        {
            countryClearCount += value;
        }
    }

    public List<string> clearCountryP
    {
        get
        {
            return clearCountry;
        }
        set
        {
            clearCountry = value;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        if (countryClearCount > 0)
        {
            for (int i = 0; i < clearCountry.Count; i++)
            {
                ClearCountry.instance.Clear(clearCountry[i]);
            }
        }
        if(countryClearCount > 0)
        {
            trans.position = new Vector3(10.65f, 0f, -10f);
        }
    }
}
