using UnityEngine;

public class FruitHeal : MonoBehaviour
{
    // References player's health in BadCatHealth
    public BadCatHealth playerHealth;

    // Sets healing limit for fruit
    public int healthRegen = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Fruit heals player by 1 heart
            playerHealth.HealthRegen(healthRegen);

            // Destroys fruit when player touches it
            Destroy(gameObject);
        }
    }
}
