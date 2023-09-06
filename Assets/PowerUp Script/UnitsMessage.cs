using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitsMessage : MonoBehaviour
{
    public GameObject[] gameArr;
    public Text text;
    public GameObject upgradeBtn;
    private string[] strArr = new string[] { "�������� ������ �⺻ ĳ����", "��ü�� ���� ĳ����\n���ݷ��� ������ �� ���� (��������)", "������ ĳ����\n���� ���� ��û ���ϴ�", "�ָ� �ִ� ���� ���� ������ ���Ÿ��� ĳ����\n�ܹ��� ���ݷ��� ����Ŭ����" };
    
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
