using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public GameObject binhandler;
    public GameObject dialogBox;
    public Text dialogText;
    public GameObject savedVars;
    public savedVariables sv;
    public GameObject leverClearedBox;
    public Text solvedPuzzlesText;
    public Text clearTimeText;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        leverClearedBox.SetActive(false);
        sv = savedVars.GetComponent<savedVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDialogBox(int caller)
    {
        int answer = binhandler.GetComponent<binaryHandler>().getAnswer();
        int playerAnswer = binhandler.GetComponent<binaryHandler>().getPlayerAnswer();
        bool cleared = binhandler.GetComponent<binaryHandler>().levelIsCleared();
        dialogBox.SetActive(true);
        switch (caller)
        {
            case 0:
                if (!cleared)
                    dialogText.text = "In order to open this door you must light the torches in a way that they spell the number " + answer + " in binary, going left to right. Your current answer is " + playerAnswer;
                else
                    dialogText.text = "Congratulations for solving the puzzle. You can now move throught the door to the next level.";
                break;
            case 1:
                dialogText.text = "Press Z to light or extinguish the torch";
                break;

        }
    }

    public void hideDialogBox()
    {
        dialogBox.SetActive(false);
    }

    public void showLevelClearWindow()
    {
        int clearedLevels = sv.getClearedLevels();
        float solveTime = binhandler.GetComponent<binaryHandler>().getClearTime();
        leverClearedBox.SetActive(true);
        solvedPuzzlesText.text = "Solved puzzles: " + clearedLevels;
        clearTimeText.text = "Clear time: " + solveTime.ToString("F2")+ "s";
    }

    public void nextPuzzle()
    {
        SceneManager.LoadScene("gameScene");
    }
}
