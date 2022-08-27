using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Core
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string Tag;
            public List<GameObject> prefab;
            public int size;
        }

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> PoolDictionary;

        void Start()
        {
            PoolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in pools)
            {
                var objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    //loop through the GameObject list inside the pool and instantiate each
                    for (int a = 0; a < pool.prefab.Count; a++)
                    {
                        var obj = Instantiate(pool.prefab[a]);
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                    }
                }

                PoolDictionary.Add(pool.Tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!PoolDictionary.ContainsKey(tag))
            {
                return null;
            }

            var objectToSpawn = PoolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            PoolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;

        }


    }
}
