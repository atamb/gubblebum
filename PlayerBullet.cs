using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject blockPrefab;
    public float blockSpeed = 5f;
    public float blockDuration = 0.8f;
    private GameObject currentBlock;
    public Transform bulletSpawnPoint;
    private Rigidbody2D blockRigidbody;

    private Rigidbody2D rb;
    public int isRight;
    public GameObject pm;
    public AbilityController ac;
    public float timeRemaining;
    private bool isTrue;
    public float bulletLifetime = 0.5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GameObject.Find("Player");
        ac = GameObject.Find("AbilityController").GetComponent<AbilityController>();
        timeRemaining = 0.75f;
    }

    private void Update()
    {
        if (pm.transform.rotation.eulerAngles.y == 180)
        {
            isRight = -1;
        }
        else if(pm.transform.rotation.eulerAngles.y == 0)
        {
            isRight = 1;
        }
        
        if (isTrue)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0)
        {
            timeRemaining = 0.75f;
            isTrue = false;
        }

        if (ac.PowerMint == true && Input.GetKeyDown(KeyCode.Q) && timeRemaining == 0.75f)
        {
            CreateBlock();
            isTrue = true;
        }
        
    }
    
    private void CreateBlock()
    {
        currentBlock = Instantiate(blockPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        blockRigidbody = currentBlock.GetComponent<Rigidbody2D>();
        blockRigidbody.velocity = new Vector2(blockSpeed * isRight, 0f);
        MoveBlock();
        }

    private void MoveBlock()
    {
        currentBlock.transform.Translate(Vector3.right * blockSpeed * Time.deltaTime);
        Destroy(currentBlock, bulletLifetime);
    }
    
}
