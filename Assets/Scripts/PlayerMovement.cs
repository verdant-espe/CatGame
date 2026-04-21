using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, rotationSpeed;
    private float xInput, yInput;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        transform.Rotate(Vector3.up, xInput * rotationSpeed * Time.deltaTime); // Rotates player

        if (yInput == 0)
        {
            rb.linearVelocity = Vector3.zero; // Stops player when no input
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(yInput * speed * transform.forward); // Moves player forward/backward
    }
}
