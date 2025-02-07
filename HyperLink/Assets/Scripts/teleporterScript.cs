using UnityEngine;

public class teleporterScript : MonoBehaviour
{

    [SerializeField] private float xCord = 0.0f;
    [SerializeField] private float yCord = 0.0f;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            player.transform.position = new Vector2(xCord, yCord);
        }
    }
}
