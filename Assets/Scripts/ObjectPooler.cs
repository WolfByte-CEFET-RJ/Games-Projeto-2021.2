using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    //Cria a classe onde estarão armazenados os objetos
    //Contém o uma tag identificadora, o tipo de objeto e um tamanho para a Pool.
    public class Pool
    {
        public string tag;
        public GameObject[] prefab;
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
    //public Queue<GameObject> enemiesQueue;
    void Start()
    {
        poolDicionario = new Dictionary<string, Queue<GameObject>>();
        //enemiesQueue = new Queue<GameObject>();

        foreach (Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
            {
                GameObject a = Instantiate(p.prefab[i]);
                a.SetActive(false);
                objectPool.Enqueue(a);
            }
            poolDicionario.Add(p.tag, objectPool);
        }
    }
   
    public GameObject SpawnFromPool(string tag)
    {
        if(!poolDicionario.ContainsKey(tag))
        {
            Debug.LogWarning("não tem chave na fila");
            return null;
        }
        
        GameObject o = poolDicionario[tag].Dequeue();
        
        if(o.gameObject.tag == "Low")
            o.transform.position = new Vector2(30f, -3.55f);
        else if(o.gameObject.tag== "Mid")
            o.transform.position = new Vector2(30f, -2.52f);
        else if(o.gameObject.tag == "High")
            o.transform.position = new Vector2(30f, -1.3f);    
        o.SetActive(true);
        return o;
    }
    public void SetFalse(GameObject go, string tag)
    {
        if(go != null)
        {
            go.SetActive(false);
            poolDicionario[tag].Enqueue(go);
        }
            
        else 
            return;
    }
}

//Inimigo, bateu no colisor
//desativa e traz de volta para a fila
//
