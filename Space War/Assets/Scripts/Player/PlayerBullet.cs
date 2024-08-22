using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public float speed = 15;
    [SerializeField] private float TimebeforeDestroy = 2;

    public bool isEnemy = false;

    private void Start()
    {
        Destroy(gameObject, TimebeforeDestroy);
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
