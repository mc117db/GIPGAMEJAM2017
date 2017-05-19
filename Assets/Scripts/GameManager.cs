using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public bool gameStarted { get; private set; }
	public int enemyLeftInCurrentWave;
    private bool isSpawningCountdown;

    public GameObject gameoverPanel;
    private bool hasBubbleStarted = false;

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
        gameStarted = true;
		enemySpawnerManager = GetComponent<EnemySpawnerManager> ();
		EnemyCharacter.EnemyRemovalEvent += decreaseEnemy;
        PlayerCharacter.PlayerDeath += LoseEvent;

    }

	void Update () {
		// for debugging========================================================================
		if(Input.GetKeyDown(KeyCode.P)) 
			gameStarted = true;
		if(Input.GetKeyDown(KeyCode.O)) 
			enemyLeftInCurrentWave = 0;
		if(Input.GetKeyDown(KeyCode.Z)) 
			print("you get resource: " + Random.Range(1, 4));
		if(Input.GetKeyDown(KeyCode.X)) 
			print("you get %: " + Random.Range(1, 101) + "%");
        // =====================================================================================
		if (gameStarted && enemyLeftInCurrentWave <= 0) {
            if(!isSpawningCountdown)
			startNextWave ();
		}
        if(!hasBubbleStarted && gameStarted) {
            hasBubbleStarted = true;
            // statrt spawning bubble
        }
        
	}

	public void startNextWave() {
        print("SPAWNNNNNNNNNNNNNNNNNNN");
        isSpawningCountdown = true;
        enemyLeftInCurrentWave = enemySpawnerManager.getEnemyNumber ();
		StartCoroutine (nextWaveEffects ());
	}

	IEnumerator nextWaveEffects() {
		yield return new WaitForSeconds (extraDelay);
		Instantiate (countdownPrefab, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(waveStartDelay);
        isSpawningCountdown = false;
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

    private void killAllEnemiesMovements()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(enemyTagString);
        foreach (GameObject enemy in allEnemies)
        {
            Destroy(enemy);
        }
    }
    private void LoseEvent()
    {
        killAllEnemiesMovements();
       // Cursor.visible = true;
        enemyLeftInCurrentWave = 0;
        enemySpawnerManager.nextWaveIndex = 0;
        gameoverPanel.SetActive(true);
        gameStarted = false;
        enemySpawnerManager.StopAllCoroutines();
        StartCoroutine(RestartGame());
        //OVER SHOW GAME OVER SCREEN
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4f);
        gameoverPanel.SetActive(false);
        PlayerCharacter.instance.Restart();
        FireController.instance.Reload();
        gameStarted = true;
    }

    public void startGame() {
        gameStarted = true;
    }

    public void exitGame() {
        Application.Quit();
    }

	void decreaseEnemy () {
		enemyLeftInCurrentWave--;
        print("decrease!!!!!!!!!!!!");
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
