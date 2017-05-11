using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HardFireBehaviour : FireBehaviour {

	// Use this for initialization
	protected override void FireLevelOne(Vector2 aimDirection)
    {
        Vector2 fireVectorOne = Vector2.zero;
        Vector2 fireVectorTwo = Vector2.zero;
        // --------------- Calculation Fire Vectors ----------------------- //
        fireVectorOne = Vector2Helper.Rotate(aimDirection, 2.5f);
        fireVectorTwo = Vector2Helper.Rotate(aimDirection, -2.5f);
        // ---------------- Spawn Bullets -------------------------------- //
        SpawnBullet(fireVectorOne, LevelOneSpeed, LevelOneDamage);
        SpawnBullet(fireVectorTwo, LevelOneSpeed, LevelOneDamage);
    }
    protected override void FireLevelTwo(Vector2 aimDirection)
    {
        SpawnBullet(aimDirection, LevelTwoSpeed, LevelTwoDamage);
    }
}
