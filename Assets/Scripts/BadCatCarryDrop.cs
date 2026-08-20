using UnityEngine;

public class BadCatCarryDrop : MonoBehaviour
{
    // Serializes a field for the player camera
    [SerializeField] private Transform badcatCameraTransform;
    // Serializes a field for the layer mask
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform interactableGrabPointTransform;
    private void Update()
    {
        // If left mouse button clicked, player picks up an object
        if(Input.GetMouseButtonDown(0))
        {
            // Sets the distance an item can be picked up and carried
            float carryDistance = 2f;
            // Creates the physics for the player to carry an item
            if (Physics.Raycast(badcatCameraTransform.position, badcatCameraTransform.forward, out RaycastHit raycastHit, carryDistance, pickupLayerMask))
            {
                // If raycast detects that a collision happens, show in debug console
                Debug.Log(raycastHit,transform);
            }
            // If raycast detects an interactable, show in debug console
                if (raycastHit.transform.TryGetComponent(out DetectInteractable detectInteractable))
            {
                detectInteractable.Grab(interactableGrabPointTransform);
                Debug.Log(detectInteractable);
            }
            
        }
    }
}
