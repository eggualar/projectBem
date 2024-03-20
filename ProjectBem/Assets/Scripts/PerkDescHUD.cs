using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PerkDescHUD : MonoBehaviour
{
    public enum InfoType { Perk, BaseDmg, BaseSpd, BaseMHp } // ������
    public InfoType type;
    Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Perk:
                int curPerk = SaveData.instance.perk;
                myText.text = string.Format("Ư������Ʈ: {0:F0}", curPerk);
                break;

            case InfoType.BaseDmg:
                myText.text = string.Format($"���ݷ� + {SaveData.instance.baseDmg * 100}% \n ����: {PlayerPrefs.GetFloat("BaseDmg") * 100}% \n ����: {SaveData.instance.needPerk}");
                break;

            case InfoType.BaseSpd:
                myText.text = string.Format($"�̵��ӵ� + {SaveData.instance.baseSpd * 100}% \n ����: {PlayerPrefs.GetFloat("BaseSpd") * 100}% \n ����: {SaveData.instance.needPerk}");
                break;

            case InfoType.BaseMHp:
                myText.text = string.Format($"�ִ�ü�� + {SaveData.instance.baseMHp} \n ����: {PlayerPrefs.GetFloat("BaseMHp") * 100}% \n ����: {SaveData.instance.needPerk}");
                break;


        }
    }
}
