using UnityEngine;

public class InteractableDamage : MonoBehaviour
{
    // References player's health in BadCatHealth
    public BadCatHealth playerHealth;

    // Sets damage for harmful items
    public int damage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Item damage deals player one damage
            playerHealth.TakeDamage(damage);
        }
    }
}
