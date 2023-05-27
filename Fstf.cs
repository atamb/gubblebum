using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fstf : MonoBehaviour
{
    
    public GameObject FstF;// Start is called before the first frame update
    public gumStart bg;
    
    private void Start()
    {
        bg = GameObject.Find("berryGum").GetComponent<gumStart>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(bg.FalSayisi ==0)
                FstF.SetActive(true);
        }
    }
}
