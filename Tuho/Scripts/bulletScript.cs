using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.tag == "Enemy")
        {
            enemyScript es = collision.collider.GetComponent<enemyScript>();
            es.takeDamage();
        }
        Destroy(this.gameObject);
     
    }
}
