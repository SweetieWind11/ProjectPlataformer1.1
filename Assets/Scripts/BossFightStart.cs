using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStart : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossbar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            boss.SetActive(true);
            bossbar.SetActive(true);
        }
    }
}
