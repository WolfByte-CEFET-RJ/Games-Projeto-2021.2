using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private GameObject player;
    
    public float beatsPorTempo = 130f;
    public bool primeiraVez;

    public static int contador;

    void Awake()
    {
        contador = 0;
        player = GameObject.FindWithTag("Player");
        beatsPorTempo = beatsPorTempo/60f;
    }
    void Update()
    {   
        Vector2 move = new Vector2(-(beatsPorTempo* Time.deltaTime), 0f);
        this.transform.Translate(move);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Limite")
        {   
            ObjectPooler.Instance.SetFalse(this.gameObject, "enemy");
            GameManager.Instance.erros++;
        }

        if(other.gameObject.tag == "ColLow")
        {
            ObjectPooler.Instance.SetFalse(this.gameObject, "enemy");
            GameManager.Instance.acertos++;
        }
            
        if(other.gameObject.tag == "ColMid")
        {
            ObjectPooler.Instance.SetFalse(this.gameObject, "enemy");
            GameManager.Instance.acertos++;
        }
        if(other.gameObject.tag == "ColHigh")
        {
            ObjectPooler.Instance.SetFalse(this.gameObject, "enemy");
            GameManager.Instance.acertos++;
        }

        if(other.gameObject.tag == "Player")
        {
            ObjectPooler.Instance.SetFalse(this.gameObject, "enemy");
            GameManager.Instance.erros++;
        }  

    }
     

}
