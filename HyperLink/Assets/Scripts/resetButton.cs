using UnityEngine;
using UnityEngine.EventSystems;

public class resetButton : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            animator.SetBool("isButtonPressed", true);
            BroadcastMessage("Reset");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isButtonPressed", false);
        }
    }
}
