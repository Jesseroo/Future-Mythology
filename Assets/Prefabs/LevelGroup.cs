using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Enemy> enemies = new List<Enemy>();

    public void startLevel()
    {
        for(int x =0; x < enemies.Count; x++)
        {
            enemies[x].gameObject.SetActive(true);
            enemies[x].currLevel = true;
        }
    }

    public void endLevel()
    {
        for (int x = 0; x < enemies.Count; x++)
        {
            enemies[x].gameObject.SetActive(false);
            enemies[x].currLevel = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
