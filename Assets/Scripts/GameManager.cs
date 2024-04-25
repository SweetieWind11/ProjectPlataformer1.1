using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    public static GameManager Instance;
    public GameObject losePanel;
    public GameObject winnPanel;


    public GameObject plosePanel;
    private bool isGameWin = false;
    private bool isGameLose = false;

    public bool IsGameWin
    {
        get => isGameWin;
        set => isGameWin = value;
    }

    public bool IsGameLose
    {
        get => isGameLose;
        set => isGameLose = value;
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
        isGameLose = false;
        isGameWin = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}