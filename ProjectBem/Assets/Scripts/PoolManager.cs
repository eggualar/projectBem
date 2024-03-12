using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �����յ��� ������ ����
    public GameObject[] prefabs;

    // Ǯ ����� �ϴ� ����Ʈ��
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
        // ������ Ǯ�� ��� �ִ� ���ӿ�����Ʈ ����
 
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                // �߰� �� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(select == null)
        {
            //��ã���� ���Ӱ� �����ϰ� select������ �Ҵ�
            select = Instantiate(prefabs[index], transform); //instantiate : ������ �����Ͽ� ����
            pools[index].Add(select); // ������ ������ ����Ʈ�� �Ҵ�
        }

        return select;
    }

}
