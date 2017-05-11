using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public bool gameStarted { get; private set; }

	private readonly float waveStartDelay = 3f;
	private EnemySpawnerManager enemySpawnerManager;
	private bool isGameWon = false;
	private int enemyLeftInCurrentWave;
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


		if (gameStarted && !isGameWon && isNextWaveReady()) {
			startNextWave ();
		}
	}

	public void startNextWave() {
		enemyLeftInCurrentWave = enemySpawnerManager.getEnemyNumber ();
		StartCoroutine (nextWaveEffects ());
	}

	IEnumerator nextWaveEffects() {
		// play 5,4,3,2,1
		yield return new WaitForSeconds(waveStartDelay);
		enemySpawnerManager.spawnNextWave ();
	}

	private bool isNextWaveReady() {
		if (enemyLeftInCurrentWave <= 0) {
			return true;
		} else {
			return false;
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
