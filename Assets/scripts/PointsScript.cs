using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    public Text pointsUI;
    public Text recordUI;

    public int points = 0;


    void Update()
    {
        UpdateRecord();

        pointsUI.text = points + " PONTOS";
        recordUI.text = PlayerPrefs.GetInt("Record") + " RECORDE ";
    }


    private void UpdateRecord()
    {
        if(points > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", points);
        }
    }
}
