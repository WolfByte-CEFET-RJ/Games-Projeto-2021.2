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

    //contador para definir o tipo de inimigo a ser instanciado
    [SerializeField] private int contador;

    //variaveis para tempo e instancia de objetos
    [SerializeField] float limite = 0; // variavel auxiliar para limite de inimigos
    public float limiteSet;            // limite de inimigos
    public float tempo;                // tempo para instanciar
    float t = 0f;                      // variavel auxiliar para limite de tempo
    
 
    void Start()
    {
        contador = 0;
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
            contador = Random.Range(1,4);
            Inst_Aleatoria(contador);
            tempo = t;
            limite++;
        }

          
    }
    
    //Instancia Aleatória
    //Contador com 3 valores, cada valor representando um ponto de spawn
    private void Inst_Aleatoria(int contador)
    {
        //instancia no spawn de baixo
        if(contador == 1)
        {
            GameObject low = Instantiate(lowEnemies[Random.Range(0, lowEnemies.Length)], 
                                         positions[0].position, positions[0].rotation);
            //Destroy(low, 4f);
        }
        //instancia no spawn do meio
        else if(contador == 2)
        {
            GameObject mid = Instantiate(midEnemies[Random.Range(0, midEnemies.Length)], 
                                         positions[1].position, positions[1].rotation);
            //Destroy(mid, 4f);
        }
        //instancia no spawn de cima
        else if(contador == 3)
        {
            GameObject high = Instantiate(highEnemies[Random.Range(0, highEnemies.Length)], 
                                          positions[2].position, positions[2].rotation);
            //Destroy(high, 4f);
        }   
    }
}
