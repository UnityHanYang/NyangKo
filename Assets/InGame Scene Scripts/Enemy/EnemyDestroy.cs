using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private EnemyFirstUnit unit;

    private void Awake()
    {
        unit = GetComponent<EnemyFirstUnit>();
    }
    public void UnitDestroy()
    {
        string[] arr = MoneyManager.Instance.money.text.Split("/");
        if (int.Parse(arr[0]) + 10 <= int.Parse(arr[1]))
        {
            arr[0] = (int.Parse(arr[0]) + 10).ToString();
            MoneyManager.Instance.money.text = arr[0] + "/" + arr[1];
        }
        Destroy(unit.go);
    }
}
