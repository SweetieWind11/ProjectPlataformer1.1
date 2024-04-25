using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemSpider : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private PlayerManager playerManager;

    private float moveSpeed = 2f; // Velocidad de movimiento
    private float direction = 1f; // Dirección inicial (1 = derecha, -1 = izquierda)
    private float timer = 0f; // Temporizador para alternar la dirección
    private float switchTime = 0.75f; // Tiempo para alternar la dirección

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
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
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(5);
            playerManager.healthLose(0.5f);
        }
    }
}
