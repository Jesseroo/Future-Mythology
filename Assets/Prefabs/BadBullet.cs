using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBullet : MonoBehaviour
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
        rb.velocity = new Vector2(15 * -dir, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("OW");
            col.gameObject.GetComponent<Death>().damage();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "KillPlane")
        {
            Destroy(gameObject);
        }
    }
}
