using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float playerlife = 100;
    [SerializeField]
    private float lifeTimer = 0.5f;
    [SerializeField]
    private int layerTrap = 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == layerTrap)
        {
            if(lifeTimer > 0)
            {
                lifeTimer -= Time.deltaTime;
            }
            if (lifeTimer <= 0)
            {
                playerlife--;
                lifeTimer = 0.5f;
            }
        }
    }
}
