using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuscript : MonoBehaviour
{
    public GameObject htp;

    private void Start()
    {
        htp.SetActive(false);
    }
    public void clickStartButton()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void clickHelpButton()
    {
        htp.SetActive(true);
    }

    public void closeButton()
    {
        htp.SetActive(false);
    }

    public void clickQuitButton()
    {
        Application.Quit();
    }
}
