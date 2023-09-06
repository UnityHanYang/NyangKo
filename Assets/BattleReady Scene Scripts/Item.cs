using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Button Lock;
    [SerializeField] private Button snip;
    [SerializeField] private Button computer;
    [SerializeField] private Button storage;
    [SerializeField] private Button treasure;
    [SerializeField] private Button speed;
    [SerializeField] private Image comImg;
    [SerializeField] private Image storImg;
    [SerializeField] private Text storText;
    [SerializeField] private Text treaText;
    [SerializeField] private Image speedImg;
    [SerializeField] private Text speedTextS;
    [SerializeField] private Text speedTextU;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    private bool isClick = false;
    private bool isClick2 = false;
    private bool isClick3 = false;
    private bool isClick4 = false;
    private bool isClick5 = false;
    private bool isClick6 = false;
    public void LockClick()
    {
        if (!isClick)
        {
            Lock.image.color = new Color(197 / 255f, 133 / 255f, 0f);
            isClick = true;
        }
        else
        {
            Lock.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick = false;
        }
    }
    public void Sniping()
    {
        if (!isClick2 && int.Parse(text1.text.Split("x")[1]) > 0)
        {
            snip.image.color = new Color(169 / 255f, 59 / 255f, 232 / 255f);
            isClick2 = true;
        }
        else
        {
            snip.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            isClick2 = false;
        }
    }
    public void Computer()
    {
        if (!isClick3 && int.Parse(text2.text.Split("x")[1]) > 0)
        {
            computer.image.color = new Color(171 / 255f, 171 / 255f, 171 / 255f);
            comImg.color = Color.white;
            isClick3 = true;
        }
        else
        {
            computer.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            comImg.color = new Color(96 / 255f, 96 / 255f, 96 / 255f);
            isClick3 = false;
        }
    }
    public void Storage()
    {
        if (!isClick4 && int.Parse(text3.text.Split("x")[1]) > 0)
        {
            storage.image.color = new Color(246 / 255f, 247 / 255f, 21 / 255f);
            storImg.color = Color.white;
            storText.color = new Color(1f, 211 / 255f, 0f, 1f);
            isClick4 = true;
        }
        else
        {
            storage.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            storImg.color = new Color(132 / 255f, 132 / 255f, 132 / 255f);
            storText.color = new Color(1f, 211 / 255f, 0f, 168/255f);
            isClick4 = false;
        }
    }
    public void Treasure()
    {
        if (!isClick5 && int.Parse(text4.text.Split("x")[1]) > 0)
        {
            treasure.image.color = new Color(202 / 255f, 160 / 255f, 0f);
            treaText.color = new Color(236/255f, 87 / 255f, 7/255f, 1f);
            isClick5 = true;
        }
        else
        {
            treasure.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            treaText.color = new Color(236 / 255f, 87 / 255f, 7 / 255f, 168 / 255f);
            isClick5 = false;
        }
    }
    public void Speed()
    {
        if (!isClick6 && int.Parse(text5.text.Split("x")[1]) > 0)
        {
            speed.image.color = new Color(197 / 255f, 242 / 255f, 72 / 255f);
            speedImg.color = new Color(1f, 1f, 1f);
            speedTextS.color = new Color(138 / 255f, 217 / 255f, 92 / 255f, 1f);
            speedTextU.color = new Color(1f, 1f, 1f, 1f);
            isClick6 = true;
        }
        else
        {
            speed.image.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            speedImg.color = new Color(106 / 255f, 106 / 255f, 106 / 255f);
            speedTextS.color = new Color(138 / 255f, 217 / 255f, 92 / 255f, 168/255f);
            speedTextU.color = new Color(1f, 1f, 1f, 168/255f);
            isClick6 = false;
        }
    }
}
