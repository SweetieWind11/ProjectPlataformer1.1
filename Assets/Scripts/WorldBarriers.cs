using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBarriers : MonoBehaviour
{
    private PlayerManager playerManager;
    void Start()
    {
        
    }
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerManager.fallInVoid();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }

    }

}
