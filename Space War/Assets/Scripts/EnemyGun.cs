using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject bulletprefab; // The bullet prefab to instantiate
    public Transform firePoint; // The point from where the bullet is fired
    public float shootingInterval = 2f; // Time between shots

    private float shootingTimer;


    void Update()
    {
        // Increment the timer
        shootingTimer += Time.deltaTime;

        // shoot when the timer reaches the interval
        if (shootingTimer >= shootingInterval)

        {
            Shoot();
            shootingTimer = 0f;
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        // Instantiate the bullet at the fire point's position and rotation
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
    }
}
