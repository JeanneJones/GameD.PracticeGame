using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private float cloudWidth;

    private void Start()
    {
        // Get the width of the cloud sprite
        cloudWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        // Move the cloud to the left
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        // Calculate the right edge of the cloud
        float cloudRightEdge = transform.position.x + cloudWidth / 2;

        // Check if the cloud's right edge has moved completely out of the camera's view
        if (cloudRightEdge < Camera.main.ViewportToWorldPoint(Vector3.zero).x)
        {
            // Calculate a new position to reappear on the right side of the camera
            float newCloudRightEdge = Camera.main.ViewportToWorldPoint(Vector3.one).x + cloudWidth / 2;

            // Set the cloud's position to the new position
            transform.position = new Vector3(newCloudRightEdge, transform.position.y, transform.position.z);
        }
    }
}
