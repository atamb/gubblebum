using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sstf : MonoBehaviour
{
    
    public GameObject SstF;// Start is called before the first frame update
    public MintGum gm;

    private void Start()
    {
        gm = GameObject.Find("mintGum").GetComponent<MintGum>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(gm.FalSayisi == 0)
                SstF.SetActive(true);
        }
    }
}
