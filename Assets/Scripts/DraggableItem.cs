using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Keeps icon on top of inventory
    Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Tells when the player begins to drag item from slot
        Debug.Log("Begin drag");

        // Saves original parent before drag
        parentAfterDrag = transform.parent;

        // Sets canvas as parent
        transform.SetParent(transform.root);

        // Sets it at top layer of canvas
        transform.SetAsLastSibling();
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
