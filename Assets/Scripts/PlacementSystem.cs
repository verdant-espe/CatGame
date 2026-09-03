using System;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlacementSystem : MonoBehaviour
{
    // Used to detect which position on the ground you're selecting using the mouse pointer
    [SerializeField] GameObject mouseIndicator, cellIndicator;

    // Creates a private property for InputManager
    [SerializeField] private InputManager inputManager;

    // References the grid
    [SerializeField] private Grid grid;

    // References database
    [SerializeField] private InteractablesDatabase database;

    // References item selected from index
    private int selectedInteractableIndex = -1;

    // Triggers on and off grid visualization
    [SerializeField] private GameObject gridVisual;

    // Creates data for terrain ground and blocks
    private GridData groundData, blockData;

    // Creates a preview of the item
    private Renderer previewRenderer;

    // Creates a list for GameObjects
    private List<GameObject> placedGameObject = new();

    private void Start()
    {
        StopPlacement();
        // Defines groundData
        groundData = new GridData();

        // Defines blockData
        blockData = new();

        // Accesses preview of item
        previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }

    public void StartPlacement(int ID)
    {
        // Returns index of an interactable
        selectedInteractableIndex = database.interactableData.FindIndex(data => data.ID == ID);
        
        // If interactable doesn't have ID, print message to debug console
        if(selectedInteractableIndex < 0)
        {
            Debug.LogError($"No ID found {ID}");
            return;
        }
        // Called when interactable has ID, can be placed
        gridVisual.SetActive(true);

        // Shows where interactable will be placed
        cellIndicator.SetActive(true);

        // Places down interactable
        inputManager.OnClicked += PlaceStructure;

        // Stops placement after left mouse button is clicked
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        // If pointer is over UI, return
        if(inputManager.IsPointerOverUI())
        {
            return;
        }
        // Gets the selected position of ground
        Vector3 mousePosition = inputManager.selectGroundPos();

        // Converts mouse position to the grid
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        // Checks validity of placement
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedInteractableIndex);

        // If placementValidity is false, return
        if (placementValidity == false)
            return;

        // Gets interactable prefab by swapping index
        GameObject newInteractable = Instantiate(database.interactableData[selectedInteractableIndex].Prefab);

        // Converts grid position back to world position
        newInteractable.transform.position = grid.CellToWorld(gridPosition);

        // Adds new items to index
        placedGameObject.Add(newInteractable);

        // If selectedData and interactableData equals 0, return ground and block data
        GridData selectedData = database.interactableData[selectedInteractableIndex].ID == 0 ? groundData : blockData;

        // Accesses item from list
        selectedData.AddItemAt(gridPosition, database.interactableData[selectedInteractableIndex].Size, database.interactableData[selectedInteractableIndex].ID, placedGameObject.Count - 1);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedInteractableIndex)
    {
        // If selectedData and interactableData equals 0, return ground and block data
        GridData selectedData = database.interactableData[selectedInteractableIndex].ID == 0 ? groundData : blockData;

        // Returns size of interactableData
        return selectedData.CanPlaceItemAt(gridPosition, database.interactableData[selectedInteractableIndex].Size);
    }

    // Stops items from being placed in another item's place
    private void StopPlacement()
    {
        // Resets when index equals -1
        selectedInteractableIndex = -1;

        // Hides grid visual
        gridVisual.SetActive(false);

        // Hides indicator
        cellIndicator.SetActive(false);

        // Unassigns PlaceStructure to OnClicked
        inputManager.OnClicked -= PlaceStructure;

        // Unassigns StopPlacement to OnExit
        inputManager.OnExit -= StopPlacement;
    }

    private void Update()
    {
        // If selectedInteractableIndex is greater than 0, return
        if (selectedInteractableIndex < 0)
            return;

        // Gets the selected position of ground
        Vector3 mousePosition = inputManager.selectGroundPos();

        // Converts mouse position to the grid
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        // Checks validity of placement
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedInteractableIndex);

        // If placementValidity is false, make indicator red
        previewRenderer.material.color = placementValidity ? Color.lightGreen : Color.red;

        // Transforms the position of mouseIndicator
        mouseIndicator.transform.position = mousePosition;

        // Converts grid position back to world position
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
