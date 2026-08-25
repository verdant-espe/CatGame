using System;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    // Use to detect which position on the ground you're selecting
    [SerializeField] GameObject mouseIndicator, cellIndicator;

    // Creates a private property for InputManager
    [SerializeField] private InputManager inputManager;

    // References the grid
    [SerializeField] private Grid grid;

    // References database
    [SerializeField] private InteractablesDatabase database;

    // References interactable selected from index
    private int selectedInteractableIndex = -1;

    // Triggers on and off grid visualization
    [SerializeField] private GameObject gridVisual;

    private void Start()
    {
        StopPlacement();
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



        // Converts grid position back to world position
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

    private void StopPlacement()
    {
        // Resets when index equals -1
        selectedInteractableIndex = -1;

        // Hides grid visual
        gridVisual.SetActive(false);

        // Hides indicator
        cellIndicator.SetActive(false);

        // Unassigns to OnClicked
        inputManager.OnClicked -= PlaceStructure;

        // Unassigns to OnExit
        inputManager.OnExit -= StopPlacement;
    }

    private void Update()
    {
        // Gets the selected position of ground
        Vector3 mousePosition = inputManager.selectGroundPos();

        // Converts mouse position to the grid
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        // Transforms the position of mouseIndicator
        mouseIndicator.transform.position = mousePosition;

        // Converts grid position back to world position
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
