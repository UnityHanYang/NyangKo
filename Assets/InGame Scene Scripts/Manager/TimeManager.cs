using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public float time;
    public float current = 30f;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!MoneyManager.Instance.isPauseP)
        {
            time += Time.deltaTime;

        }
    }
}
