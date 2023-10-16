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
    private bool isColliding1 = false;
    private bool isColliding2 = false;
    private bool candleGiven = false; // Added variable to track candle given

    private void Start()
    {
        // Disable the text at the start
        textPop.enabled = false;
        textPop2.enabled = false;
        textPopB.enabled = false; // Disable "TextPop.b" at the start
        textpop2B.enabled = false;
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

        if (col.gameObject.tag == "Pickup") // Object called candle
        {
            candleGiven = true;
        }

    }
}