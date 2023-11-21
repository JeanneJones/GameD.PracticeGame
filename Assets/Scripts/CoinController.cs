using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // make sure the player is colliding with me
        if(other.tag == "Player")
        {
            // find the particle system
            ParticleSystem mySystem = GameObject.FindGameObjectWithTag("Particles").GetComponent<ParticleSystem>();
            // put the particle system in the same place at the object
            mySystem.transform.position = this.transform.position;
            // display the particle system
            mySystem.Play();
            // reduce the health
            Health.Instance.myHealth--;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // once the player leaves the collision area, stop the particle system
        ParticleSystem mySystem = GameObject.FindGameObjectWithTag("Particles").GetComponent<ParticleSystem>();
        mySystem.Stop();
    }
}
