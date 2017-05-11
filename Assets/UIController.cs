using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text scoreText;
    public Text healthText;
    public Slider countdownTimer;
	// Use this for initialization
	void Start () {
        PlayerCharacter.instance.HealthChangeEvent += UpdateHealth;
        ScoreController.ScoreChangeEvent += UpdateScore;
        FireController.OnAmmoLerpChangeEvent += UpdateAmmoBarLerp;
    }
	void UpdateScore (int score)
    {
        scoreText.text = score.ToString();
    } 
    void UpdateHealth(int health)
    {
        healthText.text = health.ToString();
    }
    void UpdateAmmoBarLerp(float lerpVal)
    {
        countdownTimer.value = lerpVal;
    }
}
