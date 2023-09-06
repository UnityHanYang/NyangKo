using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RangeClass
{
    private static float range;

    public RangeClass(float Range)
    {
        range = Range;
    }
    public float GetRange
    {
        get => range;
    }
}
