using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject Bullet;
    private float TimerAttack =5f;
    private float spawnDistance = 5f, speed = 10f;
    private float delaytimeAttack = 0f;
    private float attack2Timer = 7f;
    public Animator bossAnimation;
    public GameObject brick;
    private float attack3Timer = 10f;

    public GameObject squarePrefab;
    private float squareSpeed = 5f;

    private Transform player;
    private PlayerManager playerManager;

    public float bossLife = 100f;


    // Update is called once per frame
    void Update()
    {
        if (bossLife <= 0)
        {
            GameManager.Instance.IsGameWin = true;
            Destroy(this.gameObject);
        }
        TimerAttack = TimerAttack - Time.deltaTime;
        if (TimerAttack <= 0)
        {
            bossAnimation.SetBool("Attack1", true);
        }
        if (bossLife <= 60)
        {
            attack2Timer -= Time.deltaTime;
            if (attack2Timer <= 0)
            {
                bossAnimation.SetBool("Attack2", true);
            }
        }
        if (bossLife <= 30)
        {
            attack3Timer -= Time.deltaTime;
            if (attack3Timer <= 0)
            {
                bossAnimation.SetBool("Attack3", true);
            }
        }
    }
    Vector2 Arc(float Q)
    {
        float x = spawnDistance * Mathf.Sin(Q * Mathf.Deg2Rad) + player.position.x;
        float y = spawnDistance * Mathf.Cos(Q * Mathf.Deg2Rad) + player.position.y;
        return new Vector2(x, y);
    }
    private void Attack1()
    {
        for (int i = 0; i < 4; i++)
        {
            player = GameObject.FindWithTag("Player").transform;
            float angle = 15f * i - 45f / 2f;
            Vector2 position = Arc(angle);
            GameObject orb = Instantiate(Bullet, position, Quaternion.identity);
            Vector2 orbDirection = (player.position - orb.transform.position).normalized;
            orb.GetComponent<OrbBehavior>().delayTime = delaytimeAttack;
            orb.GetComponent<OrbBehavior>().orbDirectionV = speed * orbDirection;
            delaytimeAttack = delaytimeAttack + .05f;
        }
        delaytimeAttack = 0f;
    }
    private void attack1End()
    {
        bossAnimation.SetBool("Attack1", false);
        TimerAttack = 5f;
    }
    private void Attack2()
    {
        GameObject projectile = Instantiate(squarePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * squareSpeed;
    }
    private void attack2End()
    {
        bossAnimation.SetBool("Attack2", false);
        attack2Timer = 7f;
    }
    private void Attack3()
    {
        float x = Random.Range(-3f, 20f);
        Instantiate(brick, new Vector2(x, 9), Quaternion.identity);
    }
    private void attack3End()
    {
        bossAnimation.SetBool("Attack3", false);
        attack3Timer = 10f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            bossLife -= 5;
        }
        if (collision.gameObject.tag == "VergilUltimate")
        {
            bossLife -= 50;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            bossLife -= .5f;
        }
    }
}
