using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedClass
{
    public float speed;

    public SpeedClass(float Speed)
    {
        speed = Speed;
    }
    public float GetSpeed
    {
        get => speed;
    }
}
