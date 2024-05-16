using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private PlayerManager playerManager;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            CameraTarget.Instance.shakeCamera(5, 1);
            Destroy(this.gameObject);

        }
        if (collision.CompareTag("Player"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerManager = player.GetComponent<PlayerManager>();
            Destroy(this.gameObject);
            playerManager.healthLose(1f);
        }
    }
}
