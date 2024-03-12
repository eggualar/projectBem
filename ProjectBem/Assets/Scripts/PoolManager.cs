using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹들을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int index = 0; index<pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // 선택한 풀의 놀고 있는 게임오브젝트 접근
 
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                // 발견 시 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(select == null)
        {
            //못찾으면 새롭게 생성하고 select변수에 할당
            select = Instantiate(prefabs[index], transform); //instantiate : 원본을 복제하여 생성
            pools[index].Add(select); // 복제한 원본을 리스트에 할당
        }

        return select;
    }

}
