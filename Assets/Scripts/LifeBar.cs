using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    // Use este tutorial https://www.youtube.com/watch?v=uytdBD7xDrc&ab_channel=LuisCanary
    public Image usefulLifeBar;
    public GameObject player;
    private float healthPoints;
    private float maxHealthPoints;

    private void Start()
    {
        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        maxHealthPoints = playerManager.HealthPoints;
    }
    void Update()
    {
        if (player != null)
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                healthPoints = playerManager.HealthPoints;
            }
        }
        usefulLifeBar.fillAmount = healthPoints / maxHealthPoints;
    }
}
