using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleLeverBehavior : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    public Animator leverAnimation;
    public DoorBehavior doorBehavior;

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            leverAnimation.SetBool("Start", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInTrigger = false;
        }
    }
    public void onLeverEnd()
    {
        leverAnimation.SetBool("Start", false);
        doorBehavior.LeverUp = true;
    }

}
