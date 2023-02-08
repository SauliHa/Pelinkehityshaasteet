using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScript : MonoBehaviour
{
    public GameObject vars;
    public GameObject uim;
    savedVariables sv;


    private void Start()
    {
        sv = vars.GetComponent<savedVariables>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sv.increaseMinRandom();
        sv.increaseMaxRandom();
        sv.clearLevel();
        uim.GetComponent<uiManager>().showLevelClearWindow();
        
    }
}
