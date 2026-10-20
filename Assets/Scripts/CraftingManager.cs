using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    // Current item in the slot
    private Item currentItem;

    public CraftSlot[] craftSlots;

    private void Update()
    {
        // If left mouse button is let go of and currentItem is not equal to null, nearestSlot = null and closestDistance is set to MaxValue
        if (Input.GetMouseButtonUp(0))
        {
            if(currentItem != null)
            {
                CraftSlot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                // Loops through each slot
                foreach (CraftSlot slot in craftSlots)
                {
                    // Calculates distance between mouse position and slot transform position
                    float distance = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    // If distance is less than shortestDistance, set shortestDistance equal to distance and nearestSlot equal to slot
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        nearestSlot = slot;
                    }
                }
                // Sets nearestSlot to active
                nearestSlot.gameObject.SetActive(true);
                // Sets nearestSlot item equal to currentItem
                nearestSlot.item = currentItem;
                // currentItem is set back to null
                currentItem = null;
            }
        }
    }

    // If currentItem is null, set currentItem equal to item
    public void OnMouseDownItem(Item item)
    {
        if (currentItem == null)
        {
            currentItem = item;
        }
    }
}
