using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;
    int points = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
    private void OnGUI()
    {
        //temporal similar a lo que hicimos en clase
        string pointString = string.Format("{000}",points);
        GUI.contentColor = Color.white;
        GUI.skin.label.fontSize = 80;
        GUI.Label(new Rect(10, 10, 250, 100), pointString);
    }
}
