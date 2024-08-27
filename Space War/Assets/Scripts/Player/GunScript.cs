using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public GameObject bulletprefab; // The bullet prefab to instantiate
    public Transform firePoint; // The point from where the bullet is fired


    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))

        {
            Shoot();
        }
    }

    



    // Update is called once per frame
    void Shoot()
    {
        // Instantiate the bullet at the fire point's position and rotation
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
    }
}
