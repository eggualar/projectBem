using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;   //관통
    public float speed; //회전속도

    float timer;
    Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update에서는 deltaTime
                break;
            default:
                timer += Time.deltaTime;
                if(timer> speed)
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
        this.count += count;

        if (id == 0)
            Batch();
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            default:
                speed = 0.3f;
                break;
        }
    }

    void Batch() //생성된 무기를 배치하는 함수
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet;
            
            if(index < transform.childCount)
            {
                bullet = transform.GetChild(index); //기존 오브젝트 활용(자식개체로 가져오기)
            }
            else
            {
                bullet= GameManager.instance.pool.Get(prefabId).transform; //모자란 것은 pool에서 가져옴
                bullet.parent = transform;  //bullet 부모를 자신으로 변경
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity; //위치, 회전값 초기화

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); //데미지, 관통 설정 ( -1 is Infinity Per)
        }
    }

    void Fire()
    {
        // 스캐너에 타겟이 잡히지 않는 경우 실행 안함
        if (!player.scanner.nearestTarget)
            return;

        //총알이 나가는 방향 계산
        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        // Bullet스크립트에 위치와 회전값 전달
        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;   // 쏘는 시작 위치 설정
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, count, dir); //원거리 공격에 맞는 초기화 함수 호출

    }
}
