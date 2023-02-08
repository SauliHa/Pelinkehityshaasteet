using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipScript : MonoBehaviour
{
    public GameObject handler;
    public GameObject flame;
    public GameObject ui;
    AudioSource aud;
    public int orderNumber;
    int binary;
    bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        flame.SetActive(false);
        binary = 0;
        inRange = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && inRange)
        {

            if (binary == 0) 
            {
                aud.Play();
                binary = 1;
                flame.SetActive(true); 
            }
            
            else if (binary == 1)
            {
                binary = 0;
                flame.SetActive(false);
            }
            
            handler.GetComponent<binaryHandler>().changeBin(orderNumber, binary);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
        ui.GetComponent<uiManager>().showDialogBox(1);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        ui.GetComponent<uiManager>().hideDialogBox();
    }



}
