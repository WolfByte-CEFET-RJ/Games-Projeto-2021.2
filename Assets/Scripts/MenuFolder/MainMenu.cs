using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Load the first level
    }
    
    public void QuitGame() {
        Application.Quit();//Quit the game
    }

    public void ProxCena() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AntCena() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
