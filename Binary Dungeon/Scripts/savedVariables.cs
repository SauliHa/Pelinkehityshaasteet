using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savedVariables : MonoBehaviour
{
    private static savedVariables sv;
    static int clearedLevels;
    static int minRandom;
    static int maxRandom;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(sv == null)
        {
            sv = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if(minRandom < 1)
        {
            minRandom = 1;
        }
        if(maxRandom < 1)
        {
            maxRandom = 20;
        }

    }

    public int getMinRandom()
    {
        return minRandom;
    }
    public void increaseMinRandom()
    {
        if(minRandom < 100)
        {
            minRandom += Random.Range(5,11);
        }
    }
    public int getMaxRandom()
    {
        return maxRandom;
    }
    public void increaseMaxRandom()
    {
        if (maxRandom < 255)
        {
            maxRandom += Random.Range(5, 15);
        }

        if(maxRandom > 255)
        {
            maxRandom = 255;
        }
    }

    public int getClearedLevels()
    {
        return clearedLevels;
    }
    public void clearLevel()
    {
        clearedLevels++;
    }

    public void Reset()
    {
        clearedLevels = 0;
        minRandom = 1;
        maxRandom = 10;
    }



}
