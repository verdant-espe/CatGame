using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    // Detects mouse position
    [SerializeField]
    private Camera sceneCamera;

    // Checks last position
    private Vector3 lastPosition;

    // Detects mouse position on ground
    [SerializeField]
    private LayerMask placementLayerMask;

    // Tells when user has clicked the mouse button
    public event Action OnClicked, OnExit;

    private void Update()
    {
        // Calls action event, tells that mouse is clicked, interactable is placed
        if (Input.GetMouseButtonDown(0))
            OnClicked?.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape))
            OnExit?.Invoke();
    }

    public bool IsPointerOverUI()
        // Returns true or false if pointer is over a UI object
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 selectGroundPos()
    {
        // Gets input through mouse position
        Vector3 mousePos = Input.mousePosition;

        // Doesn't select objects not rendered by camera
        mousePos.z = sceneCamera.nearClipPlane;

        // Returns ray going from camera to mouse position
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);

        // Result of selecting interactable
        RaycastHit hit;

        // Checks if physics detects raycast on ground
        if(Physics.Raycast(ray, out hit, 100, placementLayerMask))
        {
            // If ray hits collider, equals hit.point
            lastPosition = hit.point;
        }
        // Returns default values of last position
        return lastPosition;
    }
}
