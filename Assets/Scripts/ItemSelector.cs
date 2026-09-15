using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public static GameObject lastSelectedItem;
    private void OnMouseDown()
    {
        lastSelectedItem = transform.root.gameObject;

        Debug.Log(gameObject.name, gameObject);
    }
}
