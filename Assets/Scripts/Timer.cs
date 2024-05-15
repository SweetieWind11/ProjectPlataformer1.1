using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timerTotal = 200f;
    private bool timerUp = false;
    [SerializeField]
    private TextMeshProUGUI textTimer;
    public bool timerStart;
    public bool TimerUpGetSet
    {
        get => timerUp;
        set => timerUp = value;
    }


    void Update()
    {
        if (timerStart)
        {
            if (timerTotal > 0 && !timerUp)
            {
                timerTotal -= Time.deltaTime;
            }
            else
                timerUp = true;
        }
        textTimer.text = TimerFormat();
    }
    private string TimerFormat()
    {
        int minutes = Mathf.FloorToInt(timerTotal / 60f);
        int seconds = Mathf.FloorToInt(timerTotal - minutes * 60);

        string timerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        return timerString;

    }
    public float ReturnTimer()
    {
        return timerTotal;
    }
    public void timerStartFunction()
    {
        timerStart = true;
    }
}