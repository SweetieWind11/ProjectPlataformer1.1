using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemFly : MonoBehaviour
{

    private PointsManager pointsManager;

    public GameObject bulletPrefab;
    public float interval = 2f;

    private float timer = 0f;

    void Start()
    {
        GameObject pointsManagerObject = GameObject.Find("PointsManager");
        pointsManager = pointsManagerObject.GetComponent<PointsManager>();
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Collision");
            pointsManager.AddPoints(1);
        }
    }

}
