using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CraftingManager : MonoBehaviour
{
    // Current item in the slot
    private Item currentItem;

    // Stores an array of crafting slots
    public CraftSlot[] craftSlots;

    // Stores a list of items
    public List<Item> itemList;

    // Creates recipes for crafting items
    public string[] recipes;

    // Creates result after crafting recipe
    public Item[] recipeResults;

    // Contains the result slot
    public CraftSlot resultSlot;

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

                // Keeps track of what slot has what item
                itemList[nearestSlot.index] = currentItem;

                // currentItem is set back to null
                currentItem = null;
            }
        }
    }

    void CheckForCompletedRecipes()
    {
        // Disables result slot
        resultSlot.gameObject.SetActive(false);
        // Sets result item slot to null
        resultSlot.item = null;
        // Sets currentRecipeString to an empty string
        string currentRecipeString = "";

        foreach(Item item in itemList)
        {
            // If item is not equal to null, add current recipe string to item name
            if(item != null)
            {
                currentRecipeString += item.itemName;
            }
            // Else, it is null
            else
            {
                currentRecipeString += null;
            }
        }
        for(int i = 0; i < recipes.Length; i++)
        {
            // If recipes is equal to currentRecipeString, player has successfully created a recipe
            if (recipes[i] == currentRecipeString)
            {
                // Sets result slot active
                resultSlot.gameObject.SetActive(true);
                // Gets image of completed recipe result
                resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                // Shows the resulted item
                resultSlot.item = recipeResults[i];
            }
        }
    }

    public void OnClickSlot(CraftSlot slot)
    {
        // No item in slot
        slot.item = null;

        // makes itemList equal to null
        itemList[slot.index] = null;

        // Calls CheckForCompletedRecipes
        CheckForCompletedRecipes();
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
