using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpManager : MonoBehaviour
{
    public static XpManager instance;
    private static int xp = 0;
    public Text text;

    public int XpPlus
    {
        set => xp += value;
    }
    public int XpMinus
    {
        set => xp -= value;
    }

    public int xpP
    {
        get => xp;
        set => xp = value;
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        text.text = xpP.ToString();
    }

}
