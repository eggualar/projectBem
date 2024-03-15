using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //�޸𸮿� �ٷ� GameManager�� ������ �ٸ� ��ũ��Ʈ���� ������ �� ����
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 5 * 10f;
    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 260, 350, 450, 600 }; //����ġ �ӽ�

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
        exp++; //����ġ 1����
        if(exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
