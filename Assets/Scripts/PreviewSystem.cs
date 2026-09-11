using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    // References cellIndicator from PlacementSystem
    private GameObject cellIndicator;
    // References previewRenderer from PlacementSystem
    private Renderer previewRenderer;

    // Sets the cursor size
    private void PrepareCursor(Vector2Int size)
    {
        if (size.x > 0 || size.y > 0)
        {
            cellIndicator.transform.localScale = new Vector3(size.x, 1, size.y);
            previewRenderer.material.mainTextureScale = size;
        }
    }

    // Changes color of indicator
    private void ApplyFeedbackToPreview(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = 0.5f;
        previewRenderer.material.color = c;
    }

    // Applies color to cursor
    private void ApplyFeedbackToCursor(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
    }

    private void MoveCursor(Vector3 position)
    {
        cellIndicator.transform.position = position;
    }
    
    public void UpdatePosition(Vector3 position, bool validity)
    {
        MoveCursor(position);
        ApplyFeedbackToPreview(validity);
        ApplyFeedbackToCursor(validity);
    }

    // If cursor is over item, show remove preview
    internal void ShowRemovePreview()
    {
        PrepareCursor(Vector2Int.one);
        ApplyFeedbackToCursor(false);
    }

    // Stop showing remove preview when turned off
    public void StopShowingPreview()
    {
        cellIndicator.SetActive(false);
    }
}
