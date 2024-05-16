using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour
{
    public float delayTime;
    private float time;
    private bool fired;
    public Vector2 orbDirectionV;
    private PlayerManager playerManager;

    private void FixedUpdate()
    {
        if (time >= delayTime && !fired)
        {
            fired = true;
            GetComponent<Rigidbody2D>().velocity = orbDirectionV;
        }
        time += Time.fixedDeltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Orb"))
        {

        }
        else if (collision.gameObject.layer == 6)
        {
            CameraTarget.Instance.shakeCamera(1, .5f);
            Destroy(this.gameObject);

        }
        else if (collision.CompareTag("Player"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerManager = player.GetComponent<PlayerManager>();
            Destroy(this.gameObject);
            playerManager.healthLose(1f);
        }
    }


}
