using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public delegate void OnValueChange(int score);
    public static event OnValueChange ScoreChangeEvent;
    [Space(20)]
    [Header("SCORE VALUE FOR ENEMY TYPES")]
    public int NormalEnemyScoreVal = 10;
    public int HeavyEnemyScoreVal = 30;
    public int SwarmEnemyScoreVal = 3;
    [Space(20)]
	private int score;
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            if (ScoreChangeEvent != null)
            {
                ScoreChangeEvent(score);
            }
        }
    }

    void Start () {
        EnemyCharacter.EnemyTypeDeathEvent += EnemyTypeDeathEvent;
	}
	void EnemyTypeDeathEvent(EnemyType enemyType)
	{
       switch (enemyType)
        {
            case EnemyType.Normal:
                Score += NormalEnemyScoreVal;
                break;
            case EnemyType.Heavy:
                Score += HeavyEnemyScoreVal;
                    break;
            case EnemyType.Swarm:
                Score += SwarmEnemyScoreVal;
                break;
        }
	}
    public void Reset()
    {
        Debug.Log("Reset score to zero");
        score = 0;
    }
}
