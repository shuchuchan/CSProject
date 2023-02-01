using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
   [SerializeField] private float attackCooldown;
   private float attacking;
 
   public float damage;
   public Transform attackPosition;
   public float attackRange; 
   public LayerMask Player;


   void Update()
   {
      
   
        if (attacking <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, Player);
            if (enemiesToDamage.Length > 0)
            {
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Health>().TakeDamage(damage);
                }
                attacking = attackCooldown;
            }
            else
            {
                attacking = 0;
            }
        
        }
        else
        {
            attacking -= Time.deltaTime;
        }
    }


   void Start()
   {
    attacking = 0;
   }

   void OnDrawGizmosSelected()
   {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPosition.position, attackRange);
   }



}
