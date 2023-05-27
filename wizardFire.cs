using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardFire : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 1f; 
    public float bulletSpeed = -10f;
    public float bulletLifetime = 1.5f;
    public Transform spawnPoint;
    public Animator animator;
    public bool isF;
    Rigidbody2D rb;


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
        if (!isF)
        {
            GameObject bullet = Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = Vector2.left * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
        else
        {
            GetComponent<CapsuleCollider2D> ().enabled = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "mintBullet")
        {
            animator.SetBool("isFrozen", true);
            isF = true;
        }
    }
}
