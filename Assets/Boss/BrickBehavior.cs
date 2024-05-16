using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    public Transform cameraController;
    public string cameraToShakeName;

    void Start()
    {
        GameObject mainCameraOBJ = GameObject.Find(cameraToShakeName);
        cameraController = mainCameraOBJ.transform;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            CameraTarget.Instance.shakeCamera(5, 1);
        }
    }
}
