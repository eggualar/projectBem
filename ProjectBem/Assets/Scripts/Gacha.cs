using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{

    public List<GameObject> UPetList = new List<GameObject>();
    public List<GameObject> RPetList = new List<GameObject>();

    [HideInInspector]
    public string grade;
    [HideInInspector]
    public int getPerk;

    public void TenGacha()
    {
        if (SaveData.instance.gem >= 10) {
            for (int i = 0; i < 10; i++) {
                GoGacha();
            }
        }
        else {
            NoHaveGem();
            return; }
    }
    public void GoGacha()
    {
        if (SaveData.instance.gem >= 1)
        {
            int rand = Random.Range(0, 100);

            if (rand < 10)
            {
                grade = "Unique";
                int pet = Random.Range(0, UPetList.Count);

                //���� �ر��ϴ� ��� �ʿ�
                //int pet�� ���� ���ڿ� �ش��ϴ� ���� ����Ʈ���� �̾� ��������

            }
            else if (rand >= 10 && rand < 30)
            {
                grade = "Rare";
                int pet = Random.Range(0, RPetList.Count);

                //���� �ر��ϴ� ��� �ʿ�
                //int pet�� ���� ���ڿ� �ش��ϴ� ���� ����Ʈ���� �̾� ��������

            }
            else
            {
                grade = "Common";
                getPerk = Random.Range(0, 5);
                PlayerPrefs.SetInt("SavePerk", PlayerPrefs.GetInt("SavePerk") + getPerk);  //GameManager���� ������ ���� ����ҿ� ����

                //ȹ���� ���� ǥ���� �� �ʿ�

            }
            SaveData.instance.gem -= 1;
            PlayerPrefs.SetInt("SaveGem", SaveData.instance.gem);
            print("1ȸ �̱� ����!");
        }
        else
        {
            NoHaveGem();
        }
    }
    public void NoHaveGem()
    {
        print("�� ��� ������ ���߿� UI�� ��� ��");
    }
}
