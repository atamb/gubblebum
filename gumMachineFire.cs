using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumMachineFire : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 0.2f; 
    public float bulletSpeed = 10f;
    public float bulletLifetime = 3f;
    public Transform spawnPoint;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;


        if (spawnTimer >= spawnInterval)
        {
            SpawnBullet();
            spawnTimer = 0f;
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.up * bulletSpeed;


        Destroy(bullet, bulletLifetime);
    }
}
