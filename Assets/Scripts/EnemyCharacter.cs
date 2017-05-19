using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Normal, Swarm, Heavy }
public class EnemyCharacter : Character {

    public EnemyType ENEMYTYPE;
    public int damageAmount = 5;
    public delegate void OnEnemyType(EnemyType enemyType);
	public static event OnValueChange GlobalEnemyTakeDamage;
    public static event OnEnemyType EnemyTypeDeathEvent;
	public delegate void OnEvent();
	public static event OnEvent EnemyDeathEvent;
    public static event OnEvent EnemyRemovalEvent; // This event accounts on both death and removal through contact with the players
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
		//GameManager.Instance.enemyLeftInCurrentWave--;
		if (EnemyDeathEvent != null) {
			EnemyDeathEvent ();
		}
        if (EnemyTypeDeathEvent != null)
        {
            EnemyTypeDeathEvent(ENEMYTYPE);
        }
        if (EnemyRemovalEvent != null)
        {
            EnemyRemovalEvent();
        }
		GameObjectUtil.Destroy (gameObject);
	}
    void OnCollisionEnter2D(Collision2D other)
    {  
        if (other.gameObject.layer == 8 )
        {
            //Layer 8 is Player in ProjectSettings/TagsLayers
            IDamagable otherCharacter = (IDamagable)other.gameObject.GetComponent(typeof(IDamagable));
            otherCharacter.TakeDamage(damageAmount);
            if (EnemyRemovalEvent != null)
            {
                EnemyRemovalEvent();
            }
            GameObjectUtil.Destroy(gameObject);
        }
    }
}
