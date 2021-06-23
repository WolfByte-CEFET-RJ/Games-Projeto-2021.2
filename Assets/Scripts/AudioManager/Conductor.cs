using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Conductor : MonoBehaviour
{
    //determina as batidas por minuto 
    public float songBpm;
    
    //determina os segundos em uma batida
    public float secondsPerBeat;

    //posição atual da musica, em segundos
    public float songPosition;

    //posição atual da musica, em batidas
    public float songPositionInBeats;

    //quanto tempo passou desde que o musica iniciou, em segundos
    public float dspSongTime;

    public AudioSource backMusic, leadMusic;

    //quantas batidas existem na tela
    public float BeatsShownInAdvance = 4f;


    //relativo a informação de qtd de loops
    //trabalhar mais nisso aqui 
    public int completedLoops = 0;

    public float beatsPerLoop;

    public float loopPositionInBeats;


    //deletar
    public float erro, acerto;

    //aux
    [SerializeField] private AudioMixer _audioMixer;
    public float i;
    

    void Start()
    {
        secondsPerBeat = 60f/songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        backMusic.Play();
        leadMusic.Play();   
        i = -10f; 
    }


    //musica começa no 14f e 32f
    void Update() {
        
        erro = GameManager.Instance.erros;
        acerto = GameManager.Instance.acertos;

        i = GameManager.Instance.controleTotal;
        _audioMixer.SetFloat("Music", i);
        
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition/secondsPerBeat;    
        

        //saber a quantidade de loops
        if(songPositionInBeats >= (completedLoops + 1 )* beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        if(i >= -6f)
        {
            i = -6f;
        }
        
        if(i <= -26f)
        {
            i = -26f;
        }

    }

}
