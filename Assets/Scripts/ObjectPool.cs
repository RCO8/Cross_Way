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
        //사용한 것을 집어넣기로 새로 꺼내서 맨 끝으로 집어넣기
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (var pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //처음에 pool의 사이즈만큼 생성하고 objectPool에 넣기
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);   //GameManager안에서 관리할수 있도록
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        //태그에 pool이 없으면
        if (!PoolDictionary.ContainsKey(tag))
            return null;

        //PoolDictionary에서 Dequeue
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}
