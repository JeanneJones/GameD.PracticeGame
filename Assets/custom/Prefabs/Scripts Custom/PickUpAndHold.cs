﻿using UnityEngine;

[AddComponentMenu("Playground/Gameplay/Pick Up And Hold")]
public class PickUpAndHold : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.B;
    public KeyCode dropKey = KeyCode.B;

    public float pickUpDistance = 2f;
    private Transform carriedObject = null;

    private void Update()
    {
        bool justPickedUpSomething = false;

        if (Input.GetKeyDown(pickupKey) && carriedObject == null)
        {
            justPickedUpSomething = PickUp();
        }

        if (Input.GetKeyDown(dropKey) && carriedObject != null && !justPickedUpSomething)
        {
            Drop();
        }
    }

    public void Drop()
    {
        Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.velocity = Vector2.zero;
        }
        carriedObject.parent = null;
        carriedObject = null;
    }

    public bool PickUp()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        GameObject[] pickups2 = GameObject.FindGameObjectsWithTag("Pickup2");

        GameObject[] allPickups = new GameObject[pickups.Length + pickups2.Length];
        pickups.CopyTo(allPickups, 0);
        pickups2.CopyTo(allPickups, pickups.Length);

        float dist = pickUpDistance;
        for (int i = 0; i < allPickups.Length; i++)
        {
            float newDist = (transform.position - allPickups[i].transform.position).sqrMagnitude;
            if (newDist < dist)
            {
                carriedObject = allPickups[i].transform;
                dist = newDist;
            }
        }

        if (carriedObject != null)
        {
            Transform pickupParent = carriedObject.parent;
            if (pickupParent != null)
            {
                PickUpAndHold pickupScript = pickupParent.GetComponent<PickUpAndHold>();
                if (pickupScript != null)
                {
                    pickupScript.Drop();
                }
            }
            carriedObject.parent = gameObject.transform;
            Rigidbody2D rb2d = carriedObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.bodyType = RigidbodyType2D.Kinematic;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
