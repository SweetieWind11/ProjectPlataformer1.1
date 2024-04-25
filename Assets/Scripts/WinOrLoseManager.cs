using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLoseManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject losePanel;
    void Update()
    {
        if (GameManager.Instance.IsGameWin == true)
        {
            victoryPanel.SetActive(true);
        } 
        if(GameManager.Instance.IsGameWin == false)
        {
            victoryPanel.SetActive(false);
        }
        if (GameManager.Instance.IsGameLose == true)
        {
            losePanel.SetActive(true);
        }
        if (GameManager.Instance.IsGameLose == false)
        {
            losePanel.SetActive(false);
        }
    }
}
