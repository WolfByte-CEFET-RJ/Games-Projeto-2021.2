using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private string objectTag;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ProjectilePool.Instance.DisableObject(this.gameObject, objectTag);
        }
        if(other.gameObject.tag == "Limite")
        {
            ProjectilePool.Instance.DisableObject(this.gameObject, objectTag);
        }
    }
}
