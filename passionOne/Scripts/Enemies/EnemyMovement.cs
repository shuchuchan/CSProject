using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  
    private Vector2 movement;
    public float moveSpeed = 5f;
    private float horizontal;
    private bool isFacingRight = true;
    public Transform player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] private Animator animator;
    public GameState gameState;
    
   


    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        

    }

    // Update is called once per frame
    void Update()
    {   
        
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        direction.Normalize();
        movement = direction; 
        
        Flip();
        if(IsGrounded())
        {
            
        }
        if(!IsGrounded())
        {
            //set the negative y value to be much higher than the original so that it falls
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        move(movement);
        
    }


    void move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

       //animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

