using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    private DanteMove1 danteMove1;
    private VergilMovement vergilMove;
    public float respawnTime = 3f;
    public int Lives = 3;
    public TMP_Text vidas;
    public CharacterSelector characterselector;
    public float HealthPoints
    {
        get => healthPoints;
        set => healthPoints = value;
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        danteMove1 = GetComponent<DanteMove1>();
        vergilMove = GetComponent<VergilMovement>();
    }


    void Update()
    {
        vidas.text = Lives.ToString();
        if (Input.GetKeyDown(KeyCode.R) && Lives <= 0)
        {
            GameManager.Instance.ChangeScene("Nivel1");
        }
        if(Lives <= 0)
        {
            GameManager.Instance.IsGameLose = true;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {

            if (HealthPoints < 9 && isAlive)
            {
                healthPoints += 2;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ExtraLife")
        {
            Lives++;
            Destroy(collision.gameObject);
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
                    playerLose();
                    if (characterselector.isDante)
                    {
                        danteMove1.DissableControl();
                    }
                    else if (characterselector.isVergil)
                    {
                        vergilMove.DissableControl();
                    }
                }
                healthTimer = 0.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            GameManager.Instance.IsGameWin = true;

        }

    }
    private void playerLose()
    {
        sprite.color = Color.red;
        Lives = Lives - 1;
    }
    public void RestartPlayer()
    {
        gameObject.transform.position = respawnPosition.position;
        sprite.color = Color.white;
        healthPoints = 10;
        isAlive = true;
        if (characterselector.isDante)
        {
            danteMove1.EnableControl();
        }
        else if (characterselector.isVergil)
        {
            vergilMove.EnableControl();
        }
    }
    public void healthLose(float healthToLose)
    {
        healthPoints -= healthToLose;
    }
    public void fallInVoid()
    {
        isAlive = false;
        Lives--;
        if (characterselector.isDante)
        {
            danteMove1.DissableControl();
        }
        else if (characterselector.isVergil)
        {
            vergilMove.DissableControl();
        }

    }
}
