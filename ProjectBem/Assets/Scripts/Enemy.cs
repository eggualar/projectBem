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
    Animator anim;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return; //�� ���°� �ƴϸ� �� �Ʒ� ����

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);   //�÷��̾��� Ű�Է� ���� ���� �̵� = ������ ���� ���� ���� �̵�
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
            return; //�� ���°� �ƴϸ� �� �Ʒ� ����

        spriter.flipX = target.position.x < rigid.position.x; // ��ǥ�� x�� ���� �ڽ��� x�� ���� ��, ������ true
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); //������ �� �÷��̾ Ÿ��
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType]; //animationController���� �ޱ�(������Ʈ)
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
}
