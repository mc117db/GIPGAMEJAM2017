using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public bool gameStarted { get; private set; }
	public int enemyLeftInCurrentWave;

	private readonly float waveStartDelay = 6f;
	private readonly string enemyTagString = "Enemy";
	private readonly string playerTagString = "Player";
	private EnemySpawnerManager enemySpawnerManager;
	private bool isGameWon = false;
	[SerializeField]
	private GameObject countdownPrefab;

    void Awake() {
		DontDestroyOnLoad (transform.gameObject);
        Instance = this;
    }
		
    void Start () {
        gameStarted = false;
		enemySpawnerManager = GetComponent<EnemySpawnerManager> ();
	}

	void Update () {
		// for debugging========================================================================
		if(Input.GetKeyDown(KeyCode.P)) {
			gameStarted = true;
		}
		if(Input.GetKeyDown(KeyCode.O)) {
			resetEnemyNumber ();
		}
		// =====================================================================================
		if (enemySpawnerManager.nextWaveIndex == enemySpawnerManager.monsterWaveList.Length - 1
			&& enemyLeftInCurrentWave <= 0 && !isGameWon) {
			isGameWon = true;
			StartCoroutine (gameWonEffects());
		}

		if (gameStarted && !isGameWon && isNextWaveReady()) {
			startNextWave ();
		}
	}

	public void startNextWave() {
		enemyLeftInCurrentWave = enemySpawnerManager.getEnemyNumber ();
		StartCoroutine (nextWaveEffects ());
	}

	private bool isNextWaveReady() {
		if (enemyLeftInCurrentWave <= 0) {
			return true;
		} else {
			return false;
		}
	}

	IEnumerator nextWaveEffects() {
		Instantiate (countdownPrefab, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(waveStartDelay);
		enemySpawnerManager.spawnNextWave ();
	}

	IEnumerator gameWonEffects() {
		stopPlayerMovements ();
		stopAllEnemiesMovements ();
		yield return new WaitForSeconds (2f);
		// yan ling code here
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




	// for debugging ====================================================================================
	public void resetEnemyNumber() {
		enemyLeftInCurrentWave = 0;
	}
}
