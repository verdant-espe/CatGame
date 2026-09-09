using UnityEngine;

public class PlacementState : IBuildingState
{
    // References fields from PlacementSystem
    private int selectedInteractableIndex = -1;
    int ID;
    Grid grid;
    InteractablesDatabase database;
    GridData groundData;
    GridData blockData;
    InteractablePlacer interactablePlacer;
    GameObject cellIndicator;
    Renderer previewRenderer;

    // Called when StartPlacement is active
    public PlacementState(int iD,
                          Grid grid,
                          InteractablesDatabase database,
                          GridData groundData,
                          GridData blockData,
                          InteractablePlacer interactablePlacer)
    {
        ID = iD;
        this.grid = grid;
        this.database = database;
        this.groundData = groundData;
        this.blockData = blockData;
        this.interactablePlacer = interactablePlacer;

        // If selectedInteractableIndex is greater than -1, index has found item ID
        if (selectedInteractableIndex > -1)
        {
            // Returns index of an interactable
            selectedInteractableIndex = database.interactableData.FindIndex(data => data.ID == ID);

            // If interactable doesn't have ID, print message to debug console
            if (selectedInteractableIndex < 0)
            {
                Debug.LogError($"No ID found {ID}");
                return;
            }

            // Shows where interactable will be placed
            cellIndicator.SetActive(true);
        }
        // Else, throw exception stating that there is no item with selected ID
        else
            throw new System.Exception($"No item with ID {iD}");
    }

    public void EndState()
    {
        // When state ends, disable cellIndicator
        cellIndicator.SetActive(false);
    }

    public void OnAction(Vector3Int gridPosition)
    {
        // Checks validity of placement
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedInteractableIndex);

        // If placementValidity is false, return
        if (placementValidity == false)
            return;

        // sets index equal to PlaceItem
        int index = interactablePlacer.PlaceItem(database.interactableData[selectedInteractableIndex].Prefab, grid.CellToWorld(gridPosition));

        // If selectedData and interactableData equals 0, return ground and block data
        GridData selectedData = database.interactableData[selectedInteractableIndex].ID == 0 ? groundData : blockData;

        // Accesses item from list
        selectedData.AddItemAt(gridPosition, database.interactableData[selectedInteractableIndex].Size, database.interactableData[selectedInteractableIndex].ID, index);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedInteractableIndex)
    {
        // If selectedData and interactableData equals 0, return ground and block data
        GridData selectedData = database.interactableData[selectedInteractableIndex].ID == 0 ? groundData : blockData;

        // Returns size of interactableData
        return selectedData.CanPlaceItemAt(gridPosition, database.interactableData[selectedInteractableIndex].Size);
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        // Checks validity of placement
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedInteractableIndex);

        // If placementValidity is false, make indicator red
        previewRenderer.material.color = placementValidity ? Color.lightGreen : Color.red;
    }
}
