using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //메모리에 바로 GameManager를 저장해 다른 스크립트에서 참조할 수 있음

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
