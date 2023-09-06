using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    public static Characters instance;
    private GameObject[] goa;
    private GameObject[] goArr;
    private GameObject[] scrollArr;
    private GameObject[] wonArr;
    public List<Image> goList = new List<Image>();
    public List<Text> list = new List<Text> ();
    public List<Image> imgList = new List<Image>();
    public List<string> strList = new List<string> ();
    public List<Scrollbar> scrollList = new List<Scrollbar> ();
    public List<Text> wonList = new List<Text>();

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        goa = GameObject.FindGameObjectsWithTag("Price");
        goArr = GameObject.FindGameObjectsWithTag("UnitImg");
        scrollArr = GameObject.FindGameObjectsWithTag("Scroll");
        wonArr = GameObject.FindGameObjectsWithTag("Won");
        for(int i = 0;i<goa.Length;i++)
        {
            Text won = wonArr[i].GetComponent<Text>();
            wonList.Add(won);
            Scrollbar sc = scrollArr[i].GetComponent<Scrollbar>();
            scrollList.Add(sc);
            Image parentImg = goa[i].transform.parent.GetComponent<Image>();
            goList.Add(parentImg);
            string str = goa[i].transform.parent.name;
            strList.Add(str);
            Image img = goArr[i].GetComponent<Image>();
            imgList.Add(img);
            Text textObject = goa[i].GetComponent<Text>();
            if (textObject != null)
            {
                list.Add(textObject);
            }
        }
    }
}
