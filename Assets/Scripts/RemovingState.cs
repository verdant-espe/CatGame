using UnityEngine;

public class RemovingState : MonoBehaviour
{
    // References fields from PlacementState
    private int gameObjectIndex = -1;
    Grid grid;
    GridData groundData;
    GridData blockData;
    InteractablePlacer interactablePlacer;
    GameObject cellIndicator;
    Renderer previewRenderer;

    // Shows remove preview
    public RemovingState(Grid grid,
                         GridData groundData,
                         GridData blockData,
                         InteractablePlacer interactablePlacer,
                         GameObject cellIndicator,
                         Renderer previewRenderer)
    {
        this.grid = grid;
        this.groundData = groundData;
        this.blockData = blockData;
        this.interactablePlacer = interactablePlacer;
        this.cellIndicator = cellIndicator;
        this.previewRenderer = previewRenderer;

        //previewRenderer.ShowRemovePreview();
    }
}
