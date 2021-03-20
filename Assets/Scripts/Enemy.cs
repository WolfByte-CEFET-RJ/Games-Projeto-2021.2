using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private GameObject player;
    
    public float beatsPorTempo = 130f;
    public bool podeAcertar;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        beatsPorTempo = beatsPorTempo/60f;
    }
    void Update()
    {   
        Vector2 move = new Vector2(-beatsPorTempo * Time.deltaTime, 0f);
        this.transform.Translate(move);

        if(podeAcertar == true)
        {
            if(Input.GetKey(KeyCode.Space))
                Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Check")
            podeAcertar = true;
    
    }
     
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Check")
            podeAcertar = false;
    }
}
