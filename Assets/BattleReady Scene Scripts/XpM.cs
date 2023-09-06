using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XpM : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.text = XpManager.instance.xpP.ToString();
    }
}
