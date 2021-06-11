using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Teste : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public float i;
    void Start()
    {
        i = -10f;  
    } 

    void Update()
    {
        
        if(i >= 0f)
        {
            i = 0f;
        }
        
        if(i <= -20f)
        {
            i = -20f;
        }
        //i tem que variar entre numeros negativos
        // i pode começar como -10

        if(Input.GetKeyDown(KeyCode.Space))
        {
            i += -5f;
            _audioMixer.SetFloat("Music", i);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            i += 5f;
            _audioMixer.SetFloat("Music", i);
        }
    }
}
