using System.Collections.Generic;

using UnityEngine;

namespace NDRGameTemplate
{
    public class ObjectPooler : MonoBehaviour
    {
        #region Singleton
        public static ObjectPooler instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }


        #endregion
        public Dictionary<string, Queue<GameObject>> poolDictionary;
        public List<Pool> pools;

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objPool = new Queue<GameObject>();
                
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + "doesn't exist");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            
            objectToSpawn.SetActive(true);

            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            if(objectToSpawn.TryGetComponent(out IPoolable poolable))
                poolable.OnObjectSpawn();

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }
    }
}
