using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
    public GameObject gui;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerScript ps = collision.GetComponent<playerScript>();
            ps.paused = true;
            Time.timeScale = 0;
            uiManager uim = gui.GetComponent<uiManager>();
            uim.openStageClearWindow(ps.killedEnemies, ps.collectedItems);
        }
    }
}
