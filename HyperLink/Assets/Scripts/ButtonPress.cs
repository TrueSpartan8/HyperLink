using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "block" || collider.gameObject.tag == "Player")
        {
            animator.SetBool("isButtonPressed", true);
            BroadcastMessage("openDoor");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("block") || collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isButtonPressed", false);
            BroadcastMessage("closeDoor");
        }
    }
}
