using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class doorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
