using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGum : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "mintBullet")
        {
            Destroy(this.gameObject);
        }
    }
}
