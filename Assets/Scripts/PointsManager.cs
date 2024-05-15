using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;
    public TMP_Text text;
    int points = 0;

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PointsUI();
    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
    //private void OnGUI()
    //{
    //    //temporal similar a lo que hicimos en clase
    //    string pointString = string.Format("{000}", points);
    //    GUI.contentColor = Color.white;
    //    GUI.skin.label.fontSize = 80;
    //    GUI.Label(new Rect(10, 10, 250, 100), pointString);
    //}
    private void PointsUI()
    {
        text.text = "POINTS: " + points.ToString();
    }
}
