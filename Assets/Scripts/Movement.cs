using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the directional movement
        float x = UnityEngine.Input.GetAxis("Horizontal");
        float y = UnityEngine.Input.GetAxis("Vertical");

        // change the velocity of the object so it will move
        rb.velocity = new Vector2(x, y) * speed;  

    }
}
