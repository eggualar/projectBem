using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget; //inspector���� ���� ���ص� ��

    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);//ĳ���� ���� ��ġ, ��� ����, ������, ĳ���� ����, Ÿ�� ���̾�
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;    // �ӽ� ����� �� �Ʒ� result���� ä������
        float diff = 100;           // �ӽ� �Ÿ�

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos); //Distance: A,B�� �Ÿ��� ������

            if(curDiff < diff)
            {
                diff = curDiff; //�ӽ� �Ÿ����� ������ ��ü
                result = target.transform;
            }
        }

        return result;
    }

}
