using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Border" tag
        if (other.CompareTag("Border"))
        {
            // Destroy the bullet game object
            Destroy(gameObject);
        }
    }
}

