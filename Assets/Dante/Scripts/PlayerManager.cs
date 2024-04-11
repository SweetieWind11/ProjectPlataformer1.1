using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public bool isAlive = true;
    [SerializeField]
    private float healthPoints = 10.0f;
    private float healthTimer = 0.5f;
    [SerializeField]
    private int layerInt;
    SpriteRenderer sprite;
    [SerializeField]
    private Transform respawnPosition;
    public float healthTimerC = 0.5f;
    private DanteMove1 danteMove1;
    public float respawnTime = 3f;
    public int Lives = 3;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        danteMove1 = GetComponent<DanteMove1>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        if(Lives <= 0)
        {
            Debug.Log("Perdiste todas tus vidas, presiona R para reiniciar");
        }
        if (!isAlive && Lives >= 1)
        {
            respawnTime = respawnTime - Time.deltaTime;
            if (respawnTime <= 0)
            {
                respawnTime = 3f;
                isAlive = true;
                RestartPlayer();
            }
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
                    danteMove1.DissableControl();
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
            else if (healthTimerC < 9 && isAlive) //Cambiar healthTimerC por HealthPoints
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
        Lives = Lives - 1;
        Debug.Log("-1 vida");
    }
    public void RestartPlayer()
    {
        gameObject.transform.position = respawnPosition.position;
        sprite.color = Color.white;
        healthPoints = 10;
        isAlive = true;
        danteMove1.EnableControl();
    }
    public void healthLose(float healthToLose)
    {
        healthPoints -= healthToLose;
    }
}
