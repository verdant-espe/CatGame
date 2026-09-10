using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlacer : MonoBehaviour
{
    // Creates a list for GameObjects
    [SerializeField]
    private List<GameObject> placedGameObject = new();

    public int PlaceItem(GameObject prefab, Vector3 position)
    {
        // Instantiates item prefab
        GameObject newInteractable = Instantiate(prefab);

        // Sets position to PlaceItem position
        newInteractable.transform.position = position;

        // Adds new items to index
        placedGameObject.Add(newInteractable);

        // Returns placedGameObject
        return placedGameObject.Count - 1;
    }

    internal void RemoveItemAt(int gameObjectIndex)
    {
        // If placedGameObject is less than gameObjectIndex and equal to null, return
        if (placedGameObject.Count <= gameObjectIndex || placedGameObject[gameObjectIndex] == null)
            return;
        // Else, destroy item
        Destroy(placedGameObject[gameObjectIndex]);
        placedGameObject[gameObjectIndex] = null;
    }
}
