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

                //펫을 해금하는 기능 필요
                //int pet에 담은 숫자에 해당하는 펫을 리스트에서 뽑아 가져오기

            }
            else if (rand >= 10 && rand < 30)
            {
                grade = "Rare";
                int pet = Random.Range(0, RPetList.Count);

                //펫을 해금하는 기능 필요
                //int pet에 담은 숫자에 해당하는 펫을 리스트에서 뽑아 가져오기

            }
            else
            {
                grade = "Common";
                getPerk = Random.Range(0, 5);
                PlayerPrefs.SetInt("SavePerk", PlayerPrefs.GetInt("SavePerk") + getPerk);  //GameManager에서 적용한 퍽을 저장소에 더함

                //획득한 퍽을 표시할 거 필요

            }
            SaveData.instance.gem -= 1;
            PlayerPrefs.SetInt("SaveGem", SaveData.instance.gem);
            print("1회 뽑기 성공!");
        }
        else
        {
            NoHaveGem();
        }
    }
    public void NoHaveGem()
    {
        print("젬 없어서 못뽑음 나중에 UI로 띄울 것");
    }
}
