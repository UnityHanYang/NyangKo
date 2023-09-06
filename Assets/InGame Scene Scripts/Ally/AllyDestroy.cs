using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDestroy : MonoBehaviour
{
    private FirstUnit unit;

    private void Awake()
    {
        unit = GetComponent<FirstUnit>();
    }
    public void UnitDestroy()
    {
        Destroy(unit.go);
    }
}
