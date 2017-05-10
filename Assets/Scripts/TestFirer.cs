using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFirer : MonoBehaviour {

    // Use this for initialization

    public float firingRate = 0.2f;
    private float elaspedTime;
    public GameObject bulletPrefab;
    public Vector2 fireDirection;
    public float bulletSpeed;
	
	// Update is called once per frame
	void Update () {
		if (elaspedTime < firingRate)
        {
            elaspedTime += Time.deltaTime;
        }
        else
        {
            Fire();
            elaspedTime = 0;
        }
	}
    void Fire()
    {
        GameObject bulletGO = GameObjectUtil.Instantiate(bulletPrefab, transform.position);
        bulletGO.GetComponent<BulletBehaviour>().Initialize(fireDirection, bulletSpeed);
    }
}
