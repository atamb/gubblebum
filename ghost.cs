using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float xmin;
    public float xmax;
    private int direction = 1;
    public Animator animator;

    Rigidbody2D rb;
    public bool isF;
    public AudioSource donmasesi;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isF = false;
    }

    private void Update()
    {
        if (!isF)
        {
            rb.velocity = new Vector2(direction * moveSpeed, 0);

            if (transform.position.x <= xmin)
            {
                transform.position = new Vector2(xmin, transform.position.y);
                direction = 1;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            if (transform.position.x >= xmax)
            {
                transform.position = new Vector2(xmax, transform.position.y);
                direction = -1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            GetComponent<CapsuleCollider2D> ().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "mintBullet")
        {
            animator.SetBool("isFrozen", true);
            isF = true;
            donmasesi.Play();
        }
    }
    
}
