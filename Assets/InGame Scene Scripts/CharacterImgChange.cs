using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImgChange : MonoBehaviour
{
    private GameObject[] Unitimgs;
    private GameObject[] firstUnits;
    private void Awake()
    {
        Unitimgs = GameObject.FindGameObjectsWithTag("UnitImg");
        firstUnits = GameObject.FindGameObjectsWithTag("EvolUnit"); ;
        if (CountryCount.instance.countryClearCountP > 0)
        {
            if (FirstUnit.instance.levelClass.getLevelC + 1 >= 10)
            {
                Image unitImg = Unitimgs[0].GetComponent<Image>();
                Image changImg = firstUnits[0].GetComponent<Image>();
                unitImg.sprite = changImg.sprite;
            }
        }
    }
}
