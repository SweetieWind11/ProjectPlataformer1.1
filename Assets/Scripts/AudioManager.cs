using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 

    public AudioSource audioSource;
    public AudioSource effects;

    public AudioClip menuSong;
    public AudioClip fontSong;
    public AudioClip katana;
    public AudioClip disparo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayMenuSong();
        }
    }
    public void PlayMenuSong()
    {
        audioSource.clip = menuSong;
        audioSource.Play();
    }

    public void StopMenuSong()
    {
        audioSource.Stop();
    }

    public void PlayFontSong()
    {
        audioSource.clip = fontSong;
        audioSource.Play();
    }

    public void StopFontSong()
    {
        audioSource.Stop();
    }

    public void PlayKatana()
    {
        audioSource.clip = katana;
        effects.Play();
    }

    public void PlayDisparo()
    {
        audioSource.clip = disparo;
        effects.Play();
    }

}
