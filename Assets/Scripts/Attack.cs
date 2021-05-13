using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPosUp;
    public Transform attackPosFront;
    public Transform attackPosDown;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    public Animator anim;
    public float attackSpeed;
    private float startAttack = 0.0f;

    // Update Is called once per frame
    void Update()
    {
        if(timeBtwAttack<=0){
            if(Input.GetKey(KeyCode.D)&& Time.time>startAttack){
                anim.SetBool("IsAttacking_Front", true);
                startAttack= Time.time + attackSpeed;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosFront.position,attackRange,whatIsEnemies);
                for(int i=0;i<enemiesToDamage.Length;i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            else if(Input.GetKey(KeyCode.W)&& Time.time>startAttack){
                anim.SetBool("IsAttacking_Up", true);
                startAttack= Time.time + attackSpeed;            
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosUp.position,attackRange,whatIsEnemies);
                for(int i=0;i<enemiesToDamage.Length;i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            else if(Input.GetKey(KeyCode.S)&& Time.time>startAttack ){
                anim.SetBool("IsAttacking_Down", true);
                
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosDown.position,attackRange,whatIsEnemies);
                for(int i=0;i<enemiesToDamage.Length;i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        
            anim.SetBool("IsAttacking_Front", false);
            anim.SetBool("IsAttacking_Up", false);
            anim.SetBool("IsAttacking_Down", false);
            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;
            

        }
    }
   
}