using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClass
{
    private static int attack;
    public static int attackC;

    public AttackClass(int Attack)
    {
        attack = Attack;
    }
    public void attUpdate()
    {
        attack += attackC;
    }
    public int GetAttack
    {
        get => attack;
    }
    public void AttackPlus(int amount)
    {
        attackC += amount;
    }
}
