using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    public PlayerMovements playerMovements;
    
    
    
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    

}
