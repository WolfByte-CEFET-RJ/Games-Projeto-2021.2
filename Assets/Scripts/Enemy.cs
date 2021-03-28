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

        // LEMBRAR DE ALTERAR ISSO ENQUANTO O JOGO FOR PROGREDINDO //
        if(this.gameObject.tag == "Low")
            this.transform.position = new Vector2(0f, -3.55f);
        else if(this.gameObject.tag == "Mid")
            this.transform.position = new Vector2(0f, -2.52f);
        else if(this.gameObject.tag == "High")
            this.transform.position = new Vector2(0f, -1.3f);

    }
    void Update()
    {   
        Vector2 move = new Vector2(-beatsPorTempo * Time.deltaTime, 0f);
        this.transform.Translate(move);


        //talvez o codigo esteja no local errado?
        if(podeAcertar == true)
        {
            if(Input.GetKey(KeyCode.Space))
                //Destroy(this.gameObject);
                ObjectPooler.Instance.SetFalse(this.gameObject);
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
