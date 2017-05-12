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
    [SerializeField]
    public Sprite panel3;
    [SerializeField]
    public Sprite tutorialScreen;
    public GameObject title;

    private int currPanel;
    private Sprite[] panels;

    // Use this for initialization
    void Start()
    {
        currPanel = 0;
        panels = new Sprite[4] { panel1, panel2, panel3, tutorialScreen };
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
            goToNextPanel();
    }

    public void goToNextPanel()
    {
        if (currPanel >= panels.Length)
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            if (title.activeSelf)
            {
                title.SetActive(false);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = panels[currPanel];
                currPanel += 1;
            }
        }
    }
}
