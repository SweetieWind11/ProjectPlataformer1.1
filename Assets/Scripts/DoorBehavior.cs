using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool LeverUp = false;
    private bool isPlayerOnDoor = false;
    public Transform teleportTarget;
    private GameObject player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && LeverUp && isPlayerOnDoor)
        {
            player.transform.position = teleportTarget.position; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnDoor = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerOnDoor = false;
            player = null;
        }
    }
}

