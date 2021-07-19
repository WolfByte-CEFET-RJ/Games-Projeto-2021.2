using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator bossAnim;
    public bool isAttacking;
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private ProjectilePool ppRef;
    
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        bossAnim = this.gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isAttacking = !isAttacking;
            bossAnim.SetBool("Attack", isAttacking);
        }
        
        if(Input.GetKeyDown(KeyCode.O))
        {
           ppRef.SpawnFromPool("bullet");
           ppRef.SpawnFromPool("rocks");
        }
        

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(-bulletSpawn.right * 10f, ForceMode2D.Impulse);
    }

 
}
