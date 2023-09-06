using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootManager : MonoBehaviour
{
    private Image sr;
    public GameObject go;
    public Text shootOkText;
    public Image img;
    private Image colorImg;
    public GameObject animator;
    public GameObject shootRange;
    private void Awake()
    {
        sr = go.GetComponent<Image>();
        colorImg = img.GetComponent<Image>();
    }
    private void Update()
    {
        if (EnemyTowerDestroy.instance.islive && AllyTowerDestroy.instance.islive && !MoneyManager.Instance.isClickP)
        {
            animator.SetActive(true);
            ShootAnimation.instance.AnimatonPlay();
            shootRange.SetActive(true);
            ShootRange.instance.DownAnimation();
            shootOkText.gameObject.SetActive(true);
            colorImg.color = Color.white;
            sr.color = Color.white;
        }else if (!AllyTowerDestroy.instance.islive || !EnemyTowerDestroy.instance.islive)
        {
            if (animator.activeSelf)
            {
                ShootAnimation.instance.AnimatonPause();
            }
        }
    }

    public void ShootClick()
    {
        if (!MoneyManager.Instance.isPauseP)
        {
            ShootRange.instance.StateAnimation();
            AllyTowerShoot.instance.istrue = false;
            AllyTowerShoot.instance.ShootAnimation();
            MoneyManager.Instance.isClickP = true;
            animator.gameObject.SetActive(false);
            ShootAnimation.instance.AnimatonPause();
            shootOkText.gameObject.SetActive(false);
            colorImg.color = new Color(66 / 255f, 66 / 255f, 68 / 255f);
            sr.color = new Color(65 / 255f, 65 / 255f, 65 / 255f);
            MoneyManager.Instance.cooltime.gameObject.SetActive(true);
        }
    }
}
