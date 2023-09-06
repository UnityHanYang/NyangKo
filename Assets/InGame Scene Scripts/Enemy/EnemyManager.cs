using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public GameObject[] enemy;
    public GameObject[] unitSpawn;
    public Transform parent;
    public Transform[] trans;
    private float n;
    private bool istrue;
    int delay = 0;
    public List<GameObject> list = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    public void Update()
    {
        if (!istrue)
        {
            delay = Random.Range(14, 18);
            istrue = true;
        }
        n += Time.deltaTime;
        if (EnemyTowerDestroy.instance.islive && !MoneyManager.Instance.isPauseP && n >= delay)
        {
            GameObject go = Instantiate(enemy[0]);
            list.Add(go);
            go.transform.SetParent(parent);
            go.SetActive(true);
            int ran = Random.Range(0, unitSpawn.Length);

            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
            switch (ran)
            {
                case 2:
                    sr.sortingOrder = 3;
                    break;
                case 1:
                    sr.sortingOrder = 2;
                    break;
                case 0:
                    sr.sortingOrder = 1;
                    break;
            }
            go.transform.position = unitSpawn[ran].transform.position;
            n = 0;
            istrue = false;
        }
    }
}
