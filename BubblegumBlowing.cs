using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblegumBlowing : MonoBehaviour
{
    private float moveSpeed = 3f;
    private float jumpForce = 3.2f;
    public GameObject blockPrefab;
    public float blockSpeed = 5f;
    public float blockDuration = 0.8f;

    private bool isBlockActive = false;
    private GameObject currentBlock;
    public Transform bulletSpawnPoint;
    private Rigidbody2D blockRigidbody;
    public GameObject gumStart;



    private Rigidbody2D rb;
    private bool isJumping = false;
    public int isRight;
    public GameObject pm;
    public AbilityController ac;
    public AudioSource bubbleSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GameObject.Find("Player");
        ac = GameObject.Find("AbilityController").GetComponent<AbilityController>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        if (pm.transform.rotation.eulerAngles.y == 180)
        {
            isRight = -1;
        }
        else if(pm.transform.rotation.eulerAngles.y == 0)
        {
            isRight = 1;
        }

        if (ac.PowerBerry == true && Input.GetKeyDown(KeyCode.E) && !isBlockActive)
        {
            gumStart.SetActive(true);
            Invoke("MakeSound", 0.5f);
            Invoke("CreateBlock", 1);
            isBlockActive = true;
            Invoke("GumCancelling", 1);
        }
        
    }

    private void GumCancelling()
    {
        gumStart.SetActive(false);
    }

    private void MakeSound()
    {
        bubbleSound.Play();
    }
    private void CreateBlock()
    {
        currentBlock = Instantiate(blockPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        blockRigidbody = currentBlock.GetComponent<Rigidbody2D>();
        blockRigidbody.velocity = new Vector2(blockSpeed * isRight, 0f);
        if (isBlockActive)
        {
            MoveBlock();
        }
        Invoke("DeactivateBlock", blockDuration);
    }

    private void MoveBlock()
    {
        currentBlock.transform.Translate(Vector3.right * blockSpeed * Time.deltaTime);
    }

    private void DeactivateBlock()
    {
        blockRigidbody.velocity = Vector2.zero;
        isBlockActive = false;
        blockRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
