using UnityEngine;

public class boxReset : MonoBehaviour
{

    private GameObject box;
    public string blockTag;
    public float originalX;
    public float originalY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        box = GameObject.FindWithTag(blockTag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {
        box.transform.position = new Vector2(originalX, originalY);
    }
}
