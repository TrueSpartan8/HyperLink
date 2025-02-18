using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private float originalMoveSpeed = 0f;
    private Vector2 newMovement;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private enum playerDirectionEnum {
        up,
        down,
        left,
        right
    };
    private playerDirectionEnum direction = playerDirectionEnum.down;
    private bool canMove = true;
    private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) { //player is able to move
            newMovement = moveInput * moveSpeed;
            if (newMovement != Vector2.zero) { //the player has moved
                isMoving = true;
                if (newMovement.y > rb.linearVelocity.y) {direction = playerDirectionEnum.up;}
                else if (newMovement.y < rb.linearVelocity.y) {direction = playerDirectionEnum.down;}
                if (newMovement.x < rb.linearVelocity.x) {direction = playerDirectionEnum.left;}
                else if (newMovement.x > rb.linearVelocity.x) {direction = playerDirectionEnum.right;}
            }
            else { //the player did not move
                isMoving = false;
            }
            rb.linearVelocity = newMovement;
        }
        else { //player is unable to move, and will not move
            isMoving = false;
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if(context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    public void SetCanMove(bool canMove) {
        this.canMove = canMove;
    }
}
