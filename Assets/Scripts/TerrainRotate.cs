using UnityEngine;

public class TerrainRotate : MonoBehaviour
{

    public float rotationSpeed;
    // Speed of terrain rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates terrain on its y axis
        transform.Rotate(0, rotationSpeed, 0);
    }
}
