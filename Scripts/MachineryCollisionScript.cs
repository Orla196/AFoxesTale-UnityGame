using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldozerCollisionScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Machinery"
        if (collision.gameObject.tag == "Machinery")
        {
            // Destroy the current game object
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
