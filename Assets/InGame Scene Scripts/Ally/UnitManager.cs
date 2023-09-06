using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    public GameObject[] unit;
    public GameObject[] unitSpawn;
    public Transform parent;
    public Transform[] trans;
    private int num;
    public bool istrue = false;
    public List<GameObject> list = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    public void CreateUnit()
    {
        if (CharacterManager.instance.istrue2)
        {
            if(list.Count < 8)
            {
                num = CharacterManager.instance.n;
                GameObject go = Instantiate(unit[num]);
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
                istrue = false;
            }
        }
    }

    private void Update()
    {
        if(list.Count >= 8)
        {
            istrue = true;
        }
    }
}
