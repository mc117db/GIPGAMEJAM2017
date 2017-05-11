using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public bool gameStarted { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame()
    {
        gameStarted = true;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
