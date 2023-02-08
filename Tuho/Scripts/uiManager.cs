using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour

{
    public Text ammoTxt;
    public Text healthTxt;
    public Text killTxt;
    public Text itemTxt;
    public GameObject winScreen;
    public GameObject loseScreen;

    public void Awake()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void updateAmmo(int ammo)
    {
        ammoTxt.text = "Ammo: " + ammo.ToString();
    }

    public void updateHealth(int health)
    {
        healthTxt.text = "Health: " + health.ToString();
    }

    public void openStageClearWindow(int kills, int items)
    {
        winScreen.SetActive(true);
        killTxt.text = "Killed enemies: " + kills;
        itemTxt.text = "Gathered items: " + items;
    }

    public void openGameOverWindow()
    {
        loseScreen.SetActive(true);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("gameScene");
    }

}
