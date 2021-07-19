using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [System.Serializable]
    public class Pool{
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;  
    public Dictionary<string, Queue<GameObject>> bulletDictionary;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        bulletDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
            {
                GameObject a = Instantiate(p.prefab);
                a.SetActive(false);
                objectPool.Enqueue(a);
            }

            bulletDictionary.Add(p.tag, objectPool);
        }
    } 

    public GameObject SpawnFromPool(string tag)
    {
        if(!bulletDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("não tem chave na fila");
            return null;
        }
        
            if(bulletDictionary.Count != 0)
            {
                GameObject o = bulletDictionary[tag].Dequeue();
                /*
                if(o.gameObject.tag == "Low")
                    o.transform.position = dPos.position;
                else if(o.gameObject.tag== "Mid")
                    o.transform.position = midPos.position;
                else if(o.gameObject.tag == "High")
                    o.transform.position = upPos.position;*/
            

                o.SetActive(true);
                return o;
            }
            else
            {
                Debug.LogWarning("Fim da fila, fila vazia");
                return null;
            }
    }

}
