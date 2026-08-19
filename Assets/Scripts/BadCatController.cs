using UnityEngine;

public class BadCatController : MonoBehaviour
{
    // Controls forward and backward movement
    private float forwardInput;

    // Controls left and right movement
    private float horizontalInput;

    // Controls player speed
    private float moveSpeed = 2.0f;

    // Controls player jump force
    private float jumpForce = 1.5f;

    // References Rigidbody
    private Rigidbody rb;


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
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);

        // Moves the player left and right
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput );

        // Allows player to jump
        if (Input.GetKeyDown (KeyCode.Space))
        {
            transform.position += new Vector3(0, jumpForce / 4, 0);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
