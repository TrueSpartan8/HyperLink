using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject bar;
    public healthBar other;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bar = GameObject.Find("BossHealth");
        other = (healthBar) bar.GetComponent(typeof(healthBar));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            other.barY = -0.5f;
        }
    }
}
