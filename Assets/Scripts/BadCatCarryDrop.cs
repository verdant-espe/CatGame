using UnityEngine;

public class BadCatCarryDrop : MonoBehaviour
{
    // Serializes a field for the player
    [SerializeField] private Transform badcatCharTransform;
    // Serializes a field for the layer mask
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform interactableGrabPointTransform;

    // Stores a private DetectGrabbable
    private DetectInteractable detectInteractable;

    private void Update()
    {
        // If left mouse button clicked, player picks up an object
        if (Input.GetMouseButtonDown(0))
        {
            // If interactable is null, try to grab interactable when not carrying one
            if (detectInteractable == null)
            {
                // Sets the distance an interactable can be picked up and carried
                float carryDistance = 0.5f;
                // Creates the physics for the player to carry an interactable
                if (Physics.Raycast(badcatCharTransform.position, badcatCharTransform.right, out RaycastHit raycastHit, carryDistance, pickupLayerMask))
                {
                    // If raycast detects that a collision happens, show in debug console
                    Debug.Log(raycastHit, transform);
                }
                // If raycast detects an interactable, show in debug console
                if (raycastHit.transform.TryGetComponent(out detectInteractable))
                {
                    detectInteractable.Grab(interactableGrabPointTransform);
                    Debug.Log(detectInteractable);
                }

            }
            // If interactable isn't null, player is currently carrying one and needs to drop it
            else
            {
                detectInteractable.Drop();
                // Clears the field
                detectInteractable = null;
            }
        }
    }
}
