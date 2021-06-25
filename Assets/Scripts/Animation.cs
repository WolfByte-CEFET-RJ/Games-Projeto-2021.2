using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    
    public Animator anim;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.D)){
            anim.SetTrigger("Front");
        }
        else if(Input.GetKeyDown(KeyCode.S)){
            anim.SetTrigger("Down");
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            anim.SetTrigger("Up");
        }
            
        
        
    }
    
}
