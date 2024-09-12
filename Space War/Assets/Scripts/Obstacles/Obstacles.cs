using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float damage;


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

}
