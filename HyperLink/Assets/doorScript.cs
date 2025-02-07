using UnityEngine;

public class doorScript : MonoBehaviour
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void openDoor()
    {
        gameObject.GetComponent<Box Collider 2D>().enabled = false;
        animator.SetBool("isOpen", true);
    }

    void closeDoor()
    {
        gameObject.GetComponent<Box Collider 2D>().enabled = true;
        animator.SetBool("isOpen", false);

    }
}
