using UnityEngine;

public class FruitHeal : MonoBehaviour
{
    // References player's health in BadCatHealth
    private BadCatHealth playerHealth;

    // Sets healing limit for fruit
    public int healthRegen = 1;

    private void Start()
    {
        playerHealth = GameObject.Find("BadCat").GetComponent<BadCatHealth>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Fruit heals player by 1 heart
            playerHealth.HealthRegen(healthRegen);

            // Destroys fruit when player touches it
            Destroy(gameObject);
        }
    }
}
