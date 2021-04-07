using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    #region Singleton
      public static GameManager Instance;
      private void Awake() {
          Instance = this;    
      }
    #endregion
    
    public BoxCollider2D[] colliders;
     
    public Text acertosUI, errosUI;
    public int acertos, erros;

    

    void Start()
    {
         acertos = 0;
         erros = 0;
    }

 
    void Update()
    {
        //#region Colisores para detecção de inimigos  
        if(Input.GetKeyDown(KeyCode.I))
          colliders[0].enabled = true;
        else 
          colliders[0].enabled = false;  

        if(Input.GetKeyDown(KeyCode.O))
          colliders[1].enabled = true;
         else 
          colliders[1].enabled = false;  

        if(Input.GetKeyDown(KeyCode.P))
          colliders[2].enabled = true;
        else 
          colliders[2].enabled = false;  
        //#endregion   

        acertosUI.text = "Acertos: " + $"{acertos}";
        errosUI.text = "Erros: " + $"{erros}";
        

        
    }
}
