using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth1 : MonoBehaviour
{

    [Header("Health")]

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [SerializeField] private AudioClip hurtSound;


    public void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            //StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }



    

    void Die()
    {
        // Add logic for plaer death, e.g play death animation, show game over  screen
        //Debug.Log("Player Died");
        Destroy(gameObject); // Destroy the Player GameObject
        //anim.SetTrigger("Die");
        //SoundManager.instance.PlaySound(deathSound);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision object is an enemy bullet
        EnemyBullet bullet = collision.GetComponent<EnemyBullet>();

        if (bullet != null && bullet.isEnemy)
        {
            TakeDamage(1); //Assume each bullet does 1 damage
            Destroy(bullet.gameObject); // Destroy the bullet
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an enemy
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die(); // Player dies instantly on contact with the enemy
        }

    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

}
