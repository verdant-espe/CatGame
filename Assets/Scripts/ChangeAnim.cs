using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    // Creates a private Animator class
    private Animator catAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    // Controls the sprite's animations
        catAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Changes to walking sprite
        if(Input.GetKey(KeyCode.W))
        {
            catAnimator.SetBool("DoWalk", true);
        }
        // Changes back to idle sprite
        if (Input.GetKeyUp(KeyCode.W))
        {
            catAnimator.SetBool("DoWalk", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            catAnimator.SetBool("DoWalk", true);
        }
        // Changes back to idle sprite
        if (Input.GetKeyUp(KeyCode.A))
        {
            catAnimator.SetBool("DoWalk", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            catAnimator.SetBool("DoWalk", true);
            
        }
        // Changes back to idle sprite
        if (Input.GetKeyUp(KeyCode.S))
        {
            catAnimator.SetBool("DoWalk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            catAnimator.SetBool("DoWalk", true);
        }
        // Changes back to idle sprite
        if (Input.GetKeyUp(KeyCode.D))
        {
            catAnimator.SetBool("DoWalk", false);
        }


        // Changes to jump sprite
        if (Input.GetKeyDown(KeyCode.Space))
        {
            catAnimator.SetBool("DoJump", true);
        }

        // Changes back to idle sprite
        if (Input.GetKeyUp(KeyCode.Space))
        {
            catAnimator.SetBool("DoJump", false);
        }
    }
}
