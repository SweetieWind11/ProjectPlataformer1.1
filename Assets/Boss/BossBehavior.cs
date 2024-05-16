using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject Bullet;
    public float TimerAttack;
    public float spawnDistance, speed;
    private float delaytimeAttack = 0f;
    public float attack2Timer = 5f;
    public Animator bossAnimation;
    public GameObject brick;

    private float bossLife = 100f;

    private Transform player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimerAttack = TimerAttack - Time.deltaTime;
        if (TimerAttack <= 0)
        {
            }
        attack2Timer -= Time.deltaTime;
        if (attack2Timer <= 0)
        {
            bossAnimation.SetTrigger("attack2");
            attack2Timer = 5f;
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
        TimerAttack = 1.5f;

    }
    private void Attack2()
    {
        float x = Random.Range(9f, -9f);
        Instantiate(brick, new Vector2(x, 6), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
