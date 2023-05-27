using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public bool isDead;
    public int fal;

    public GameObject YouDead, FstF, SecF, TrdF;
    // Start is called before the first frame update
    void Start()
    {
        fal = 0;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            YouDead.SetActive(true);
        }

        switch (fal)
        {
            case 1:
                FstF.SetActive(true);
                break;
            case 2:
                SecF.SetActive(true);
                break;
            case 3:
                TrdF.SetActive(true);
                break;
        }
            
            
    }
}
