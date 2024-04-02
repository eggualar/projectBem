using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    public List<string> UniquePetList = new List<string>() { "¯�� ��", "������ ��" };
    public List<string> RarePetList = new List<string>() { "��", "��2" };

    public string grade;

    public void GoGacha()
    {
        int rand = Random.Range(0, 100);

        if (rand < 10) {
            grade = "Unique";
            int pet = Random.Range(0, UniquePetList.Count);
            return;
        }
        else if (rand >= 10 && rand < 30)
        {
            grade = "Rare";
            return;
        }
        else
        {
            grade = "Common";
            return;
        }    
    }
}
