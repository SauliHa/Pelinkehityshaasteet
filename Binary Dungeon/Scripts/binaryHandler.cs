using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class binaryHandler : MonoBehaviour
{
    public GameObject vars;
    public GameObject exitDoor;
    AudioSource aud;
    savedVariables sv;
    int bin0, bin1, bin2, bin3, bin4, bin5, bin6, bin7;
    int answer;
    int playerAnswer;
    string currentBin;
    bool cleared;
    float clearTime;
    // Start is called before the first frame update
    void Start()
    {
        bin0 = 0;
        bin1 = 0;
        bin2 = 0;
        bin3 = 0;
        bin4 = 0;
        bin5 = 0;
        bin6 = 0;
        bin7 = 0;
        currentBin = bin0 + "" + bin1 + "" + bin2 + "" + bin3 + "" + bin4 + "" + bin5 + "" + bin6 + "" + bin7;
        sv = vars.GetComponent<savedVariables>();
        answer = Random.Range(sv.getMinRandom(), sv.getMaxRandom());
        cleared = false;
        playerAnswer = 0;
        clearTime = 0f;
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!cleared)
        {
            clearTime += Time.deltaTime;
        }
    }

    public void changeBin(int binIndex, int bin)
    {
        switch (binIndex)
        {
            case 0:
                bin0 = bin;
                break;
            case 1:
                bin1 = bin;
                break;
            case 2:
                bin2 = bin;
                break;
            case 3:
                bin3 = bin;
                break;
            case 4:
                bin4 = bin;
                break;
            case 5:
                bin5 = bin;
                break;
            case 6:
                bin6 = bin;
                break;
            case 7:
                bin7 = bin;
                break;
            default:
                Debug.Log("Binary index was out of bounds. It needs to be between 0-7");
                break;
        }
        checkAnswer();
    }

    void checkAnswer()
    {
        currentBin = bin0 + "" + bin1 + "" + bin2 + "" + bin3 + "" + bin4 + "" + bin5 + "" + bin6 + "" + bin7;
        Debug.Log("Current bin as binary:" + currentBin);

        playerAnswer = Convert.ToInt32(currentBin, 2);

        if (answer == playerAnswer)
        {
            aud.Play();
            Destroy(exitDoor.gameObject);
            cleared = true;
            Debug.Log("answer was right!");
        }
        else
        {
            Debug.Log("answer was wrong");
        }
    }

    public int getAnswer()
    {
        return answer;
    }

    public int getPlayerAnswer()
    {
        return playerAnswer;
    }

    public bool levelIsCleared()
    {
        return cleared;
    }

    public float getClearTime()
    {
        return clearTime;
    }

}
