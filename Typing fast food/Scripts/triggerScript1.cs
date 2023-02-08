using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript1 : MonoBehaviour
{
    public GameObject gui;
    uiManager uim;

    private void Start()
    {
        uim = gui.GetComponent<uiManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        customerScript cs = collision.GetComponent<customerScript>();
        cs.stopMoving();
        uim.nextOrder(collision.gameObject);
    }
}
