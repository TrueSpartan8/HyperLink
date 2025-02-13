using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private Vector3 mousePos;
    public float attackDelay = 0.25f; //this attack delay will be replaced by the attackDelay of the current weapon
    private bool isNextAttackDisabled; //if attackDelay has ended, then you can perform another (next) attack
    private bool isAttacking; //if the attack animation is in progress, the player isAttacking

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext context) //Attack() from the Input Actions controller
    {
        if (context.performed)
        {
            //change the direction of the player to face the clicked mouse pointer
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            animator.SetFloat("LastInputX", mousePos.x - transform.position.x);
            animator.SetFloat("LastInputY", mousePos.y - transform.position.y);

            if (isNextAttackDisabled) {return;} //cancel the Attack() if its disabled
            isAttacking = true; //the player is right now currently in the process of attacking
            isNextAttackDisabled = true;
            BroadcastMessage("Attack"); //call the Attack() method in any child objects (which in turn triggers attack in the animator)
            StartCoroutine(DelayAttack());
        }
    }

    //wait for attackDelay seconds before setting isAttackDisabled to false
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        isNextAttackDisabled = false;
    }

    //getter and setter for the isAttacking boolean
    public void SetIsAttacking(bool isAttacking) {this.isAttacking = isAttacking;}
    public bool GetIsAttacking() {return this.isAttacking;}
}
