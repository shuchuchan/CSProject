using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
   
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    [SerializeField] private GameState gameState;

    [SerializeField] private Rigidbody2D rb;
    
    public float currentHealth { get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckFall();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //player hurt
            StartCoroutine(Invunerability());
        }
        else 
        {
            if(gameState.score <= 50)
            {
                SceneManager.LoadScene("gradeF");
            }
            if(gameState.score > 50 && gameState.score <=60)
            {
                SceneManager.LoadScene("gradeD");
            }
            if(gameState.score > 60 && gameState.score <80)
            {
                SceneManager.LoadScene("gradeC");
            }
            if(gameState.score >= 76 && gameState.score < 90)
            {
                SceneManager.LoadScene("gradeB");
            }
            if(gameState.score >= 90)
            {
                SceneManager.LoadScene("gradeA");
            }
        }
    }

   

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

   
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    private void CheckFall()
    {
        if(rb.transform.position.y < -5)
        {
            if(gameState.score <= 50)
            {
                SceneManager.LoadScene("gradeF");
            }
            if(gameState.score > 50 && gameState.score <=60)
            {
                SceneManager.LoadScene("gradeD");
            }
            if(gameState.score > 60 && gameState.score <80)
            {
                SceneManager.LoadScene("gradeC");
            }
            if(gameState.score >= 76 && gameState.score < 90)
            {
                SceneManager.LoadScene("gradeB");
            }
            if(gameState.score >= 90)
            {
                SceneManager.LoadScene("gradeA");
            }
        }
    }
}
