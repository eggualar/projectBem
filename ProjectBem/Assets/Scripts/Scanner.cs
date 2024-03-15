using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget; //inspector에서 설정 안해도 됨

    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);//캐스팅 시작 위치, 쏘는 방향, 원지름, 캐스팅 길이, 타겟 레이어
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;    // 임시 결과물 이 아래 result값을 채워넣음
        float diff = 100;           // 임시 거리

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos); //Distance: A,B의 거리를 구해줌

            if(curDiff < diff)
            {
                diff = curDiff; //임시 거리보다 작으면 교체
                result = target.transform;
            }
        }

        return result;
    }

}
