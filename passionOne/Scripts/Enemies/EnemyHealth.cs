using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
   
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public GameState gameState;
    
    public float currentHealth { get; private set; }
    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("Player").GetComponent<GameState>();
    }
    void Update()
    {
       
        
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
            if(gameObject.tag == "Enemy")
                gameState.score += 4;
            if(gameObject.tag == "BossOne")
                gameState.score += 14;
            if(gameObject.tag == "BossTwo")
                {
                gameState.score += 14; 
                SceneManager.LoadScene("gradeA"); 
                }
            gameObject.SetActive(false); 
            
        }
    }

   
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(11, 19, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    
}
