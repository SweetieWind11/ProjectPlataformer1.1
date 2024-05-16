using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject characterSelectorUI;
    [SerializeField]
    private GameObject vergil;
    [SerializeField]
    private GameObject vergilUI;
    [SerializeField]
    private GameObject vergilUltimateBarUI;
    public Animator vergilUIAnimations;
    [SerializeField]

    private GameObject dante;
    [SerializeField]
    private GameObject danteUI;
    public Animator danteUIAnimations;
    private bool Animationstart = false;
    private float durationAnimation;
    public Timer timer;
    public bool isDante = false;
    public bool isVergil = false;

    public GameObject startBarriers;


    void Start()
    {
        AudioManager.instance.PlayFontSong();
        AudioManager.instance.StopMenuSong();

        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Animationstart)
        {
            durationAnimation -= Time.deltaTime;
            if (durationAnimation <= 0)
            {
                onAnimationEnd();
                Animationstart = false;
            }
        }
    }
    public void SelectVergilButton()
    {
        dante.SetActive(false);
        danteUI.SetActive(false);
        vergilUIAnimations.SetBool("Selected", true);
        durationAnimation = 2f;
        Animationstart = true;
        isVergil = true;
        startBarriers.SetActive(false);
        AudioManager.instance.PlayFontSong();

    }
    public void SelectDanteButton()
    {
        vergil.SetActive(false);
        vergilUI.SetActive(false);
        vergilUltimateBarUI.SetActive(false);
        danteUIAnimations.SetBool("Selected", true);
        durationAnimation = 2f;
        Animationstart = true;
        isDante = true;
        startBarriers.SetActive(false);
        AudioManager.instance.PlayFontSong();

    }
    public void onAnimationEnd()
    {
        characterSelectorUI.SetActive(false);
        timer.timerStartFunction();
    }
}
