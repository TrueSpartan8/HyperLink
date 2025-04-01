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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDistance && Vector2.Distance(transform.position, player.position) < detectionDistance)
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
    }
}
