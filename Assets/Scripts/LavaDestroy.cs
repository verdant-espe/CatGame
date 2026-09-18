using Unity.VisualScripting;
using UnityEngine;

public class LavaDestroy : MonoBehaviour
{
    // Gets game object
    GameObject interactable;
    void OnTriggerEnter(Collider other)
    {
        // Finds any game object with the tag "Interactable"
        interactable = GameObject.FindWithTag("Interactable");

        // If lava touches interactable, destroy interactable
        if (gameObject.name == "Lava")
        {
            Destroy(interactable);
        }
    }
}
