using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField]
    // Places preview item above ground
    private float yOffset = 0.06f;

    [SerializeField]
    // Shows the preview cell that will be selected
    private GameObject cellIndicator;
    // Shows preview item
    private GameObject previewItem;

    [SerializeField]
    // References preview material
    private Material previewMatPrefab;

    // Instantiates preview material
    private Material previewMatInstance;

    // References renderer for cell indicator
    private Renderer cellIndicatorRenderer;

    private void Start()
    {
        // Passes previewMatInstance into previewMatPrefab
        previewMatInstance = new Material(previewMatPrefab);
        // Disables cell indicator
        cellIndicator.SetActive(false);
        // Gets component of cell indicator renderer
        cellIndicatorRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }

    public void ShowPlacementPreview(GameObject prefab, Vector2Int size)
    {
        // Instantiates prefab item
        previewItem = Instantiate(prefab);
        // Gives original material
        Preparepreview(previewItem);
        // Sets size of grid preview
        PrepareCursor(size);
        // Sets indicator active 
        cellIndicator.SetActive(true);
    }

    private void PrepareCursor(Vector2Int size)
    {
        // If size x and size y are greater than 0,
        if(size.x > 0 || size.y > 0)
        {
            // Increases size of cell indicator
            cellIndicator.transform.localScale = new Vector3(size.x, 0.1f, size.y);
            // Sets tiling of material to be equal to item size
            cellIndicatorRenderer.material.mainTextureScale = size;
        }
    }

    private void Preparepreview(GameObject previewItem)
    {
        // Gets the components in previewItem
        Renderer[] renderers = previewItem.GetComponentsInChildren<Renderer>();
        
        // Loops through each renderer
        foreach(Renderer renderer in renderers)
        {
            // Assigns all materials for the preview material
            Material[] materials = renderer.materials;
            for(int i = 0; i < materials.Length; i++)
            {
                materials[i] = previewMatInstance;
            }
            // Modifies material of item
            renderer.materials = materials;
        }
    }

    public void StopPreview()
    {
        // Disables cell indicator
        cellIndicator.SetActive(false);
        // Destroys the preview item
        Destroy(previewItem);
    }

    public void UpdatePosition(Vector3 position, bool validity)
    {
        // Moves preview position
        MovePreview(position);

        // Moves cursor position
        MoveCursor(position);

        // Checks validity of feedback
        ApplyFeedback(validity);
    }

    private void ApplyFeedback(bool validity)
    {
        // If validity is true, change color to white, else change to red
        Color c = validity ? Color.lightGreen : Color.red;

        // Applies color to cell indicator
        cellIndicatorRenderer.material.color = c;

        // Transparency value applied to preview item
        c.a = 0.5f;

        // Sets preview material to c
        previewMatInstance.color = c;
    }

    private void MoveCursor(Vector3 position)
    {
        // Applies position to cell indicator
        cellIndicator.transform.position = position;
    }

    private void MovePreview(Vector3 position)
    {
        // Moves preview item
        previewItem.transform.position = new Vector3(position.x, position.y + yOffset, position.z);
    }
}
