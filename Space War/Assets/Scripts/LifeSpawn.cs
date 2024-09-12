using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawn : MonoBehaviour 
{
    public GameObject lifePrefab;   // The collectible prefab to spawn
    public float spawnInterval = 2f; // Time interval between spawns
    public float spawnXOffset = 10f; // How far off-screen to the right enemies spawn
    public float moveSpeed = 5f;     // Speed at which enemies move left
    public float minY = -4f;         // Minimum y position for spawning
    public float maxY = 4f;          // Maximum y position for spawning

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Track time and spawn enemies at regular intervals
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            HealthCollectible();
            timeSinceLastSpawn = 0f;
        }
    }

    void HealthCollectible()
    {
        // Randomize the y position within a specified range
        float spawnY = Random.Range(minY, maxY);

        // Set the x position to the right side, off-screen
        float spawnX = Camera.main.transform.position.x + spawnXOffset;

        // Create the spawn position vector
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Instantiate the enemy at the spawn position
        GameObject life = Instantiate(lifePrefab, spawnPosition, Quaternion.identity);

        // Move the enemy left by applying velocity directly
        Rigidbody2D lifeRb = life.GetComponent<Rigidbody2D>();
        if (lifeRb != null)
        {
            lifeRb.velocity = Vector2.left * moveSpeed;
        }
    }
}
