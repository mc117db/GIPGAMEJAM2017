using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour {

	[System.Serializable]
	private class MonsterGroup {
		public GameObject monsterType;
		public int monsterAmount;
		public float spawnTimer;
		public bool isRandom;
		public GameObject[] spawnpoints;
	}

	[System.Serializable]
	private class MonsterWave {
		public MonsterGroup[] monsterGroupList;
	}


//================================================== Main class information =========================================================//


	[SerializeField]
	private MonsterWave[] monsterWaveList;
	private GameObject[] spawnpointList;
	private int nextWaveIndex = 0;


	public void spawnNextWave() {
		MonsterWave targetWave = monsterWaveList [nextWaveIndex];
		foreach(MonsterGroup grp in targetWave.monsterGroupList){
			StartCoroutine (spawnGroup (grp));
		}
		nextWaveIndex = (nextWaveIndex + 1) % monsterWaveList.Length;
	}

	IEnumerator spawnGroup(MonsterGroup grp) {
		yield return new WaitForSeconds (grp.spawnTimer);
		if (!grp.isRandom && grp.spawnpoints.Length == 0) {
			Instantiate (grp.monsterType, spawnpointList[0].transform.position, Quaternion.identity);
		}
		for (int n = 0; n < grp.monsterAmount; n++) {
			Vector2 spawnLocation = grp.isRandom? 
				spawnpointList[Random.Range(0, spawnpointList.Length)].transform.position: 
				grp.spawnpoints[Random.Range(0, grp.spawnpoints.Length)].transform.position;
			Instantiate (grp.monsterType, spawnLocation, Quaternion.identity);
		}
	}
}
