using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public bool title;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        if(!title)
            SceneManager.LoadScene("Level 1");
        else
        {
            FindObjectOfType<AudioManager>().Play("Song");
            LevelManager.levelManager.nextLevel();
            gameObject.SetActive(false);
        }
    }
}
