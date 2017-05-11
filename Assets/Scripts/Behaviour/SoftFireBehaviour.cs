using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SoftFireBehaviour : FireBehaviour {

    // Use this for initialization
    protected override void FireLevelOne(Vector2 aimDirection)
    {
        Vector2 fireVectorOne = Vector2.zero;
        Vector2 fireVectorTwo = Vector2.zero;
        Vector2 fireVectorThree = Vector2.zero;
        Vector2 fireVectorFour = Vector2.zero;

        // --------------- Calculation Fire Vectors ----------------------- //
        fireVectorOne = Vector2Helper.Rotate(aimDirection, 10);
        fireVectorTwo = Vector2Helper.Rotate(aimDirection, 2.5f);
        fireVectorThree = Vector2Helper.Rotate(aimDirection, -2.5f);
        fireVectorFour = Vector2Helper.Rotate(aimDirection, -10);

        // ---------------- Spawn Bullets -------------------------------- //
        SpawnBullet(fireVectorOne, LevelOneSpeed, LevelOneDamage);
        SpawnBullet(fireVectorTwo, LevelOneSpeed, LevelOneDamage);
        SpawnBullet(fireVectorThree, LevelOneSpeed, LevelOneDamage);
        SpawnBullet(fireVectorFour, LevelOneSpeed, LevelOneDamage);
    }
    protected override void FireLevelTwo(Vector2 aimDirection)
    {
        Vector2 fireVectorOne = Vector2.zero;
        Vector2 fireVectorTwo = Vector2.zero;
        Vector2 fireVectorThree = Vector2.zero;
        Vector2 fireVectorFour = Vector2.zero;
        Vector2 fireVectorFive = Vector2.zero;
        // --------------- Calculation Fire Vectors ----------------------- //
        fireVectorOne = Vector2Helper.Rotate(aimDirection, 12);
        fireVectorTwo = Vector2Helper.Rotate(aimDirection, 5);
        fireVectorThree = aimDirection;
        fireVectorFour = Vector2Helper.Rotate(aimDirection, -5);
        fireVectorFive = Vector2Helper.Rotate(aimDirection, -12);
        // -------------- Spawn bullets ---------------------------- //
        SpawnBullet(fireVectorOne, LevelTwoSpeed, LevelTwoDamage);
        SpawnBullet(fireVectorTwo, LevelTwoSpeed, LevelTwoDamage);
        SpawnBullet(fireVectorThree, LevelTwoSpeed, LevelTwoDamage);
        SpawnBullet(fireVectorFour, LevelTwoSpeed, LevelTwoDamage);
        SpawnBullet(fireVectorFive, LevelTwoSpeed, LevelTwoDamage);
    }
}
