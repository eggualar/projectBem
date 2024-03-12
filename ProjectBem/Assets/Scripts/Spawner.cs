using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;
    float upLevel;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        upLevel = 30f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / upLevel),spawnData.Length-1); //FloorToInt(아랫자리 내림 후 float을 Int로 변경) / Mathf.Min(스폰 레벨이 정한거 이상 올라가지 않게)

        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0); // 시간에 따라 몬스터 종류 변경

        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //0은 부모 개체인 자기 자신 위치에 소환
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}
