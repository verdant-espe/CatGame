using UnityEngine;

public class SwimInWater : MonoBehaviour
{
    // If player gets in water, gravity changes
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Physics.gravity = new Vector3(0, -2f, 0);
        }
    }

    // If player gets out of water, return to normal gravity
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Physics.gravity = new Vector3(0, -10f, 0);
        }
    }
}
