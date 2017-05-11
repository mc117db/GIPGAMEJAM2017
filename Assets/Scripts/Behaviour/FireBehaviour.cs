using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour:MonoBehaviour {
    public GameObject bulletPrefab;
    public static int DefaultDamage = 3;
    public static int DefaultSpeed = 3;
    public int LevelOneDamage;
    public float LevelOneSpeed;
    public int LevelTwoDamage;
    public float LevelTwoSpeed;
	[Header("Toggle this if player is responsible for rotating")]
	private bool isPlayerInchargeOfAim;
	private bool inheritMovementVelocity;
	public Transform rootTransform;
	public Rigidbody2D rootRigidbody;

	public void TogglePlayerInchargeOfAim (bool isON)
	{
		isPlayerInchargeOfAim = isON;
	}
	public void ToggleInheritMovemement(bool isOn)
	{
		inheritMovementVelocity = isOn;
	}
    public void FireBasedOnAffinity(int affinityPower,Vector2 aimDirection)
    {
		Vector2 finalAimDir = aimDirection;
		if (isPlayerInchargeOfAim) {
			finalAimDir = rootTransform.right;
		}
        switch (affinityPower)
        {
            case 0:
			FireDefault(finalAimDir);
                    break;
            case 1:
			FireLevelOne(finalAimDir);
                break;
            case 2:
			FireLevelTwo(finalAimDir);
                break;
        }
    }
    #region Firing Implementations
    void FireDefault (Vector2 aimDirection)
    {
        Vector2 fireVectorOne = Vector2.zero;
        Vector2 fireVectorTwo = Vector2.zero;
        // --------------- Calculation Fire Vectors ----------------------- //
        fireVectorOne = Vector2Helper.Rotate(aimDirection, 2.5f);
        fireVectorTwo = Vector2Helper.Rotate(aimDirection, -2.5f);
        // ---------------- Spawn Bullets -------------------------------- //
        SpawnBullet(fireVectorOne, DefaultSpeed, DefaultDamage);
        SpawnBullet(fireVectorTwo, DefaultSpeed, DefaultDamage);
        SpawnBullet(aimDirection, DefaultSpeed, DefaultDamage);
    }
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
		bulletOne.GetComponent<BulletBehaviour>().Initialize(inheritMovementVelocity?fireDir+rootRigidbody.velocity:fireDir, spd, dmg);
    }
    #endregion
}
