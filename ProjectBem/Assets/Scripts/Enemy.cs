using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health; // Spawner������ int
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;
    

    bool isLive; //���� ������Ʈ�� ������ �� ��

    Rigidbody2D rigid;
    Collider2D coll;
    Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive)
            return; //�� ���°� �ƴϸ� �� �Ʒ� ����

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);   //�÷��̾��� Ű�Է� ���� ���� �̵� = ������ ���� ���� ���� �̵�
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) // ����߰ų�, �ǰ� �ִϸ��̼� ȣ������ �ƴ� ���(?)
            return; //�� ���°� �ƴϸ� �� �Ʒ� ����

        spriter.flipX = target.position.x < rigid.position.x; // ��ǥ�� x�� ���� �ڽ��� x�� ���� ��, ������ true
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); //������ �� �÷��̾ Ÿ��
        isLive = true;
        coll.enabled = true;      
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;

    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType]; //animationController���� �ޱ�(������Ʈ)
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isLive)
            return;
        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack()); // �˹� �ڷ�ƾ ����

        if(health >0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            isLive = false;
            coll.enabled = false;       // �ݶ��̴� ��Ȱ��
            rigid.simulated = false;    // ���� �ù� ��Ȱ��
            spriter.sortingOrder = 1;   // ���̾� �� �ܰ� ������
            anim.SetBool("Dead", true);
            //�ִϸ��̼��� Dead�Լ� ����
            GameManager.instance.kill++;    // ų �� ����
            GameManager.instance.GetExp();  // ����ġ ���� (�ӽ�) --> ų �� ����ġ ���� ������ �װ� ȹ��� ����ġ ������ �ٲ� ����
        }
    }

    //�˹� �ڷ�ƾ
    IEnumerator KnockBack()
    {

        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized*3, ForceMode2D.Impulse);
        /*
        yield return null; // 1������ ����
        yield return new WaitForSeconds(2f); // 2�� ����
        */
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
