using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private GameObject player;
    
    public float beatsPorTempo = 130f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        beatsPorTempo = beatsPorTempo/60f;
    }
    void Update()
    {   
        Vector2 move = new Vector2(-beatsPorTempo * Time.deltaTime, 0f);
        this.transform.Translate(move);

        float dist = Vector3.Distance(this.transform.position, player.transform.position);
    }
}
