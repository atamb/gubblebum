using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumStart : MonoBehaviour
{
    public int FalSayisi = 0;
    public GameObject Gum;
    public GameObject Fal;
    public AbilityController ac;
    public AudioSource falsesi;
    
    // Update is called once per frame
    void Start()
    {
        ac = GameObject.Find("AbilityController").GetComponent<AbilityController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            falsesi.Play();
            ac.PowerBerry = true;
            Gum.SetActive(false);
            GetComponent<BoxCollider2D> ().enabled = false;
            Invoke("SettingActive", 15f);
        }
    }

    private void SettingActive()
    {
        if (FalSayisi == 0)
        {
            Destroy(Fal);
            FalSayisi += 1;
        }
        Gum.SetActive(true);
        GetComponent<BoxCollider2D> ().enabled = true;
        ac.PowerBerry = false;
    }
}
