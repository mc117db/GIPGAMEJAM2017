using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSequence : MonoBehaviour
{

    [SerializeField]
    public Sprite panel1;
    [SerializeField]
    public Sprite panel2;

    private int currPanel;
    private Sprite[] panels;

    // Use this for initialization
    void Start()
    {
        currPanel = 0;
        panels = new Sprite[2] { panel1, panel2 };
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (GameManager.Instance.gameStarted)
        {
            goToNextPanel();
        }
    }

    public void goToNextPanel()
    {
        if (currPanel >= panels.Length)
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = panels[currPanel];
            currPanel += 1;
        }
    }
}
