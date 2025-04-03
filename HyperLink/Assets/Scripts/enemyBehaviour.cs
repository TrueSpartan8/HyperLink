using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float detectionDistance = 1f;
    public float stopDistance = 0.1f;
    public Transform player;
    public float moveSpeed = 1f;
    private Animator animator;
    public int health = 20;
    public int damage = 5;
    private SpriteRenderer m_SpriteRenderer;
    private Color ogColor;
    private bool isHit;
    private Vector2 knockbackDirection;
    public float knockbackStrength = -0.01f;
    private PlayerHealth playerObj;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        ogColor = m_SpriteRenderer.color;
        isHit = false;
        playerObj = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDistance && Vector2.Distance(transform.position, player.position) < detectionDistance && !isHit)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("InputX", player.position.x - transform.position.x);
            animator.SetFloat("InputY", player.position.y - transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > detectionDistance)
        {
            transform.position = this.transform.position;
            animator.SetBool("isMoving", false);
        }

        if (health <= 0)
        {
            isHit=true;
            m_SpriteRenderer.color = new Color(255, 0, 0);
            Invoke("die", 1);
        }
    }

    void die()
    {
        transform.position = new Vector2(-10, -10);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("slash") && !isHit)
        {
            health -= playerObj.damage;
            isHit = true;
            animator.SetBool("isMoving", false);
            m_SpriteRenderer.color = new Color(255, 0, 0);
            knockbackDirection = player.transform.position - GameObject.FindWithTag("slash").transform.position;
            rb.linearVelocity = (knockbackDirection.normalized * knockbackStrength);
            Invoke("endKnockback", 0.1f);
            Invoke("resetColor", 1);
        }
    }

    private void endKnockback()
    {
        rb.linearVelocity = Vector2.zero;
    }
    void resetColor()
    {
        rb.linearVelocity = Vector2.zero;
        isHit = false;
        m_SpriteRenderer.color = ogColor;
    }
}
