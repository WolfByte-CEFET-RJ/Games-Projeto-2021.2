using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //arrays com posições e tipos de inimigos
    public Transform[] positions;
    public GameObject[] lowEnemies;
    public GameObject[] midEnemies;
    public GameObject[] highEnemies;
    
    //referencia a classe Conductor (p/acessar algumas variaveis)
    [SerializeField] private Conductor cond;

    //variaveis para tempo e instancia de objetos
    [SerializeField] float limite = 0; // variavel auxiliar para limite de inimigos
    public float limiteSet;            // limite de inimigos
    public float tempo;                // tempo para instanciar
    float t = 0f;                      // variavel auxiliar para limite de tempo

    void Start()
    {
        
        //
        tempo = cond.secondsPerBeat * 4f;
        //t recebe o valor de tempo, para determinar o limite de tempo
        t = tempo;
    }

    void Update()
    {
        tempo -= Time.deltaTime;
            if(tempo <= 0f && limite < limiteSet)
            {     
                ObjectPooler.Instance.SpawnFromPool("enemy");                
                tempo = t;
                limite++;
            }

    }
}
