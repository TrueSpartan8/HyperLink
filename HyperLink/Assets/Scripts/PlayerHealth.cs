using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject bar;
    public healthBar other;
    public int damage = 10;
    private SpriteRenderer m_SpriteRenderer;
    private Color ogColor;
    private bool isHit;
    private Vector2 knockbackDirection;
    public float knockbackStrength = 0.01f;
    private Rigidbody2D rb;
    private playerMovement player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bar = GameObject.Find("HealthBar");
        other = (healthBar) bar.GetComponent(typeof(healthBar));
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        ogColor = m_SpriteRenderer.color;
        isHit = false;
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<playerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        other.updateHealth(health);
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("enemyAttack") && !isHit)
        {
            health -= damage;
            isHit = true;
            m_SpriteRenderer.color = new Color(255, 0, 0);
            Invoke("resetColor", 1);
            knockbackDirection = GameObject.FindWithTag("enemyAttack").transform.position - transform.position;
            player.knockback(knockbackDirection, knockbackStrength);
            
        }
    }
    void resetColor()
    {
        Debug.Log("Reset Color");
        isHit = false;
        m_SpriteRenderer.color = ogColor;
    }

}
