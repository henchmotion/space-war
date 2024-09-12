using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_timer = 3f;
    public Vector2 direction;
    public bool isEnemy = true;
    [SerializeField] private float damage;

    public CameraShake cameraShake;
    public int health = 1; // Bullet's health, set to 3 for example
    public GameObject explosionPrefab;


    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnEnable()
    {
        // Start the deactivation timer when the bullet is activated 
        Invoke("Deactivate", deactivate_timer);
    }

    private void OnDisable()
    {
        // Cancel the deactivation timer when the bullet is activated
        CancelInvoke();

    }
    // Update is called once per frame
     private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth1>().TakeDamage(damage);
        }
        else if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            Die(); // Player dies instantly on contact with the enemy
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // Subtract the damage from the enemy's health

        // Check if health is zero or below
        if (health <= 0)
        {
            Die(); // Call the Die function if health is zero
        }
    }

    void Die()
    {
        Explode();
        
        Destroy(gameObject); // Destroy the enemy game object

        if (cameraShake != null) ;
        {
            cameraShake.Shake();
        }
    }

    void Explode()
    {
        // Instantiate the explosion effect at the bullet's position and rotation
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}

