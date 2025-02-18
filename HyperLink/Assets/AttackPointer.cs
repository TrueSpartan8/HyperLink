using UnityEngine;

public class AttackPointer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(transform.position.x - mousePos.x, transform.position.y - mousePos.y);
        transform.up = direction;
    }
}
