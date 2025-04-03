using UnityEngine;

public class healthBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealth(float health)
    {
        transform.localScale = new Vector2(health/100, 0.2f);
        
        transform.position = new Vector2((Camera.main.transform.position.x - 1.04f) + (-1+(health/100))/2, Camera.main.transform.position.y + 0.62f);
    }
}
