using UnityEngine;

public class InteractableDamage : MonoBehaviour
{
    // References player's health in BadCatHealth
    public BadCatHealth playerHealth;

    // Sets damage for harmful items
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Item damage deals player one damage
            playerHealth.TakeDamage(damage);
        }
    }
}
