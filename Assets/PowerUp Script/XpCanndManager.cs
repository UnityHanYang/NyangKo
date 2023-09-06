using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpCanndManager : MonoBehaviour
{
    public static XpCanndManager instance;
    public Text xp;
    public int num;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        xp.text = XpManager.instance.xpP.ToString();
        num = int.Parse(xp.text);
    }

    private void Update()
    {
        xp.text = num.ToString();
    }
}
