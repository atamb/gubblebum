using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tstf : MonoBehaviour
{
     
    public GameObject TstF;// Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TstF.SetActive(true);
        }
    }
}
