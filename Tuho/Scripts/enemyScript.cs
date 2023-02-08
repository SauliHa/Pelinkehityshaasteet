using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyScript : MonoBehaviour
{
    AIPath aiPath;
    public GameObject player;
    playerScript ps;
    public float chaseDistance;
    public float loseInterestDistance;
    public float hitPoints;
    public float moveSpeed;
    Animator anim;
    AudioSource aud;
    BoxCollider2D col;
    bool dead;
   

    // Start is called before the first frame update
    void Start()
    {
        ps = player.GetComponent<playerScript>();
        aiPath = GetComponent<AIPath>();
        anim = GetComponentInChildren<Animator>();
        aud = GetComponent<AudioSource>();
        col = GetComponent<BoxCollider2D>();
        col.enabled = true;
        dead = false;
        aiPath.maxSpeed = moveSpeed;
        aiPath.canSearch = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        
        if(distance < chaseDistance && !dead)
        {
            anim.SetBool("isMoving", true);
            aiPath.maxSpeed = moveSpeed;
            aiPath.canSearch = true;
        }
        else if(distance > loseInterestDistance && !dead)
        {
            anim.SetBool("isMoving", false);
            aiPath.maxSpeed = 0;
            aiPath.canSearch = false;
        }
    }

    public void takeDamage()
    {
        aud.Play();
        hitPoints--;
        if(hitPoints <= 0)
        {
            ps.killedEnemies++;
            aiPath.maxSpeed = 0;
            aiPath.canSearch = false;
            col.enabled = false;
            anim.SetBool("isDead", true);
            dead = true;
        }
    }
}
