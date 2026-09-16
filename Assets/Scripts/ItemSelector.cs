using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    // Creates a field for the last selected item
    public static GameObject lastSelectedItem;

    private void OnMouseDown()
    {
        // Gets the root of the last selected item
        lastSelectedItem = transform.root.gameObject;

        // Tells if you have clicked on the item again
        Debug.Log(gameObject.name, gameObject);
    }
}
