using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float damage;
    public GameObject explosionPrefab;
    [SerializeField] private AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth1>().TakeDamage(damage);
            Destroy(this.gameObject);
            SoundManager.instance.PlaySound(explodeSound);
            Explode();

        }
        else if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }



        //else if (collision.tag == "Player")
        //{
        //    Destroy(player.gameObject);
        //}
    }

    void Explode()
    {
        // Instantiate the explosion effect at the bullet's position and rotation
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }

}
