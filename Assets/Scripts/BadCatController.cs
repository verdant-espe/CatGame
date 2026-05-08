using UnityEngine;

public class BadCatController : MonoBehaviour
{
    // Controls forward and backward movement
    public float forwardInput;

    // Controls left and right movement
    public float horizontalInput;

    // Controls player speed
    public float speed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal");

        // Moves the player forwards and backwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Moves the player left and right
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput );
    }
}
