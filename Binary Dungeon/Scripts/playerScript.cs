using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    float movementSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        anim.SetBool("moving", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate((Vector2.up * movementSpeed) * Time.deltaTime);
            anim.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate((Vector2.down * movementSpeed) * Time.deltaTime);
            anim.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((Vector2.left * movementSpeed) * Time.deltaTime);
            sr.flipX = true;
            anim.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((Vector2.right * movementSpeed) * Time.deltaTime);
            sr.flipX = false;
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
}
