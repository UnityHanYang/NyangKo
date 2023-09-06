using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour
{
    public static StorageManager instance;
    public Image iconImg;
    public Image Circle;
    private string[] arr;
    private string[] arr2;
    public Text Level;
    public GameObject animatorO;
    public Text won;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        arr2 = Level.text.Split(" ");
        if (EnemyTowerDestroy.instance.islive && AllyTowerDestroy.instance.islive && MoneyManager.Instance.isClickP2 && !MoneyManager.Instance.isPauseP || int.Parse(arr2[1]) == 8)
        {
            animatorO.SetActive(true);
            iconImg.color = Color.white;
            Circle.color = Color.white;
            StorageAnimation.instance.ClickToAni();
        }else if (!AllyTowerDestroy.instance.islive || !EnemyTowerDestroy.instance.islive)
        {
            StorageAnimation.instance.ClickToCancel();
        }else if (!MoneyManager.Instance.isClickP2)
        {
            if(StorageAnimation.instance != null)
            {
                StorageAnimation.instance.ClickToCancel();
                iconImg.color = new Color(66 / 255f, 66 / 255f, 68 / 255f);
                Circle.color = new Color(65 / 255f, 65 / 255f, 65 / 255f);
            }
        }
    }

    public void ClickToUpgrade()
    {
        if (MoneyManager.Instance.isClickP2 && int.Parse(arr2[1]) < 8 && !MoneyManager.Instance.isPauseP)
        {
            arr = MoneyManager.Instance.money.text.Split("/");
            if (int.Parse(arr2[1]) + 1 == 8)
            {
                arr[0] = (int.Parse(arr[0]) - int.Parse(MoneyManager.Instance.amount.text)).ToString();
                MoneyManager.Instance.amount.text = "MAX";
                won.gameObject.SetActive(false);
            }
            else
            {
                won.gameObject.SetActive(true);
                arr[0] = (int.Parse(arr[0]) - int.Parse(MoneyManager.Instance.amount.text)).ToString();
                MoneyManager.Instance.amount.text = (int.Parse(MoneyManager.Instance.amount.text) + 40).ToString();
            }
            arr[1] = (int.Parse(arr[1]) + 50).ToString();
            Level.text = arr2[0] +" "+ (int.Parse(arr2[1]) + 1).ToString();
            StorageAnimation.instance.ClickToCancel();
            MoneyManager.Instance.money.text = arr[0] + "/" + arr[1];
            iconImg.color = new Color(66 / 255f, 66 / 255f, 68 / 255f);
            Circle.color = new Color(65 / 255f, 65 / 255f, 65 / 255f);
            MoneyManager.Instance.isClickP2 = false;
        }
    }
}
