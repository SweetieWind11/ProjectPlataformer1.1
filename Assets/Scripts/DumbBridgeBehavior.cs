using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbBridgeBehavior : MonoBehaviour
{
    public Animator bridge;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bridge.SetBool("Destroy", true);
        }
    }
    public void bridgeEnd()
    {
        bridge.SetBool("StartB", false);
    }
    public void destroyEnd()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Destroy(gameObject);
    }
}