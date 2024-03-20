using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PerkDescHUD : MonoBehaviour
{
    public enum InfoType { Perk, BaseDmg, BaseSpd, BaseMHp } // 열거형
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
                myText.text = string.Format("특성포인트: {0:F0}", curPerk);
                break;

            case InfoType.BaseDmg:
                myText.text = string.Format($"공격력 + {SaveData.instance.baseDmg * 100}% \n 현재: {PlayerPrefs.GetFloat("BaseDmg") * 100}% \n 가격: {SaveData.instance.needPerk}");
                break;

            case InfoType.BaseSpd:
                myText.text = string.Format($"이동속도 + {SaveData.instance.baseSpd * 100}% \n 현재: {PlayerPrefs.GetFloat("BaseSpd") * 100}% \n 가격: {SaveData.instance.needPerk}");
                break;

            case InfoType.BaseMHp:
                myText.text = string.Format($"최대체력 + {SaveData.instance.baseMHp} \n 현재: {PlayerPrefs.GetFloat("BaseMHp") * 100}% \n 가격: {SaveData.instance.needPerk}");
                break;


        }
    }
}
