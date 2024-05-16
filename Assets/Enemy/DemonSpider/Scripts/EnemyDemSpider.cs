using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemSpider : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private PlayerManager playerManager;

    private float moveSpeed = 2f; // Velocidad de movimiento
    private float direction = 1f; // Direcci�n inicial (1 = derecha, -1 = izquierda)
    private float timer = 0f; // Temporizador para alternar la direcci�n
    private float switchTime = 0.75f; // Tiempo para alternar la direcci�n

    void Start()
    {

    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= switchTime)
        {
            direction *= -1; 
            timer = 0f; 
        }
        transform.Translate(Vector2.right * moveSpeed * direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerManager = player.GetComponent<PlayerManager>();
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(5);
            playerManager.healthLose(0.5f);
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            PointsManager.instance.AddPoints(5);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(6);
        }
        if (collision.gameObject.tag == "VergilUltimate")
        {
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(10);
        }
    }
}
