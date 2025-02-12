using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            BroadcastMessage("Swing");

            animator.SetFloat("LastInputX", mousePos.x - transform.position.x);
            animator.SetFloat("LastInputY", mousePos.y - transform.position.y);
        }
    }
}
