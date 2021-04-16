using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManager levelManager;
    public List<LevelGroup> Levels = new List<LevelGroup>();
    public int currentLevel;

    private void Awake()
    {
        if(levelManager != null)
        {
            GameObject.Destroy(levelManager);
        }
        else
        {
            levelManager = this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Levels[currentLevel].startLevel();
    }

    public void nextLevel()
    {
        //Levels[currentLevel].endLevel();
        currentLevel++;
        if(currentLevel <= Levels.Count)
            Levels[currentLevel].startLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
