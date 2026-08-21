using UnityEngine;

public class BadCatController : MonoBehaviour
{
    // Controls forward and backward movement
    private float forwardInput;

    // Controls left and right movement
    private float horizontalInput;

    // Controls player speed
    private float moveSpeed = 2.0f;

    // Controls player jump
    public Vector3 jump;

    // Controls player jump force
    private float jumpForce = 5.5f;

    // Tells whether or not player is grounded
    public bool isGrounded;

    // References Rigidbody
    Rigidbody rb;

    // Controls the direction the player sprite is facing
    private int facingDirection = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets component for RigidBody
        rb = GetComponent<Rigidbody>();

        // 
        jump = new Vector3(0.0f, 2.5f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the input for vertical movement
        forwardInput = Input.GetAxis("Vertical");

        // Sets the input for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        // Checks if player is flipped the correct way, facing right when moving right, facing left when moving left
        if(horizontalInput > .1f && facingDirection < 0 || horizontalInput < -.1f && facingDirection > 0)
        {
            Flip();
        }

        // Moves the player forwards and backwards
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);

        // Moves the player left and right
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput );

        // Lets player jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Uses force to bring down player after jump
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Sets Flip method
    void Flip()
    {
        // Changes the direction player is facing
        facingDirection *= -1;

        // Flips player sprite
        Vector3 scale = transform.localScale;

        // Changes x value of scale by -1
        scale.x *= -1;

        // Takes scale value and applies it to player's transform
        transform.localScale = scale;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
