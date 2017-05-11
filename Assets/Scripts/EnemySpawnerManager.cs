using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour {

	[System.Serializable]
	public class MonsterGroup {
		public GameObject monsterType;
		public int monsterAmount;
		public float spawnTimer;
		public bool isRandom;
		public GameObject[] spawnpoints;
	}

	[System.Serializable]
	public class MonsterWave {
		public MonsterGroup[] monsterGroupList;
	}


//================================================== Main class information =========================================================//

	[HideInInspector]public int totalWaveEnemy;
	[HideInInspector]public int nextWaveIndex = 0;

	public MonsterWave[] monsterWaveList;

	[Space(10)]
	public GameObject[] spawnpointList;

	public void spawnNextWave() {
		MonsterWave targetWave = monsterWaveList [nextWaveIndex];
		foreach(MonsterGroup grp in targetWave.monsterGroupList){
			StartCoroutine (spawnGroup (grp));
		}
		nextWaveIndex = (nextWaveIndex + 1) % monsterWaveList.Length;
	}

	// return the total number of enemies in that wave.
	public int getEnemyNumber() {
		MonsterWave targetWave = monsterWaveList [nextWaveIndex];
		totalWaveEnemy = 0;
		foreach(MonsterGroup grp in targetWave.monsterGroupList){
			totalWaveEnemy += grp.monsterAmount;
		}
		return totalWaveEnemy;
	}

	IEnumerator spawnGroup(MonsterGroup grp) {
		yield return new WaitForSeconds (grp.spawnTimer);
		if (!grp.isRandom && grp.spawnpoints.Length == 0) {
			for (int n = 0; n < grp.monsterAmount; n++) {
				Instantiate (grp.monsterType, spawnpointList [0].transform.position, Quaternion.identity);
			}
		} else {
			for (int n = 0; n < grp.monsterAmount; n++) {
				Vector2 spawnLocation = grp.isRandom ? 
				spawnpointList [Random.Range (0, spawnpointList.Length)].transform.position : 
				grp.spawnpoints [Random.Range (0, grp.spawnpoints.Length)].transform.position;
				Instantiate (grp.monsterType, spawnLocation, Quaternion.identity);
			}
		}
	}
}
