using UnityEngine;

public class DetectInteractable : MonoBehaviour
{
    // Creates a rigidbody class for the interactable
    private Rigidbody rb;
    // Stores grab point
    private Transform itemGrabPointTransform;

    // Calls rigidbody components
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Sets grab point for interactable
    public void Grab(Transform interactableGrabPointTransform)
    {
        // Updates grab point
        this.itemGrabPointTransform = interactableGrabPointTransform;
        // Disables gravity upon selecting interactable
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    // Sets when the player drops the object
   public void Drop()
    {
        // Sets grab point to null
        this.itemGrabPointTransform = null;
        // Enables gravity when interactable is dropped
        rb.useGravity = true;
    }
    
    // Moves interactable rigidbody
    private void FixedUpdate()
    {
        // If grab point isn't null, move position of interactable
        if(itemGrabPointTransform != null)
        {
            // Sets lerp speed
            float lerpSpeed = 10f;

            // Makes interactable move smoother
            Vector3 newPosition = Vector3.Lerp(transform.position, itemGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            
            // Moves position of interactable with player
            rb.MovePosition(newPosition);
        }
    }
}
