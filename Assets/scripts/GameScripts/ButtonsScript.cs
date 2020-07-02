using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
    }


    public void OnClickBackMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
