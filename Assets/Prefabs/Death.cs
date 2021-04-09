using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Death : MonoBehaviour
{
    Renderer rend;
    Color c;
    int delay = 0;
    GameObject a;
    public GameObject Bullet;
    public float xSpeed, ySpeed;
    public Rigidbody2D rb;
    public int shotspeed = 50;
    Vector2 movement;
    public int health = 3;
    int timer = 0;
    int tnow;
    public GameObject[] skulls;

    public GameOverScreen GameOver;

    public static int maxHealth = 3;
    public int currentHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //input
        timer++;
        rb.velocity = new Vector2((Input.GetAxis("Horizontal") * xSpeed), Input.GetAxis("Vertical") * ySpeed);

        if (Input.GetKey(KeyCode.Space) && delay > shotspeed)
        {
            Shoot();
        }

       
        delay++;
    }

    public void damage()
    {
        health--;
        currentHealth--;
        healthUpdate(health);
        if (health == 0)
        {
            GameOver.Setup();
            Destroy(gameObject);
        }
    }

    IEnumerator invuln()
    {
        Physics2D.IgnoreLayerCollision(10, 9, true);
        Physics2D.IgnoreLayerCollision(10, 11, true);
        c.a = .5f;
        rend.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(10, 9, false);
        Physics2D.IgnoreLayerCollision(10, 11, false);
        c.a = 1f;
        rend.material.color = c;
    }

    public void healthUpdate(int health)
    {
        if (health == 2)
            Destroy(skulls[2]);
        else if (health == 1)
            Destroy(skulls[1]);
        else if (health == 0)
            Destroy(skulls[0]);
    }

    void Shoot()
    {
        delay = 0;
        Instantiate(Bullet, a.transform.position, Quaternion.identity);
    }

}
