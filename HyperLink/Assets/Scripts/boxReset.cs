using UnityEngine;

public class boxReset : MonoBehaviour
{

    private GameObject box;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        box = GameObject.FindWithTag("block");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {
        box.transform.position = new Vector2(-6.16f, -0.56f);
    }
}
