using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float distance;

    
    public bool perto;
    
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
