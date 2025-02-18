using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    private PlayerAttack playerAttack;
    private playerMovement playerMovement;
    SpriteRenderer rend;
    public float damage = 2f;    
    public float attackDelay = 0.25f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Current Weapon") {
            playerAttack.attackDelay = attackDelay;
        }
        //only rotate the sword to face the mouse IF the player is not currently attacking or is in the middle of an attack animation
        if (!playerAttack.GetIsAttacking()) {
            /*
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = new Vector2(transform.position.x - mousePos.x, transform.position.y - mousePos.y);
            if (mousePos.y > transform.position.y) {
                rend.sortingOrder = 1;
            }
            else {
                rend.sortingOrder = 3;
            }
            transform.up = direction; */
        }
    }

    public void Attack()
    {
        animator.SetTrigger("attack"); //trigger the attack animation
        playerMovement.SetCanMove(false);
    }

    public void OnAttackAnimationEnd() { //this is called when the slash animation ends (animator event)
        playerAttack.SetIsAttacking(false);
        playerMovement.SetCanMove(true);
    }
}
