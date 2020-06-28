using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuButtons : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject tutorialPanel;


    public void OnClickStart()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void OnClickCredits()
    {
        creditsPanel.gameObject.SetActive(true);
    }

    public void OnClickExitCredits()
    {
        creditsPanel.gameObject.SetActive(false);
    }


    public void OnClickTutorial()
    {
        tutorialPanel.gameObject.SetActive(true);
    }

    public void OnClickExitTutorial()
    {
        tutorialPanel.gameObject.SetActive(false);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

}
