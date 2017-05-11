using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	public int enemyScoreValue = 10;
	public int score;

	void Start () {
		EnemyCharacter.EnemyDeathEvent += EnemyDeathEvent;
	}
	void EnemyDeathEvent()
	{
		score += enemyScoreValue;
	}
}
