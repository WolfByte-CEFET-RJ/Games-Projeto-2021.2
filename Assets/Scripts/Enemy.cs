using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private GameObject player;
    
    public float beatsPorTempo = 130f;

    public static int contador;
    
    bool setAttack;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rigidbody;
    Vector2 move;

    public GameObject deathParticle;
    void Awake()
    {
        contador = 0;
        //anim = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        beatsPorTempo = beatsPorTempo/60f;
        setAttack = false;
    }
    void Update()
    {   
        move = new Vector2(-(beatsPorTempo *Time.deltaTime), 0f);
        this.transform.Translate(move);

        float i = Vector3.Distance(this.transform.position, player.transform.position);
        if(i <= 3.4f)
        {
            setAttack = true;
            anim.SetBool("Attack", setAttack);
        }
        else
        {
            setAttack = false;
            anim.SetBool("Attack", setAttack);
        }
    }
    
    void EnemyDeath()
    {
        ObjectPooler.Instance.SetFalse(this.gameObject, "enemy");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Limite")
        {   
            EnemyDeath();
            GameManager.Instance.erros++;
        }

        if(other.gameObject.tag == "ColLow")
        {
            GameManager.Instance.acertos++;
            EnemyDeath();
        }
            
        if(other.gameObject.tag == "ColMid")
        {
            EnemyDeath();
            GameManager.Instance.acertos++;
        }
        if(other.gameObject.tag == "ColHigh")
        {
            EnemyDeath();
            GameManager.Instance.acertos++;
        }

        if(other.gameObject.tag == "Player")
        {
            EnemyDeath();
            GameManager.Instance.erros++;
        }  
    }
}
