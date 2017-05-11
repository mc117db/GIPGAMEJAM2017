using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUICanvas : MonoBehaviour {

    public int score;
    public int health;
    public float affinityLevel; // [-1, 1]
    public float ultiLevel; // [0, 2]

    // reference to displayed UI elements
    private Text ui_scoreval;
    private Text ui_healthval;
    private Image ui_affinitybar;
    private Image ui_affinitypointer;
    private Image ui_ulticontainer;
    private Image ui_ultibar;

    // "constants"
    private float AFF_BAR_HEIGHT;
    private float ULTI_BAR_HEIGHT;

	// Use this for initialization
	void Start () {
        initValues();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initValues()
    {
        ui_scoreval = transform.Find("scoreValue").GetComponent<Text>();
        ui_healthval = transform.Find("healthValue").GetComponent<Text>();
        ui_affinitybar = transform.Find("affinityBar").GetComponent<Image>();
        ui_affinitypointer = ui_affinitybar.transform.Find("affinityIndicator").GetComponent<Image>();
        ui_ulticontainer = transform.Find("ultiContainer").GetComponent<Image>();
        ui_ultibar = ui_ulticontainer.transform.Find("ultiBar").GetComponent<Image>();

        AFF_BAR_HEIGHT = ui_affinitybar.rectTransform.sizeDelta.y;
        ULTI_BAR_HEIGHT = ui_ulticontainer.rectTransform.sizeDelta.y;

        ui_scoreval.text = score.ToString();
        ui_healthval.text = health.ToString();
        ui_affinitypointer.rectTransform.localPosition = new Vector2(-22, affinityLevel*AFF_BAR_HEIGHT/2);
        ui_ultibar.rectTransform.sizeDelta = new Vector2(20, ULTI_BAR_HEIGHT * ultiLevel / 2);
    }

    void updateScore(int val)
    {
        score = val;
        ui_scoreval.text = score.ToString();
    }

    void updateHealth(int val)
    {
        health = val;
        ui_healthval.text = health.ToString();
    }

    void updateAffinity(float val)
    {
        affinityLevel = val;
        ui_affinitypointer.rectTransform.localPosition = new Vector2(-22, affinityLevel * AFF_BAR_HEIGHT / 2);
    }

    void updateUltiLevel(float val)
    {
        ultiLevel = val;
        ui_ultibar.rectTransform.sizeDelta = new Vector2(20, ULTI_BAR_HEIGHT * ultiLevel / 2);
    }
}
