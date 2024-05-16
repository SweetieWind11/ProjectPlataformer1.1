using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeBar : MonoBehaviour
{
    public Image BossBar;
    public GameObject boss;
    private float bossLife;
    private float fullLifeBoss;

    private void Start()
    {
        fullLifeBoss = 100;
    }

    void Update()
    {
        if (boss != null)
        {
            BossBehavior bossBehavior = boss.GetComponent<BossBehavior>();
            if (bossBehavior != null)
            {
                bossLife = bossBehavior.bossLife;
            }
        }
        BossBar.fillAmount = bossLife / fullLifeBoss;
    }
}