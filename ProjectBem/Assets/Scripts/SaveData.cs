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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // È®ÀÎ¿ë
        // PlayerPrefs.SetInt("SavePerk", 1);
        perk = perk + PlayerPrefs.GetInt("SavePerk");
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("SavePerk", 0);
        perk = 0;
    }

    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }
}
