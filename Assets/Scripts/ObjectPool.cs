using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        //����� ���� ����ֱ�� ���� ������ �� ������ ����ֱ�
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (var pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //ó���� pool�� �����ŭ �����ϰ� objectPool�� �ֱ�
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);   //GameManager�ȿ��� �����Ҽ� �ֵ���
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        //�±׿� pool�� ������
        if (!PoolDictionary.ContainsKey(tag))
            return null;

        //PoolDictionary���� Dequeue
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}
