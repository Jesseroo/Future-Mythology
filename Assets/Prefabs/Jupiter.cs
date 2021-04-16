using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jupiter : Enemy
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    GameObject a;
    bool burst = false;
    int delay = 0;
    public GameObject SecondaryShot;
    bool phase2 = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        maxHealth = 25;
        currentHealth = maxHealth;
        healthbar.gameObject.SetActive(false);
        if (hasBar)
            healthbar.SetMaxHealth(maxHealth);
    }

    public Jupiter()
    {


    }

    void Shoot()
    {
        if(!phase2)
            Instantiate(badBullet, a.transform.position, Quaternion.identity);
        else
            Instantiate(SecondaryShot, a.transform.position, Quaternion.identity);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed * -1, ySpeed);
        if (delay % 120 == 0 && canDamage && delay % 240 != 0)
        {
            Shoot();
        }
        else if (delay % 240 == 0)
        {
            burst = true;
        }
        if (delay % 245 == 0)
        {
            burst = false;
        }
        if (burst && canDamage)
        {
            Shoot();
        }
        delay++;

        if(currentHealth == 1 && !phase2)
        {
            maxHealth = 35;
            currentHealth = maxHealth;
            if (hasBar)
                healthbar.SetMaxHealth(maxHealth);
            ySpeed = 5;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "BossTrigger")
        {
            ySpeed = 3;
            xSpeed = 0;
            healthbar.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            canDamage = true;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Death>().damage();
        }
        if (col.gameObject.tag == "Boss Bounds")
        {
            ySpeed *= -1;
        }
    }

}
