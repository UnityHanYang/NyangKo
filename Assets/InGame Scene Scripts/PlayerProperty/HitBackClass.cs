using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBackClass
{
    private int hitBack;

    public HitBackClass(int HitBack)
    {
        hitBack = HitBack;
    }
    public int GetHitBack
    {
        get => hitBack;
    }
    public void HitBackCount(int count)
    {
        hitBack -= count;
    }
}
