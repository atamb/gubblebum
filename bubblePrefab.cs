using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblePrefab : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        Invoke("DestroyBlock", 4);
    }
    private void DestroyBlock()
    {
        gameObject.SetActive(false);
    }
}
