using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemSpider : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private PointsManager pointsManager;
    private PlayerManager playerManager;


    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
        GameObject pointsManagerObject = GameObject.Find("PointsManager");
        pointsManager = pointsManagerObject.GetComponent<PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Collision");
            pointsManager.AddPoints(5);
            playerManager.healthLose(0.5f);
        }
    }
}
