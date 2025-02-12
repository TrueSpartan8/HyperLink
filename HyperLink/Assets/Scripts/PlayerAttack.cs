using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext context)
    {
        BroadcastMessage("Swing");

        if (context.canceled)
        {
            BroadcastMessage("EndSwing");

        }
    }
}
