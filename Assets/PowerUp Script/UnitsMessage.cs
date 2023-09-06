using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitsMessage : MonoBehaviour
{
    public GameObject[] gameArr;
    public Text text;
    public GameObject upgradeBtn;
    private string[] strArr = new string[] { "저가생산 가능한 기본 캐릭터", "고체력 방어용 캐릭터\n공격력은 새발의 피 정도 (범위공격)", "전투용 캐릭터\n빨간 적에 엄청 강하다", "멀리 있는 적도 공격 가능한 원거리형 캐릭터\n단발의 공격력은 하이클래스" };
    
    void Update()
    {
        for(int i = 0; i < gameArr.Length; i++)
        {
            if (gameArr[i].name == "FirstUnit")
            {
                text.text = strArr[i];
            }
        }
        for(int i = 0; i<UnitUpGrade.instance.strings.Count; i++)
        {
            if (UnitUpGrade.instance.strings[i] == "FirstUnit")
            {
                upgradeBtn.SetActive(false);
            }
            else
            {
                upgradeBtn.SetActive(true);
            }
        }
    }
}
