using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpClass
{
    private int hp;
    public static int hpC;

    public HpClass(int HP)
    {
        hp = HP;
    }
    public int GetHp
    {
        get => hp;
    }
    public void HpUpdate()
    {
        hp += hpC;
    }
    public void HpMinus(int damage)
    {
        hp -= damage;
    }
    public void HpPlus(int amount)
    {
        hpC += amount;
    }
}
