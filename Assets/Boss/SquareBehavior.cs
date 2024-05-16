using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    PlayerManager playerManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(1);
        }
        if (collision.gameObject.tag == "VergilUltimate")
        {
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(5);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerManager = player.GetComponent<PlayerManager>();
            Destroy(this.gameObject);
            playerManager.healthLose(1f);

        }
    }

}
