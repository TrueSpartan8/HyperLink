using UnityEngine;

public class slash : MonoBehaviour
{
    SpriteRenderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(transform.position.x - mousePos.x, transform.position.y - mousePos.y);
        if (mousePos.y > transform.position.y) {
            Debug.Log("Above");
            rend.sortingOrder = 1;
        }
        else {
            Debug.Log("Below");
            rend.sortingOrder = 3;
        }
        transform.up = direction;
    }
}