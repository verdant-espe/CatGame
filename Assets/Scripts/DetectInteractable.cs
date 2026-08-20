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

    // Moves interactable rigidbody
    private void FixedUpdate()
    {
        // If grab point isn't null, move position of interactable
        if(interactableGrabPointTransform != null)
        {
            interactableRigidbody.MovePosition(interactableGrabPointTransform.position);
        }
    }
}
