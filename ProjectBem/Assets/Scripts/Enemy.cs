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
            return; //산 상태가 아니면 이 아래 중지

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);   //플레이어의 키입력 값을 더한 이동 = 몬스터의 방향 값을 더한 이동
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) // 사망했거나, 피격 애니메이션 호출중이 아닌 경우(?)
            return; //산 상태가 아니면 이 아래 중지

        spriter.flipX = target.position.x < rigid.position.x; // 목표의 x축 값과 자신의 x축 값을 비교, 작으면 true
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); //생성될 때 플레이어를 타겟
        isLive = true;
        coll.enabled = true;      
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;

    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType]; //animationController에서 받기(컨포넌트)
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isLive)
            return;
        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack()); // 넉백 코루틴 실행

        if(health >0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            isLive = false;
            coll.enabled = false;       // 콜라이더 비활성
            rigid.simulated = false;    // 물리 시뮬 비활성
            spriter.sortingOrder = 1;   // 레이어 한 단계 내리기
            anim.SetBool("Dead", true);
            //애니메이션이 Dead함수 실행
            GameManager.instance.kill++;    // 킬 수 증가
            GameManager.instance.GetExp();  // 경험치 증가 (임시) --> 킬 시 경험치 구슬 떨구고 그거 획득시 경험치 증가로 바꿀 예정
        }
    }

    //넉백 코루틴
    IEnumerator KnockBack()
    {

        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized*3, ForceMode2D.Impulse);
        /*
        yield return null; // 1프레임 쉬기
        yield return new WaitForSeconds(2f); // 2초 쉬기
        */
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
