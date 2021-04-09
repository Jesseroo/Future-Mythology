using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] skulls;
    public int health;
    void Start()
    {
        
    }

    public void healthUpdate(int health)
    {
        if (health == 2)
            Destroy(skulls[0]);
        else if (health == 1)
            Destroy(skulls[1]);
        else if (health == 0)
            Destroy(skulls[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
