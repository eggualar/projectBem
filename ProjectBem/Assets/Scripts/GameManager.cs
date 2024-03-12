using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //�޸𸮿� �ٷ� GameManager�� ������ �ٸ� ��ũ��Ʈ���� ������ �� ����

    public float gameTime;
    public float maxGameTime = 5 * 10f;

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

}
