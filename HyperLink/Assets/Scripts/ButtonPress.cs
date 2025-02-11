using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour
{
    private Animator animator;
    private Boolean isPressed = false; //the state of this button object

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //public getter method for the button state
    public Boolean GetIsPressed() {
        return isPressed;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "block" || collider.gameObject.tag == "Player")
        {
            isPressed = true;
            animator.SetBool("isButtonPressed", true);
            SendMessageUpwards("CheckButtonState", null, SendMessageOptions.DontRequireReceiver); //invoke any parent objects that have the CheckButtonState() method, and ignore when there are none
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("block") || collider.gameObject.CompareTag("Player"))
        {
            isPressed = false;
            animator.SetBool("isButtonPressed", false);
            SendMessageUpwards("CheckButtonState", null, SendMessageOptions.DontRequireReceiver); //invoke any parent objects that have the CheckButtonState() method, and ignore when there are none
        }
    }
}