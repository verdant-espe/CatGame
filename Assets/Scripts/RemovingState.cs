using UnityEditor.Timeline.Actions;
using UnityEngine;

public class RemovingState : IBuildingState
{
    // References fields from PlacementState
    private int gameObjectIndex = -1;
    Grid grid;
    GridData groundData;
    GridData blockData;
    InteractablePlacer interactablePlacer;
    PreviewSystem preview;

    public RemovingState(Grid grid,
                         GridData groundData,
                         GridData blockData,
                         InteractablePlacer interactablePlacer,
                         PreviewSystem preview)
    {
        this.grid = grid;
        this.groundData = groundData;
        this.blockData = blockData;
        this.interactablePlacer = interactablePlacer;
        this.preview = preview;
        // Shows remove preview
        preview.ShowRemovePreview();
    }

    public void EndState()
    {
        // Stops showing placement preview
        preview.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        // If something is occupying the space, selectedData is equal to blockData
        GridData selectedData = null;
        if(blockData.CanPlaceItemAt(gridPosition,Vector2Int.one) == false)
        {
            selectedData = blockData;
        }
        // Else, selectedData is equal to groundData
        else if(blockData.CanPlaceItemAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = groundData;
        }

        // If selectedData is null. return
        if(selectedData == null)
        {

        }
        // Else, get representation index
        else
        {
            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            // If gameObjectIndex in equal to -1, return
            if (gameObjectIndex == -1)
                return;

            // Start removing item
            selectedData.RemoveItemAt(gridPosition);
            interactablePlacer.RemoveItemAt(gameObjectIndex);
        }
        // Updates preview
        Vector3 cellPosition = grid.CellToWorld(gridPosition);
        preview.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition));
    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        // Checks if the item selection is valid
        return !(blockData.CanPlaceItemAt(gridPosition, Vector2Int.one) && blockData.CanPlaceItemAt(gridPosition, Vector2Int.one));
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        // Checks if selection is valid and removes item from grid
        bool validity = CheckIfSelectionIsValid(gridPosition);
        preview.UpdatePosition(grid.CellToWorld(gridPosition), validity);

    }
}
