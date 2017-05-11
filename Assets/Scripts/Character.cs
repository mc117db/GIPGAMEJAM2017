using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable{
	void TakeDamage (int damage);
}
public class Character : MonoBehaviour,IDamagable,IRecycle {

	public int maxHealth = 20;
	int hp;
	public delegate void OnValueChange(int value);
	public event OnValueChange HealthChangeEvent;
	public event OnValueChange TakeDamageEvent;

	public int Health
	{
		get{return hp;}
		set{
			hp = value;
			if (HealthChangeEvent != null) {
				HealthChangeEvent (hp);
			}
			if (hp != 0 && value <= 0) {
                hp = 0;
				Death ();
			}
		}
	}

	public virtual void TakeDamage(int damage)
	{
		Health -= damage;
		if (TakeDamageEvent != null) {
			TakeDamageEvent (damage);
		}
	}
	protected virtual void Start()
	{
		Restart ();
	}
	protected virtual void Death()
	{
		Debug.Log (gameObject.name + " DIED!");
	}
	public virtual void Restart()
	{
		Health = maxHealth;
	}
	public virtual void Shutdown()
	{
		
	}
}
