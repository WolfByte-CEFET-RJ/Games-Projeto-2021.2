using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    void Update()
    {   
        transform.position = new Vector2(-(2 * Time.deltaTime), 0f);
    }
}
