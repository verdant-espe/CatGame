using UnityEngine;

public class DetectInteractable : MonoBehaviour
{
    // Creates a rigidbody class for the interactable
    private Rigidbody interactableRigidbody;
    // Stores grab point
    private Transform interactableGrabPointTransform;

    // Calls rigidbody components
    private void Awake()
    {
        interactableRigidbody = GetComponent<Rigidbody>();
    }
    // Sets grab point for interactable
    public void Grab(Transform interactableGrabPointTransform)
    {
        // Updates grab point
        this.interactableGrabPointTransform = interactableGrabPointTransform;
        // Disables gravity upon selecting interactable
        interactableRigidbody.useGravity = false;
    }

    // Sets when the player drops the object
   public void Drop()
    {
        // Sets grab point to null
        this.interactableGrabPointTransform = null;
        // Enables gravity when interactable is dropped
        interactableRigidbody.useGravity = true;
    }
    
    // Moves interactable rigidbody
    private void FixedUpdate()
    {
        // If grab point isn't null, move position of interactable
        if(interactableGrabPointTransform != null)
        {
            // Sets lerp speed
            float lerpSpeed = 10f;

            // Makes interactable move smoother
            Vector3 newPosition = Vector3.Lerp(transform.position, interactableGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            
            // Moves position of interactable with player
            interactableRigidbody.MovePosition(newPosition);
        }
    }
}
