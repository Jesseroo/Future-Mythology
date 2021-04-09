using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int dir = 1;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public void ChangeDirection()
    {
        dir *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(5 * dir, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy" && col.gameObject.GetComponent<Enemy>().canDamage)
        {
            col.gameObject.GetComponent<Enemy>().damage();
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
