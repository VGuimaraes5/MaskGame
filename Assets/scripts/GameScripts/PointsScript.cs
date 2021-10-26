using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    //controlador dos textos da UI


    public TMP_Text pointsUI;
    public TMP_Text recordUI;

    public int points = 0;


    void Update()
    {
        UpdateRecord();

        //muda o texto na tela conforme a pontuação atual
        pointsUI.text = points + " POINTS";
        recordUI.text = " RECORD " + PlayerPrefs.GetInt("Record");
    }

    //atualiza a pontuação recorde
    private void UpdateRecord()
    {
        //
        if(points > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", points);
        }
    }
}
