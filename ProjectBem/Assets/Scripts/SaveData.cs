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
        // 확인용
        // PlayerPrefs.SetInt("SavePerk", 1);
        PlayerPrefs.SetInt("SavePerk", PlayerPrefs.GetInt("SavePerk")+PlayerPrefs.GetInt("GainPerk"));  //GameManager에서 적용한 퍽을 저장소에 더함
        perk = PlayerPrefs.GetInt("SavePerk");
        print($"SavePerk: {PlayerPrefs.GetInt("SavePerk")}");
        print($"GainPerk: {PlayerPrefs.GetInt("GainPerk")}");
        print($"Perk: {perk}");
    }

    public void Reset()
    {
        //퍽 개수 초기화
        PlayerPrefs.SetInt("SavePerk", 0);
        PlayerPrefs.SetInt("GainPerk", 0);
        perk = 0;

        //퍽 업글 초기화
        PlayerPrefs.SetFloat("BaseDmg", 0);
        PlayerPrefs.SetFloat("BaseSpd", 0);
        PlayerPrefs.SetFloat("BaseMHp", 0);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }


    // 퍽 업그레이드 함수들
    public void BaseDmgUpg()
    {
        //Weapon스크립트
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseDmg", PlayerPrefs.GetFloat("BaseDmg")+ baseDmg);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }

    public void BaseSpdUpg()
    {
        //Gear스크립트, Player스크립트
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseSpd", PlayerPrefs.GetFloat("BaseSpd") + baseSpd);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }
    public void BaseMHpUpg()
    {
        //GameManager스크립트
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseMHp", PlayerPrefs.GetFloat("BaseMHp") + baseMHp);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }
}