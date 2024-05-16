using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemFly : MonoBehaviour
{


    public GameObject bulletPrefab;
    public float interval = 2f;

    private float timer = 0f;

    private float timerUpDown = 0f;
    private float moveSpeed = 2f; 
    private float direction = 1f; 
    private float switchTime = 0.75f; // Tiempo para alternar la dirección
    private PlayerManager playerManager;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // Instanciar el prefab bullet en la posición actual del enemigo
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timer = 0f; // Reiniciar el temporizador
        }
        timerUpDown += Time.deltaTime;
        if (timerUpDown >= switchTime)
        {
            direction *= -1;
            timerUpDown = 0f;
        }
        transform.Translate(Vector2.up * moveSpeed * direction * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerManager = player.GetComponent<PlayerManager>();
            Destroy(this.gameObject);
            playerManager.healthLose(0.1f);
            PointsManager.instance.AddPoints(5);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            PointsManager.instance.AddPoints(5);
        }
        if (other.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(6);
        }
        if (other.gameObject.tag == "VergilUltimate")
        {
            Destroy(this.gameObject);
            PointsManager.instance.AddPoints(10);
        }
    }


}
