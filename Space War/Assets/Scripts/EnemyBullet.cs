using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_timer = 3f;
    public Vector2 direction;
    public bool isEnemy = true;

   
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
}
