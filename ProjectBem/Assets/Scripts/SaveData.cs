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
    public float baseDamage;
    public float baseSpeed;
    public float baseMaxHp;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Ȯ�ο�
        // PlayerPrefs.SetInt("SavePerk", 1);
        perk = perk + PlayerPrefs.GetInt("SavePerk");
    }

    public void Reset()
    {
        //�� ���� �ʱ�ȭ
        PlayerPrefs.SetInt("SavePerk", 0);
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

    }

    public void BaseSpdUpg()
    {

    }
    public void BaseMHpUpg()
    {

    }
}