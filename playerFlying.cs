using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlying : MonoBehaviour
{
    public float upForce = 0.5f;
    public float horizontalForce = 0.12f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * upForce, ForceMode2D.Force);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * horizontalInput * horizontalForce, ForceMode2D.Force);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; 
        }
        Vector3 characterPosition = transform.position;
        float characterHeight = spriteRenderer.bounds.extents.y;
        
    }
}
