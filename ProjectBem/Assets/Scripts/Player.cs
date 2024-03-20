using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    public RuntimeAnimatorController[] animCon;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������Ʈ�� �ִ� Rigidbody2D ������
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    private void OnEnable()
    {
        speed *= Character.Speed*(1 + PlayerPrefs.GetFloat("BaseSpd"));
        anim.runtimeAnimatorController = animCon[GameManager.instance.playerId];
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //normalized : ��Ÿ��� ������ ���� �밢�� ���⵵ ���� �ӵ��� �̵��ϰ� ��
        //Time.fixedDeltaTime : ���� ������ �ӵ���ŭ
        rigid.MovePosition(rigid.position+nextVec); // ��ġ �̵�
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0; //SpriteRenderer�� flipX�� üũ, ����(ĳ���� �̵� ���⿡ ���� �¿����)
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
            return;

        GameManager.instance.health -= Time.deltaTime * 10;

        if(GameManager.instance.health<0)
        {
            for (int index = 2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }

            anim.SetTrigger("Dead");
            GameManager.instance.GameOver();
        }
    }
}
