using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������Ʈ�� �ִ� Rigidbody2D ������
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //normalized : ��Ÿ��� ������ ���� �밢�� ���⵵ ���� �ӵ��� �̵��ϰ� ��
        //Time.fixedDeltaTime : ���� ������ �ӵ���ŭ
        rigid.MovePosition(rigid.position+nextVec); // ��ġ �̵�
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
