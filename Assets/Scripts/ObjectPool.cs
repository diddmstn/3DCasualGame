using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag; 
        public List<GameObject> prefab; 
        public int size; 
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        //Dicitionary O(1), List O(n)
        poolDictionary= new Dictionary<string, Queue<GameObject>>();//Queue�� ������ ���� ������ �ָ� ���� �ش�?
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); 
            for (int i = 0; i<pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab[Random.Range(0,pool.prefab.Count)]);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}
