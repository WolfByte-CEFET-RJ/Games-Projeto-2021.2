using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake() {
        Instance = this;    
    }
    #endregion
    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDicionario;
    void Start()
    {
        poolDicionario = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
            {
                GameObject a = Instantiate(p.prefab);
                a.SetActive(false);
                objectPool.Enqueue(a);
            }

            poolDicionario.Add(p.tag, objectPool);

        }
    }

    public GameObject SpawnFromPool(string tag, Transform pos)
    {
        if(!poolDicionario.ContainsKey(tag))
        {
            Debug.LogWarning("não tem chave na fila");
            return null;
        }
        
        GameObject o = poolDicionario[tag].Dequeue();

        o.SetActive(true);
        o.transform.position = pos.position;
        return o;
    }
}
