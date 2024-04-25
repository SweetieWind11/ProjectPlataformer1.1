using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartMenu : MonoBehaviour
{
    public void startButton()
    {
        GameManager.Instance.ChangeScene("Nivel1");
    }
    public void creditsButton()
    {

        GameManager.Instance.ChangeScene("Credits");
    }
    public void exitButton()
    {
        Application.Quit();
    }
}
