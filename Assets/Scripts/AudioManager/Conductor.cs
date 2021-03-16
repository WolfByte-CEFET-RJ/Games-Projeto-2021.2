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

    //referencia ao AudioSource
    public AudioSource musicSource;

    //quantas batidas existem na tela
    public float BeatsShownInAdvance = 4f;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secondsPerBeat = 60f/songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();        
    }

    void Update() {

        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition/secondsPerBeat;    
    }
}
