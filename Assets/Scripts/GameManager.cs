using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public bool gameStarted { get; private set; }
	public int enemyLeftInCurrentWave;

	/*
 	public bool GameStarted {
		get {
			return gameStarted;
		}
		set {
			if (gameStarted && enemyLeftInCurrentWave <= 0) {
				startNextWave ();
			}
			gameStarted = value;
		}
	}

	public int EnemyLeftInCurrentWave {
		get {
			return enemyLeftInCurrentWave;
		}
		set {
			if (gameStarted && enemyLeftInCurrentWave <= 0) {
				startNextWave ();
			}
			enemyLeftInCurrentWave = value;
		}
	}
	*/

	private readonly float waveStartDelay = 4.5f;
	private readonly float extraDelay = 2f;
	private readonly string enemyTagString = "Enemy";
	private readonly string playerTagString = "Player";
	private EnemySpawnerManager enemySpawnerManager;

	[SerializeField]
	private GameObject countdownPrefab;

    void Awake() {
		DontDestroyOnLoad (transform.gameObject);
        Instance = this;
    }
		
    void Start () {
        gameStarted = false;
		enemySpawnerManager = GetComponent<EnemySpawnerManager> ();
		EnemyCharacter.EnemyDeathEvent += decreaseEnemy;
	}

	void Update () {
		// for debugging========================================================================
		if(Input.GetKeyDown(KeyCode.P)) 
			gameStarted = true;
		if(Input.GetKeyDown(KeyCode.O)) 
			enemyLeftInCurrentWave = 0;
		// =====================================================================================

		if (gameStarted && enemyLeftInCurrentWave <= 0) {
			startNextWave ();
			print ("call once");
		}
	}

	public void startNextWave() {
		enemyLeftInCurrentWave = enemySpawnerManager.getEnemyNumber ();
		StartCoroutine (nextWaveEffects ());
	}

	IEnumerator nextWaveEffects() {
		yield return new WaitForSeconds (extraDelay);
		Instantiate (countdownPrefab, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(waveStartDelay);
		enemySpawnerManager.spawnNextWave ();
	}

	private void stopPlayerMovements() {
		GameObject player = GameObject.FindGameObjectWithTag (playerTagString);
		player.GetComponent<PlayerInputs> ().stopPlayerMovement ();
	}

	private void stopAllEnemiesMovements() {
		GameObject[] allEnemies = GameObject.FindGameObjectsWithTag (enemyTagString);
		foreach(GameObject enemy in allEnemies) {
			enemy.GetComponent<EnemyMovements> ().stopMovement ();
		}
	}
		
    public void startGame() {
        gameStarted = true;
    }

    public void exitGame() {
        Application.Quit();
    }

	void decreaseEnemy () {
		enemyLeftInCurrentWave--;
		print ("decreased! now left " + enemyLeftInCurrentWave);
	}

	/*
	IEnumerator gameWonEffects() {
		stopPlayerMovements ();
		stopAllEnemiesMovements ();
		yield return new WaitForSeconds (2f);
		// yan ling code here
	}
	*/

}
