using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;   //����
    public float speed; //ȸ���ӵ�

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
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update������ deltaTime
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

    void Batch() //������ ���⸦ ��ġ�ϴ� �Լ�
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet;
            
            if(index < transform.childCount)
            {
                bullet = transform.GetChild(index); //���� ������Ʈ Ȱ��(�ڽİ�ü�� ��������)
            }
            else
            {
                bullet= GameManager.instance.pool.Get(prefabId).transform; //���ڶ� ���� pool���� ������
                bullet.parent = transform;  //bullet �θ� �ڽ����� ����
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity; //��ġ, ȸ���� �ʱ�ȭ

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); //������, ���� ���� ( -1 is Infinity Per)
        }
    }

    void Fire()
    {
        // ��ĳ�ʿ� Ÿ���� ������ �ʴ� ��� ���� ����
        if (!player.scanner.nearestTarget)
            return;

        //�Ѿ��� ������ ���� ���
        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        // Bullet��ũ��Ʈ�� ��ġ�� ȸ���� ����
        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;   // ��� ���� ��ġ ����
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, count, dir); //���Ÿ� ���ݿ� �´� �ʱ�ȭ �Լ� ȣ��

    }
}