using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMessage : MonoBehaviour
{
    public TMP_Text textPop; // Reference to the first text object
    public TMP_Text textPop2; // Reference to the second text object
    public TMP_Text textPopB; // textpop follow up
    public TMP_Text textpop2B; // textpop2 follow up
    public TMP_Text TextBat;   //bat text


    private bool isColliding1 = false;
    private bool isColliding2 = false;
    private bool isColliding3 = false;
    private bool candleGiven = false; // track candle given
    private bool RedFlowerPickup2 = false;

    private void Start()
    {
        // Disable the text at the start
        textPop.enabled = false;
        textPop2.enabled = false;
        textPopB.enabled = false; 
        textpop2B.enabled = false;
        TextBat.enabled = false;
    }

    private void Update()
    {
        if (!isColliding1)
        {
            Transform player = transform;
            Transform whisp1 = textPop.transform;
            float distance1 = Vector2.Distance(whisp1.position, player.position);

            if (distance1 < 1.5)
            {
                textPop.enabled = true;
                textPop.text = "Oh no, my pumpkin is unlit! Can you help me find my candle? If you do find it, simply press E to grab it.";
            }
            else
            {
                textPop.enabled = false;
            }
        }

        if (!isColliding2)
        {
            Transform player = transform;
            Transform whisp2 = textPop2.transform;
            float distance2 = Vector2.Distance(whisp2.position, player.position);

            if (distance2 < 1.5)
            {
                textPop2.enabled = true;
                textPop2.text = "I love red flowers but I can't find any ...";
            }
            else
            {
                textPop2.enabled = false;
            }

            if (candleGiven) // Check if the candle has been given
            {
                textPop.enabled = false; // Hide the first text
                textPopB.enabled = true; // Show "TextPop.b"
                textPopB.text = "Thank you! Your reward is a hint: Behind the forest's curtain, a secret to unwind, Two to the right, a red bloom you'll find.";
            }

            if (RedFlowerPickup2)   // Check if the RedFlower has been picked up
            {
                textPop2.enabled = false;
                textpop2B.enabled = true;
                textpop2B.text = "You found one! Thank you. Now I can happily rest";
            }

            if (!RedFlowerPickup2 && !isColliding2)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f); // Adjust the radius as needed
                foreach (Collider2D col in colliders)
                {
                    if (col.gameObject.tag == "Pickup2" && Input.GetKeyDown(KeyCode.E))
                    {
                        RedFlowerPickup2 = true;
                        // Handle pickup logic here
                    }
                }
            }
        }

        if (!isColliding3)
        {
            Transform player = transform;
            Transform Bat2 = TextBat.transform;
            float distanceBat2 = Vector2.Distance(Bat2.position, player.position);

            if (distanceBat2 < 1.5)
            {
                TextBat.enabled = true;
                TextBat.text = "*Shriek*";
            }
            else
            {
                TextBat.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TextPop")
        {
            isColliding1 = true;
        }

        if (col.gameObject.tag == "TextPop2")
        {
            isColliding2 = true;
        }




        if (col.gameObject.tag == "TextBat")
        {
            isColliding3 = true;
        }






        if (col.gameObject.tag == "Pickup") // Object called candle
        {
            candleGiven = true;
        }

        if (col.gameObject.tag == "Pickup2") // Object called RedFlower
        {
            // Check if the player presses a key to pick up the RedFlower (e.g., 'E' key)
            if (Input.GetKeyDown(KeyCode.E))
            {
                RedFlowerPickup2 = true;
            }
        }
    }
}
