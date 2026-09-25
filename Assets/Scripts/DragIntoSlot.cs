using UnityEngine;
using UnityEngine.EventSystems;

public class DragIntoSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Stops multiple items from being placed in a single slot
        if (transform.childCount == 0)
        {
            // Gets dropped item
            GameObject dropped = eventData.pointerDrag;

        // Gets DraggableItem script from dropped GameObject
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        // Sets draggableItem parent to transform after it has been tragged
        draggableItem.parentAfterDrag = transform;
        }
    }
}
