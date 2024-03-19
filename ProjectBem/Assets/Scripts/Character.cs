using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 다른 스크립트에서 Character.Speed로 참조할 수 있음
    // 예) 이동속도 1.1배인 경우, 이동속도 = N*Character.Speed;
    public static float Speed
    {
        get { return GameManager.instance.playerId == 0? 1.1f : 1f; }
    }
    public static float WeaponSpeed
    {
        get { return GameManager.instance.playerId == 1 ? 1.1f : 1f; }
    }
    public static float WeaponRate
    {
        get { return GameManager.instance.playerId == 1 ? 0.9f : 1f; }
    }
    // 캐릭터 3,4인데 현재 애니메이터 없음
    public static float Damage
    {
        get { return GameManager.instance.playerId == 2 ? 1.2f : 1f; }
    }
    public static int Count
    {
        get { return GameManager.instance.playerId == 3 ? 1 : 0; }
    }
}
