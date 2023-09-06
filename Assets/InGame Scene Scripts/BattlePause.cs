using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattlePause : MonoBehaviour
{
    public Canvas can;
    public Canvas message;
    private bool istrue = false;
    public AudioSource au;
    private bool ischeck = false;
    public Image slash;
    public Slider slider;

    private void Update()
    {
        if (can.gameObject.activeSelf)
        {
            au.volume = slider.value;
        }
    }
    public void OptionOpen()
    {
        if (!MoneyManager.Instance.isPauseP && !istrue) {
            MoneyManager.Instance.isPauseP = true;
            can.gameObject.SetActive(true);
        }
    }

    public void OptionClose()
    {
        if (!istrue)
        {
            MoneyManager.Instance.isPauseP = false;
            can.gameObject.SetActive(false);
        }
    }

    public void Message()
    {
        if (!istrue)
        {
            message.gameObject.SetActive(true);
            istrue = true;
        }
    }
    public void NoClick()
    {
        message.gameObject.SetActive(false);
        istrue = false;
    }

    public void ClickToMute()
    {
        if (!ischeck)
        {
            au.mute = true;
            ischeck = true;
            slash.gameObject.SetActive(true);
        }
        else
        {
            au.mute = false;
            ischeck = false;
            slash.gameObject.SetActive(false);
        }
    }
}
