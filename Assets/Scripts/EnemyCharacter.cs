using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character {

	// Use this for initialization
	public static event OnValueChange GlobalEnemyTakeDamage;
	public delegate void OnEvent();
	public static event OnEvent EnemyDeathEvent;
	public override void TakeDamage (int damage)
	{
		base.TakeDamage (damage);
		if (GlobalEnemyTakeDamage != null) {
			GlobalEnemyTakeDamage (damage);
		}
	}
	protected override void Death ()
	{
        base.Death();
		//Gamemanager.instance.EnemyLeftInCurrentWave--;
		if (EnemyDeathEvent != null) {
			EnemyDeathEvent ();
		}
		GameObjectUtil.Destroy (gameObject);
	}
}
