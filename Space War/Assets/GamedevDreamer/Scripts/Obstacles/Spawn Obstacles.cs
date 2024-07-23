using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
   [SerializeField] public GameObject Obstacle;
   [SerializeField] public  float maxX;
   [SerializeField] public  float minX;
   [SerializeField] public  float maxY;
   [SerializeField] public float minY;
   [SerializeField] public  float timeBetweenSpawn;
    private float spawnTime;
   
    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(Obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
