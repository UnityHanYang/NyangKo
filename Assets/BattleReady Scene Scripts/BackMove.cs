using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMove : MonoBehaviour
{
    public static BackMove instance;
    private static string str;
    public Animator animator;
    public GameObject gm;
    public GameObject go;
    public GameObject go2;
    private GameObject[] Unitimgs;
    private GameObject[] firstUnits;
    private void Awake()
    {
        instance = this;    
    }
    public string strP
    {
        get => str;
        set => str=value;
    }
    public void FadeNextScene()
    {
        animator.SetTrigger("ToClick");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(str);
    }

    public void SceneShow()
    {
        go.SetActive(false);
        go2.SetActive(false);
        gm.SetActive(true);
        Unitimgs = GameObject.FindGameObjectsWithTag("UnitImg");
        firstUnits = GameObject.FindGameObjectsWithTag("EvolUnit");
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
