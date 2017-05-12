using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // Use this for initialization
    public AudioSource[] audioSources;
    public AudioClip[] enemyDeath_audioClip;
	void Start () {
        EnemyCharacter.EnemyTypeDeathEvent += EnemyCharacter_EnemyTypeDeathEvent;
	}

    private void EnemyCharacter_EnemyTypeDeathEvent(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Normal:
                PlayEnemyDeathAudio(0);
                break;
            case EnemyType.Heavy:
                PlayEnemyDeathAudio(1);
                break;
            case EnemyType.Swarm:
                PlayEnemyDeathAudio(2);
                break;
        }
    }

    // Update is called once per frame
    void PlayEnemyDeathAudio(int audioClipNo)
    {
        //Debug.Log("Playsound enemysound effect");
        audioSources[0].PlayOneShot(enemyDeath_audioClip[audioClipNo]);
    }
}
