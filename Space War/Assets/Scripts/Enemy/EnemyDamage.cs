using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public CameraShake cameraShake;
    public int health = 1; // Enemy's health, set to 3 for example
    public GameObject explosionPrefab;
    [SerializeField] private AudioClip explodeSound;
    [SerializeField] private AudioClip hurtSound;

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the enemy is a player's bullet
        if (other.CompareTag("Player Bullet"))
        {
            TakeDamage(1); // Reduce health by 1 for each bullet hit

            // Destroy the bullet after it hits the enemy
            Destroy(other.gameObject);
            SoundManager.instance.PlaySound(explodeSound);
        }

        if (other.CompareTag("Player"))
        {
            Die(); // Player dies instantly on contact with the enemy
            Explode();
            SoundManager.instance.PlaySound(hurtSound);



            Debug.Log("Enemy Destroy");
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // Subtract the damage from the enemy's health

        // Check if health is zero or below
        if (health <= 0)
        {
            Die(); // Call the Die function if health is zero
            Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an enemy
        if (collision.gameObject.CompareTag("Player"))
        {
   
            Die(); // Player dies instantly on contact with the enemy
            Explode();

            Debug.Log("Enemy Destroy");
            SoundManager.instance.PlaySound(hurtSound);
        }
    }

    void Die()
    {
        
        // You can add death effects, score increase, etc., here
        Destroy(gameObject); // Destroy the enemy game object

        
    }

    void Explode()
    {
        // Instantiate the explosion effect at the enemy's position and rotation
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1f);

        if (cameraShake != null) ;
        {
            cameraShake.Shake();

        
        }
    }
}
