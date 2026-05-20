using UnityEngine;

public class SwimInWater : MonoBehaviour
{
    // References player
    public GameObject Player;

    // References Water
    public GameObject Water;

    // Sets gravity for when the player is in water
    public float waterGrav = 0.9f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // If player gets in water, gravity changes
    private void OnTriggerEnter(Collider other)
    {
        if (Player)
        {
            Physics.gravity = Vector3.down * waterGrav;
        }
    }
}
