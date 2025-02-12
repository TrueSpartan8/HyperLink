using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swing()
    {
        animator.SetTrigger("attack");
    }

}
