using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float distance;
    GameObject low, mid, high;
    
    
    public bool perto;
    
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        low = GameObject.FindWithTag("Low");
        mid = GameObject.FindWithTag("Mid");
        high = GameObject.FindWithTag("High");
        
    }
    void Start()
    {
        velocidade = 4;
    }

    void Update()
    {
        float movx = Input.GetAxis("Horizontal");
        float movy = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(velocidade * movx ,0);   
    }
}
