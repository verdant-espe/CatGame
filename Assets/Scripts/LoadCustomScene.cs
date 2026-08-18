using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCustomScene : MonoBehaviour
{
    // Loads in the selected terrain by its index number
   public void LoadTerrain(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
