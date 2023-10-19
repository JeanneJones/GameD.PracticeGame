using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parallax : MonoBehaviour
{

    [SerializeField] private Vector2 parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        /// Check if the background has moved to the left far enough to repeat it
        if (cameraTransform.position.x - transform.position.x >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(transform.position.x + offsetPositionX, transform.position.y);
        }
        /// Check if the background has moved to the right far enough to repeat it
        else if (transform.position.x - cameraTransform.position.x >= textureUnitSizeX)
        {
            float offsetPositionX = (transform.position.x - cameraTransform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(transform.position.x - offsetPositionX, transform.position.y);
        }
    }
    

}
