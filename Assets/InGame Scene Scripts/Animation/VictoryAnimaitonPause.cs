using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAnimaitonPause : MonoBehaviour
{
    public GameObject go;
    public GameObject vic;
    public static VictoryAnimaitonPause instance;
    public bool istrue = false;
    private void Awake()
    {
        instance = this;
    }
    public void ClickToPause()
    {
        istrue = true;
        VictoryAnimation.instance.StateAnimation();
        vic.SetActive(false);
        go.SetActive(true); 
    }
}
