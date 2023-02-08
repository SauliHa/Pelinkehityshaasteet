using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gui;
    public bool paused;
    public int killedEnemies;
    public int collectedItems;
    uiManager uim;
    Animator anim;
    AudioSource aud;

    float movementSpeed = 8f;
    float shootingSpeed = 2000f;
    float turningSpeed = 150f;

    float invincibility = 0f;
    public int ammo;
    public int health;
    public int ammoPackAmount;
    public int healthPackAmount;
    
    // Start is called before the first frame update
    void Awake()
    {
        uim = gui.GetComponent<uiManager>();
        anim = gameObject.GetComponent<Animator>();
        aud = gameObject.GetComponent<AudioSource>();
        
        killedEnemies = 0;
        collectedItems = 0;
    }

    private void Start()
    {
        paused = false;
        Time.timeScale = 1f;
        uim.updateAmmo(ammo);
        uim.updateHealth(health);
    }

    void takeDamage()
    {
        invincibility = 1f;
        health--;
        uim.updateHealth(health);
        if (health <= 0)
        {
            Time.timeScale = 0;
            paused = true;
            uim.openGameOverWindow();
        }
    }

    public void gainHealth()
    {
        collectedItems++;
        health += healthPackAmount;
        uim.updateHealth(health);
    }

    void shoot()
    {
        if(ammo >= 1)
        {
            aud.Play();
            ammo--;
            uim.updateAmmo(ammo);

            Rigidbody2D bulletClone;
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;

            Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            bulletClone = newBullet.GetComponent<Rigidbody2D>();
            bulletClone.velocity = bulletClone.GetRelativeVector(Vector2.down * (shootingSpeed * Time.deltaTime));
        }
        else
        {
            Debug.Log("Out of ammo");
        }
        
    }

    public void gainAmmo()
    {
        collectedItems++;
        ammo += ammoPackAmount;
        uim.updateAmmo(ammo);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isWalking", true);
            transform.Translate((Vector2.down * movementSpeed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isWalking", true);
            transform.Translate((Vector2.up * movementSpeed) * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, (turningSpeed * Time.deltaTime), Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, (-turningSpeed * Time.deltaTime), Space.Self);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !paused)
        {
            shoot();
        }

        if(invincibility > 0f)
        {
            invincibility -= Time.deltaTime;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if(invincibility <= 0f)
            {
                takeDamage();
            }
            
        }
    }
}
