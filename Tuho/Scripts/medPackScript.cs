using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medPackScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript ps = collision.gameObject.GetComponent<playerScript>();
            ps.gainHealth();
            Destroy(this.gameObject);
        }
    }
}
