using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float barX;
    public float barY;
    public float totalHealth;
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
        transform.localScale = new Vector2((health/100) * totalHealth, 0.2f);
        
        transform.position = new Vector2((Camera.main.transform.position.x + barX) + (-1+(health/100))*totalHealth/2, Camera.main.transform.position.y + barY);
    }
}
