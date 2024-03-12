using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health; // Spawner에서는 int
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    bool isLive; //이후 컴포넌트로 빼든지 할 것

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
            return; //산 상태가 아니면 이 아래 중지

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);   //플레이어의 키입력 값을 더한 이동 = 몬스터의 방향 값을 더한 이동
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
            return; //산 상태가 아니면 이 아래 중지

        spriter.flipX = target.position.x < rigid.position.x; // 목표의 x축 값과 자신의 x축 값을 비교, 작으면 true
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); //생성될 때 플레이어를 타겟
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType]; //animationController에서 받기(컨포넌트)
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
}
