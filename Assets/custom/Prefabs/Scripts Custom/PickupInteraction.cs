using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteraction : MonoBehaviour
{
    public float interactDistance = 2.0f; // Adjust this distance as needed.
    public GameObject pickupText; // The text or UI element to display.

    private GameObject player;
    private bool isNearPickup = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Replace "Player" with your player tag.
        if (pickupText != null)
        {
            pickupText.SetActive(false);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Make sure to set the correct tag for the player.");
            return;
        }

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < interactDistance)
        {
            if (!isNearPickup)
            {
                isNearPickup = true;
                ShowPickupText(true);
            }

            if (Input.GetKeyDown(KeyCode.E)) // Change the key as needed.
            {
                // Add your interaction logic here when the player presses the specified key.
                // For example, you can pick up the item or trigger an event.
                Debug.Log("Interact with Pickup");
            }
        }
        else
        {
            if (isNearPickup)
            {
                isNearPickup = false;
                ShowPickupText(false);
            }
        }
    }

    private void ShowPickupText(bool show)
    {
        if (pickupText != null)
        {
            pickupText.SetActive(show);
        }
    }
}
