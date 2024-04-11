using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemFlyBullet : MonoBehaviour
{
    private PlayerManager playerManager;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            playerManager.healthLose(1f);
        }
    }
}