using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuCanvas : MonoBehaviour
{

    private bool isPaused;

    // Use this for initialization
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            togglePause();
        }
    }

    void togglePause()
    {
        if (isPaused)
        {
            resumeGame();
        }
        else
        {
            pauseGame();
        }
    }

    void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        transform.Find("GamePausedText").GetComponent<Text>().text = "Game Paused";
    }

    void resumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        transform.Find("GamePausedText").GetComponent<Text>().text = "";
    }
}
