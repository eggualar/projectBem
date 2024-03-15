using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // 컴포넌트에 있는 Rigidbody2D 가져옴
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //normalized : 피타고라스 정리에 의해 대각선 방향도 같은 속도로 이동하게 함
        //Time.fixedDeltaTime : 물리 프레임 속도만큼
        rigid.MovePosition(rigid.position+nextVec); // 위치 이동
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0; //SpriteRenderer의 flipX를 체크, 해제(캐릭터 이동 방향에 따른 좌우반전)
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
