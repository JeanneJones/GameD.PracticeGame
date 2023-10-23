using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTrigger : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.ResetTrigger("MoveLeft");
        anim.ResetTrigger("MoveRight");
        anim.ResetTrigger("Idle");

        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0f)
        {
            // Right movement
            anim.SetTrigger("MoveRight");
            transform.localScale = new Vector3(1, 1, 1); // Flip sprite to face right
        }
        else if (horizontalInput < 0f)
        {
            // Left movement
            anim.SetTrigger("MoveLeft");
            transform.localScale = new Vector3(-1, 1, 1); // Flip sprite to face left
        }
        else
        {
            // Idle state when not moving horizontally
            anim.SetTrigger("Idle");
        }
    }
}
