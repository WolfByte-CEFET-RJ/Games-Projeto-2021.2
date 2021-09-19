using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator bossAnim;
    public bool isAttacking;

    [SerializeField] private ProjectilePool ppRef;

    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        bossAnim = this.gameObject.GetComponentInChildren<Animator>();
        counter = 3f;

    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        //isAttacking = false;
        if(Input.GetKeyDown(KeyCode.P))
        {
            ppRef.DisableObject(this.gameObject, this.tag);
            /*isAttacking = !isAttacking;
            bossAnim.SetBool("Attack", isAttacking);*/
        }
        
        if(counter <= 0f)
        {
            counter = 3f;
            Attack();   
        }



    
    }

    private void Attack()
    {
        bossAnim.SetBool("Attack", isAttacking);
        ppRef.SpawnFromPool("bullet");
        isAttacking = true;
    }


 
}
