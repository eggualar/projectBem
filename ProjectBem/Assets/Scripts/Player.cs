using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������Ʈ�� �ִ� Rigidbody2D ������
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //normalized : ��Ÿ���� ������ ���� �밢�� ���⵵ ���� �ӵ��� �̵��ϰ� ��
        //Time.fixedDeltaTime : ���� ������ �ӵ���ŭ
        rigid.MovePosition(rigid.position+nextVec); // ��ġ �̵�
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0; //SpriteRenderer�� flipX�� üũ, ����(ĳ���� �̵� ���⿡ ���� �¿����)
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}