using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDamage : MonoBehaviour
{
    private static EnemyFirstUnit enemy;
    public static ShootDamage instance;
    public GameObject go;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy = collision.GetComponent<EnemyFirstUnit>();
    }

    public void EnemyHit()
    {
        if (enemy != null)
        {
            enemy.SpeedSlow();
        }
    }
}
