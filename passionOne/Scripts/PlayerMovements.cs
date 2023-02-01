using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 13f;
    private bool isFacingRight = true;
    private bool doubleJump = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField]private BoxCollider2D boxCollider;

    //knockback stuff
    public float KBforce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    public bool grounded;

   void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
   
    private void Update()
    {   
        //animation stuff
        
        
        
        
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
       
        animator.SetBool("Run", horizontal != 0);

       
        
    }

    private void FixedUpdate()
    {
       
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
       

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
        animator.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    
}