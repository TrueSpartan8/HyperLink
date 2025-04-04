using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collider)
    {
        animator.SetBool("isButtonPressed", true);
        if(collider.gameObject.tag == "Player")
        {
            Invoke("LoadCredits", 2);
        }
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
