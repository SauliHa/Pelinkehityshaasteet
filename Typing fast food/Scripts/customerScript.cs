using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerScript : MonoBehaviour
{
    float speed = 2f;
    bool canMove;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        anim = GetComponent<Animator>();
    }

    public void stopMoving()
    {
        canMove = false;
        anim.SetBool("isMoving", false);
    }

    public void startMoving()
    {
        canMove = true;
        anim.SetBool("isMoving", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
