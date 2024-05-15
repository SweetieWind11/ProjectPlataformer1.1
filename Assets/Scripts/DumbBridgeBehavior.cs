using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbBridgeBehavior : MonoBehaviour
{
    public Animator bridge;
    public GameObject father;
    public GameObject PointToGo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bridgeEnd()
    {
        bridge.SetBool("StartB", false);
    }
}