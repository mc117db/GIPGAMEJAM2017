﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireBehaviour:MonoBehaviour {
    public GameObject bulletPrefab;
    public int LevelOneDamage;
    public float LevelOneSpeed;
    public int LevelTwoDamage;
    public float LevelTwoSpeed;

    public void FireBasedOnAffinity(int affinityPower,Vector2 aimDirection)
    {
        switch (affinityPower)
        {
            case 1:
                FireLevelOne(aimDirection);
                break;
            case 2:
                FireLevelTwo(aimDirection);
                break;
        }
    }
    #region Firing Implementations
    protected virtual void FireLevelOne(Vector2 aimDirection)
    {
        Debug.Log("Fire level 1, you probably forget to set your child function marked as override");
    }
    protected virtual void FireLevelTwo(Vector2 aimDirection)
    {
        Debug.Log("Fire level 2, you probably forget to set your child function marked as override");
    }
    protected void SpawnBullet(Vector2 fireDir,float spd,int dmg)
    {
        GameObject bulletOne = GameObjectUtil.Instantiate(bulletPrefab, transform.position);
        bulletOne.GetComponent<BulletBehaviour>().Initialize(fireDir, spd, dmg);
    }
    #endregion
}