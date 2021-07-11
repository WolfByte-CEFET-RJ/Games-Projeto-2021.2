using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenuUI;

    public void Start(){
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void Update(){
       if (Input.GetKeyDown(KeyCode.Escape)) {
           if (GameIsPaused) {
               Resume();
           } else {
               Pause();
           }
       } 
    }
    
    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios) {
            a.Play();
        };  
        GameIsPaused = false;
    }

    public void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios) {
            a.Pause();
        };  
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}


