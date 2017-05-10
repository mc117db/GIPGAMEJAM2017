using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BulletBehaviour : MonoBehaviour, IRecycle {

    Vector2 bulletVelocity;
    float speed;
    int damage;
    Rigidbody2D rigidbodyComponent;
	// Update is called once per frame
    public void Initialize(Vector2 vel,float spd)
    {
        rigidbodyComponent = gameObject.GetComponent<Rigidbody2D>();
        bulletVelocity = vel.normalized;
        speed = spd;
        rigidbodyComponent.velocity = bulletVelocity * speed;
    }
    public void Initialize(Vector2 vel, float spd,int dmg)
    {
        Initialize(vel, spd);
        damage = dmg;
    }

    void Update () {
        if (!CheckIfOffScreen())
        {
            GameObjectUtil.Destroy(gameObject);
        }
	}
    bool CheckIfOffScreen()
    {
        Vector3 bulletScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (bulletScreenPoint.x < 0 || bulletScreenPoint.x > Screen.width || bulletScreenPoint.y < 0 || bulletScreenPoint.y > Screen.height)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    // Object pooler interface implementations
    public void Restart()
    {
        bulletVelocity = Vector2.zero;
        speed = 0;
    }

    public void Shutdown()
    {
        bulletVelocity = Vector2.zero;
        speed = 0;
    }
}
