using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public bool isAlive = true;
    [SerializeField]
    private int healthPoints = 10;
    private float healthTimer = 0.5f;
    [SerializeField]
    private int layerInt;
    SpriteRenderer sprite;
    [SerializeField]
    private Transform respawnPosition;
    public float healthTimerC = 0.5f;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isAlive == false)
        {
            RestartPlayer();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerInt)
        {
            if (healthTimer > 0)
            {
                healthTimer -= Time.deltaTime;
            }
            else if (healthTimer <= 0 && isAlive)
            {
                healthPoints -= 1;
                if (healthPoints <= 0)
                {
                    isAlive = false;
                    Debug.Log("Perdiste");
                    playerLose();
                }
                healthTimer = 0.5f;
            }
        }
        if (collision.gameObject.tag == "Heal")
        {
            if (healthTimerC > 0)
            {
                healthTimerC -= Time.deltaTime;
            }
            else if (healthTimerC < 9 && isAlive)
            {
                healthPoints += 1;
                healthTimerC = 0.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            Debug.Log("Ganaste");
        }
    }
    private void playerLose()
    {
        sprite.color = Color.red;
    }
    public void RestartPlayer()
    {
        gameObject.transform.position = respawnPosition.position;
        sprite.color = Color.white;
        healthPoints = 10;
        isAlive = true;
    }
}
