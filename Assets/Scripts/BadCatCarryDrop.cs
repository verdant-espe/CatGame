using UnityEngine;

public class BadCatCarryDrop : MonoBehaviour
{
    [SerializeField] private Transform badcatCameraTransform;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Physics.Raycast(badcatCameraTransform.position, badcatCameraTransform.forward);
        }
    }
}
