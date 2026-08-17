using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCustomScene : MonoBehaviour
{
    // Loads in the Grassland Terrain
   public void OnStartCLick()
    {
        SceneManager.LoadScene("Grassland");
    }
}
