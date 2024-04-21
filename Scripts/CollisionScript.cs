using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Destructible")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
