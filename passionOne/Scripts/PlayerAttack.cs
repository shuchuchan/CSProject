using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float attackCooldown;

   private float attacking;
   
   public float damage;
   public Transform attackPosition;
   public float attackRange; 
   public LayerMask Enemy;
   public Animator animator;

    void Start()
    {
        attacking = 0;
        animator = GetComponent<Animator>();
    }

   void Update()
   {
    
    if (attacking <= 0)
    {

       
        if(Input.GetKey(KeyCode.F))
        {
            animator.SetBool("PlayerRun", false);
            animator.SetBool("Attack", true);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, Enemy);
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            attacking = attackCooldown;
            if(animator.GetBool("Attack") == true)
            {
                animator.SetBool("PlayerRun", false);
            }
            

        } 
        
    }
    
    else
        {
        attacking -= Time.deltaTime;
        if(animator.GetBool("Grounded") || animator.GetBool("Run") )
            {
            animator.SetBool("Attack", false);
            }
        }

    //animator.SetBool("Attack", false);
    
   }
 

   
    
    void OnDrawGizmosSelected()
   {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPosition.position, attackRange);
   }



}
