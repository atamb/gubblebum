using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private float moveSpeed = 2.2f;
    public float jumpForce = 1.8f;

    private Rigidbody2D rb;
    private bool isJumping = false;
    public Animator animator;
    public float moveX;
    public AbilityController ac;
    public GameObject gameOver;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ac = GameObject.Find("AbilityController").GetComponent<AbilityController>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
        RotationSettings();
        AnimController();
    }
    
    
    private void AnimController()
    {
        if (Mathf.Abs(moveX) >= 0.1)
        {
             animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("mintGum"))
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("berryGum"))
        {
            ac.PowerBerry = true;
        }
        if (collision.gameObject.CompareTag("mintGum"))
        {
            ac.PowerMint = true;
        }
        if (collision.gameObject.CompareTag("finisher"))
        {
            transform.position = new Vector2(70.6f,transform.position.y);
            GetComponent<playerFlying>().enabled = true;
        }
        if (collision.gameObject.CompareTag("finisherr"))
        {
            transform.position = new Vector2(95,11);
            GetComponent<playerFlying>().enabled = false;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<BubblegumBlowing>().enabled = false;
            GetComponent<PlayerBullet>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            ac.isDark = true;
            Invoke("LetsGo", 2);
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            gameOver.SetActive(true);
            if (transform.position.x < 8.8f)
            {
                transform.position = new Vector2(-8, 3);
            }
            else if (transform.position.x > 8.8f && transform.position.x < 27.3f)
            {
                transform.position = new Vector2(9, -1.5f);
            }
            else if (transform.position.x > 27.3f && transform.position.x < 45.15f)
            {
                transform.position = new Vector2(28.3f, 1.25f);
            }
            else if (transform.position.x > 45.15f && transform.position.x < 63f)
            {
                transform.position = new Vector2(46.15f, -1);
            }
            else if (transform.position.x > 63f)
            {
                transform.position = new Vector2(70.5f, -0.5f);
            }
        }
    }

    public void LetsGo()
    {
        SceneManager.LoadScene(2);
    }
    public void RotationSettings(){
        if (moveX < -0.1f && transform.eulerAngles.y == 0f)
        {
            transform.Rotate(0, -180, 0);
        } 
        else if (moveX > 0.1f && transform.eulerAngles.y == 180f)
        {
            transform.Rotate(0, 180, 0);
        } 
    }

}
