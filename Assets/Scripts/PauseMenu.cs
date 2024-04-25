using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject pausePanel;
    private bool isPaused;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && GameManager.Instance.IsGameWin == false && GameManager.Instance.IsGameLose == false)
        {
            pauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            resumeGame();  
        }

    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        isPaused = true;
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        isPaused = false;
    }
    public void restart()
    {
        Time.timeScale = 1;
        GameManager.Instance.ChangeScene("Nivel1");
        GameManager.Instance.IsGameLose = false;
    }
    public void mainMenu()
    {
        Time.timeScale = 1;
        GameManager.Instance.ChangeScene("Menu");
    }
    
}


