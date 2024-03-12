using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.2f)
        {
            GameManager.instance.pool.Get(1);
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,2)); //몬스터 종류 개수
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //0은 부모 개체인 자기 자신
    }
}
