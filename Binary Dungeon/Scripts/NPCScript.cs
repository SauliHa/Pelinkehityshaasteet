using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public GameObject uim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        uim.GetComponent<uiManager>().showDialogBox(0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        uim.GetComponent<uiManager>().hideDialogBox();
    }
}
