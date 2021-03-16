using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Conductor conductor;
    
    public Transform RemovePos;
    public Transform SpawnPos;

    
    void Update()
    {   
        transform.position = Vector2.Lerp(
        SpawnPos.position,
        RemovePos.position,
        (conductor.BeatsShownInAdvance -(conductor.songPosition - conductor.songPositionInBeats)) / conductor.BeatsShownInAdvance
    );
    }
}
