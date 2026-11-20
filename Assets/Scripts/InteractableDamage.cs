using UnityEngine;

public class InteractableDamage : MonoBehaviour
{
    // References player's health in BadCatHealth
    private BadCatHealth playerHealth;

    // Sets damage for harmful items
    public int damage = 1;

    private void Start()
    {
        playerHealth = GameObject.Find("BadCat").GetComponent<BadCatHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Item damage deals player one damage
            playerHealth.TakeDamage(damage);
        }
    }
}
