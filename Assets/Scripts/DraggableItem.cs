using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // References icon image
    public Image image;

    // Keeps icon on top of inventory and hides it in the editor
    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Tells when the player begins to drag item from slot
        Debug.Log("Begin drag");

        // Saves original parent before drag
        parentAfterDrag = transform.parent;

        // Makes canvas parent
        transform.SetParent(transform.root);

        // Sets it at top layer of canvas
        transform.SetAsLastSibling();

        // Disables interaction with item
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Tells when player is currently dragging item from slot
        Debug.Log("Dragging");

        // When mouse is held, item is able to be dragged
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Tells when player stops dragging item
        Debug.Log("End drag");

        // Assign parent after drag
        transform.SetParent(parentAfterDrag);

        // Enables interaction with item
        image.raycastTarget = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
