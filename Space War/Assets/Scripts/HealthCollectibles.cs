using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibles : MonoBehaviour
{
    [SerializeField] private float healthValue;


    [Header("SFX")]
    [SerializeField] private AudioClip lifeSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth1>().AddHealth(healthValue);
            gameObject.SetActive(false);
            //Destroy(other.gameObject);
            SoundManager.instance.PlaySound(lifeSound);
        }
        else if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }



    }
}
