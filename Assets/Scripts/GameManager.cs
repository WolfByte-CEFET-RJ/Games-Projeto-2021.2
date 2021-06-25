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
    public Conductor conductor;
    public float controleDeAcertos, controleDeErros, controleTotal;
    [SerializeField] private Animator anim;
    void Start()
    {
       controleDeErros = 0f;
       controleDeAcertos = 0f;
       
    }

 
    void Update()
    {
        //#region Colisores para detecção de inimigos  
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
          colliders[0].enabled = true;
          anim.SetTrigger("Press");
        }
        else 
        { 
          colliders[0].enabled = false;  
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
          colliders[1].enabled = true;
          anim.SetTrigger("Press");
        }
        else 
        { 
          colliders[1].enabled = false;  
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
          colliders[2].enabled = true;
          anim.SetTrigger("Press");
        }
        else 
        { 
          colliders[2].enabled = false;  
        }
        //#endregion   

        acertosUI.text = "Acertos: " + $"{acertos}";
        errosUI.text = "Erros: " + $"{erros}";   

        if(controleDeAcertos != acertos)
        {
          controleDeAcertos = acertos;
        }

        if(controleDeErros != erros)
        {
          controleDeErros = erros;
        }

      controleTotal = controleDeAcertos - controleDeErros;
    }


 
}
