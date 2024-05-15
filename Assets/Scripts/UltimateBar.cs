using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UltimateBar : MonoBehaviour
{
    public Image ultimateBar;
    public GameObject player;
    private float UltimateCount;
    private float FullUltimate;

    private void Start()
    {
        VergilMovement vergilMovement = player.GetComponent<VergilMovement>();
        FullUltimate = 50;
    }
    void Update()
    {
        if (player != null)
        {
            VergilMovement vergilMovement = player.GetComponent<VergilMovement>();
            if (vergilMovement != null)
            {
                float ultCharge = vergilMovement.UltCharge;
                UltimateCount = ultCharge;
            }
        }
        ultimateBar.fillAmount = UltimateCount / FullUltimate;
    }
}
