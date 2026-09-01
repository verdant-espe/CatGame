using UnityEngine;
using UnityEngine.UI;

public class BatCatHealth : MonoBehaviour
{
    // Creates a public int for health
    public int health;

    // Creates a public int for the number of hearts
    public int maxHearts;


    // Accesses heart sprites on UI
    public Image[] hearts;

    // Creates a public int for the full heart sprite
    public Sprite fullHeart;

    // Creates a public int for the empty heart sprite
    public Sprite emptyHeart;

    //Makes sure player does not have more health than number of hearts
    private void FixedUpdate()
    {
        if(health > maxHearts)
        {
            health = maxHearts;
        }
    }

    private void Update()
    {
        // Loop runs as long as i is less than number of hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            // if i is less than health, display full heart
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            // Else, display empty heart
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // If i is less than number of hearts, make heart of index i visible
            if (i < maxHearts)
            {
                hearts[i].enabled = true;
            }
            // Else, hide hearts
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
