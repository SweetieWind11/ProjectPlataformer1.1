using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartMenu : MonoBehaviour
{
    public float waitforStart = 0.1f;
    public int isSongStart = 1;
    private void Start()
    {
        AudioManager.instance.PlayMenuSong();
        AudioManager.instance.StopFontSong();
    }
    private void Update()
    {
        waitforStart -= Time.deltaTime;
        if(waitforStart <= 0 && isSongStart >= 1)
        {
            isSongStart = 0;
            AudioManager.instance.PlayMenuSong();
        }
    }
    public void startButton()
    {
        GameManager.Instance.ChangeScene("Nivel1");
        AudioManager.instance.StopMenuSong();
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
