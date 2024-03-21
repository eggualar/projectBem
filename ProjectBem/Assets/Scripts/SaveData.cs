using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    [HideInInspector]
    public int perk;
    [SerializeField]
    public float baseDmg;
    public float baseSpd;
    public float baseMHp;
    public int needPerk;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Ȯ�ο�
        // PlayerPrefs.SetInt("SavePerk", 1);
        PlayerPrefs.SetInt("SavePerk", PlayerPrefs.GetInt("SavePerk")+PlayerPrefs.GetInt("GainPerk"));  //GameManager���� ������ ���� ����ҿ� ����
        perk = PlayerPrefs.GetInt("SavePerk");
        print($"SavePerk: {PlayerPrefs.GetInt("SavePerk")}");
        print($"GainPerk: {PlayerPrefs.GetInt("GainPerk")}");
        print($"Perk: {perk}");
    }

    public void Reset()
    {
        //�� ���� �ʱ�ȭ
        PlayerPrefs.SetInt("SavePerk", 0);
        PlayerPrefs.SetInt("GainPerk", 0);
        perk = 0;

        //�� ���� �ʱ�ȭ
        PlayerPrefs.SetFloat("BaseDmg", 0);
        PlayerPrefs.SetFloat("BaseSpd", 0);
        PlayerPrefs.SetFloat("BaseMHp", 0);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }


    // �� ���׷��̵� �Լ���
    public void BaseDmgUpg()
    {
        //Weapon��ũ��Ʈ
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseDmg", PlayerPrefs.GetFloat("BaseDmg")+ baseDmg);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }

    public void BaseSpdUpg()
    {
        //Gear��ũ��Ʈ, Player��ũ��Ʈ
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseSpd", PlayerPrefs.GetFloat("BaseSpd") + baseSpd);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }
    public void BaseMHpUpg()
    {
        //GameManager��ũ��Ʈ
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseMHp", PlayerPrefs.GetFloat("BaseMHp") + baseMHp);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }
}