using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public Transform[] positions;
    public GameObject[] lowEnemies;
    public GameObject[] midEnemies;
    public GameObject[] highEnemies;
    
    [SerializeField] private Conductor cond;

    [SerializeField] private int contador;
    [SerializeField] float limite = 0;
    public float limiteSet;
    public float tempo;
    [SerializeField] float t = 0f;
    
 
    void Start()
    {
        contador = 0;
        tempo = cond.secondsPerBeat * 4f;
        t = tempo;
    }

    // Update is called once per frame
    void Update()
    {
        //a cada 3 segundos um item é spawnado no mapa       
        
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
            Destroy(low, 4f);
        }
        //instancia no spawn do meio
        else if(contador == 2)
        {
            GameObject mid = Instantiate(midEnemies[Random.Range(0, midEnemies.Length)], 
                                         positions[1].position, positions[1].rotation);
            Destroy(mid, 4f);
        }
        //instancia no spawn de cima
        else if(contador == 3)
        {
            GameObject high = Instantiate(highEnemies[Random.Range(0, highEnemies.Length)], 
                                          positions[2].position, positions[2].rotation);
            Destroy(high, 4f);
        }   
    }
}
