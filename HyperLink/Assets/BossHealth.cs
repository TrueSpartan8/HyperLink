using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    public GameObject bar;
    public GameObject overlay;
    public healthBar other;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<enemyBehaviour>().health;
        bar = GameObject.Find("BossHealth");
        overlay = GameObject.Find("BossOverlay");
        other = (healthBar) bar.GetComponent(typeof(healthBar));
    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<enemyBehaviour>().health;
        other.updateHealth(health);

        if (health <= 0)
        {
            bar.transform.position = new Vector2(-10, -10);
            overlay.transform.position = new Vector2(-10, -10);
        }
    }
}
