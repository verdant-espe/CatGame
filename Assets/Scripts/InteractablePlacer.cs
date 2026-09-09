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
}
