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
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / upLevel),spawnData.Length-1); //FloorToInt(�Ʒ��ڸ� ���� �� float�� Int�� ����) / Mathf.Min(���� ������ ���Ѱ� �̻� �ö��� �ʰ�)

        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0); // �ð��� ���� ���� ���� ����

        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //0�� �θ� ��ü�� �ڱ� �ڽ� ��ġ�� ��ȯ
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
