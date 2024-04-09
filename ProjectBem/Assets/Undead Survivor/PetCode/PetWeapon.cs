using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PetWeapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;

    public float speed;
    float timer;

    Pet pet;

    void Awake()
    {
        pet = GetComponentInParent<Pet>();
    }

    void Start()
    {
        Init();
    }

    // Start is called before the first frame update
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                timer += Time.deltaTime;
                if(timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count = count;
        if (id == 0)
            Batch();
    }

    // Update is called once per frame
    void Init()
    {
     switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                speed = 0.3f;
                break;
        }   
    }

    void Batch ()
    {
        for (int index=0; index < count; index++){
            Transform bullet;
                if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.parent = transform;

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count; //삽을 회전
            bullet.Rotate(rotVec); // 각도 계산
            bullet.Translate(bullet.up * 1.5f, Space.World); //이동방향 기준
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); //-1 is infinty per.
        }
    }

    void Fire()
    {
        if (!pet.scanner.nearestTarget)
            return;

        Vector3 targetPos = pet.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;

        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, count, dir); //-1 is infinty per.

    }
}
