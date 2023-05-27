using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player.transform.position.x < 8.8f)
        {
            transform.position = new Vector3(0, 0,-10);
        }
        else if (player.transform.position.x > 8.8f && player.transform.position.x < 27.3f)
        {
            transform.position = new Vector3(18, 0, -10);
        }
        else if (player.transform.position.x > 27.3f && player.transform.position.x < 45.15f)
        {
            transform.position = new Vector3(36, 0, -10);
        }
        else if (player.transform.position.x > 45.15f && player.transform.position.x < 63f)
        {
            transform.position = new Vector3(54, 0, -10);
        }
        else if (player.transform.position.x > 63f && player.transform.position.x < 90f)
        {
            transform.position = new Vector3(79, 0, -10);
        }
        else if (player.transform.position.x > 90f)
        {
            transform.position = new Vector3(97, 0, -10);
        }
    }
}
