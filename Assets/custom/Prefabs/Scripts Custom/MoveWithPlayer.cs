using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public float parallaxFactor = 0.5f; // Adjust this value to control the parallax effect
    private Transform playerTransform;
    private Vector3 startPosition;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player is tagged as "Player"
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the horizontal offset based on the player's movement
        float horizontalOffset = (playerTransform.position.x - startPosition.x) * parallaxFactor;

        // Update the cloud's position to create the parallax effect
        transform.position = new Vector3(startPosition.x + horizontalOffset, transform.position.y, transform.position.z);
    }
}