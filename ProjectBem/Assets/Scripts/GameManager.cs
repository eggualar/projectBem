using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //메모리에 바로 GameManager를 저장해 다른 스크립트에서 참조할 수 있음
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 5 * 10f;
    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 260, 350, 450, 600 }; //경험치 임시

    [Header("# Game Object")]
    public Player player;
    public PoolManager pool;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++; //경험치 1증가
        if(exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
