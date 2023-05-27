using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ilkSakiz : MonoBehaviour
{
    public AudioSource falsesi;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            falsesi.Play();
            gameObject.SetActive(false);
        }
    }
}
