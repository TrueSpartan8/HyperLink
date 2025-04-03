using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject bar;
    public GameObject overlay;
    public healthBar other;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bar = GameObject.Find("BossHealth");
        overlay = GameObject.Find("BossOverlay");
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
            other.barY = -0.6f;
            overlay.transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y -0.55f);
        }
    }
}
