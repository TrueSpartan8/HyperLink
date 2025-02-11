using System;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    private Animator animator;
    public GameObject[] Buttons; //all the buttons that are required for opening this door

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check the button state of all the buttons associated with this door object. This is only called when a child button object changes state
    void CheckButtonState() {
        Boolean isOpen = true; //assume the door is open for now
        foreach(GameObject button in Buttons) { //iterate through each button
            if (!button.GetComponent<ButtonPress>().GetIsPressed()) { //if atleast one button is not pressed, this door is not open
                isOpen = false;
            }
        }
        if (isOpen) {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("isOpen", true);
        }
        else {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            animator.SetBool("isOpen", false);
        }
    }
}