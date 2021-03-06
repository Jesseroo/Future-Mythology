using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

   

    public GameObject badBullet;
    public GameObject bossTrigger;
    GameObject a;
    public int delay = 0;
    public float xSpeed;
    public float ySpeed;
    public bool canDamage;
    public bool currLevel = false;
    public GameOverScreen Win;

    public AudioManager AM;

    public bool isJupiter;

    //bool initiated = false;

    public bool hasBar;
    public bool canShoot, canAim;
    public float fireRate;
    public static int maxHealth;
    public int currentHealth;
    public GameObject explosionRef;
    public HealthBar healthbar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        //healthbar.gameObject.SetActive(false);
        //currentHealth = maxHealth;
    }

    //void createEnemy()
    //{
    //    currentHealth = maxHealth;
    //    if (hasBar)
    //        healthbar.SetMaxHealth(maxHealth);
    //    initiated = true;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        //if(hasBar)
        //healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if(!initiated)
        //{
        //    createEnemy();
        //}
        if(currLevel)
            rb.velocity = new Vector2(xSpeed * -1, ySpeed);

        if(canShoot && delay > 10 * fireRate)
        {
            Shoot();
        }


        delay++;
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("OW");
            col.gameObject.GetComponent<Death>().damage();
            StartCoroutine("invuln");
            Die();
        }
        if (col.gameObject.tag == "KillPlane")
        {
            Die();
        }
    }

    void Die()
    {
        if (hasBar)
        {
            GameObject explosion = Instantiate(explosionRef);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
           LevelManager.levelManager.nextLevel();
            bossTrigger.SetActive(true);
        }
        if (hasBar && !isJupiter)
        {
            AM.Stop("Song");
            AM.Play("Song End");
            AM.Play("Song 2");
        }
        if (isJupiter)
        {
            Win.Setup();
        }
        Destroy(gameObject);
    }

    public void damage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
        }
        if (hasBar)
            healthbar.SetHealth(currentHealth);
    }

    void Shoot()
    {
        delay = 0;
        Instantiate(badBullet, a.transform.position, Quaternion.identity);
    }

}
