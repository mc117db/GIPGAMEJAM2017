using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToggleFire { void ToggleFire(bool isOn); }
public interface IAddAmmo { void AddAmmo(float ammoAmount); }
public class FireController : MonoBehaviour,IToggleFire,IAddAmmo {
    public static FireController instance;
	public bool canShoot;
    public float RateOfFire;
    private float currentAmmo;
    public float maxAmmo;
    public float ammoPerShot;
    float elaspedTime;
    public Vector2 aimDirectionTEST;
    public delegate void OnAmmoLerpChange(float lerp01);
    public static event OnAmmoLerpChange OnAmmoLerpChangeEvent;
    [Space(10)]
    //public AffinityMode currentAffinity;
    //public int affinityPower;
    [Space(10)]
    // In the future, can refactor this system into a Dictionary of <Key,FireBehaviour>
    //public FireBehaviour HARDBEHAVIOUR;
    //public FireBehaviour SOFTBEHAVIOUR;
    public FireBehaviour NeutralFireBehaviour;
    public delegate void OnEvent();
    public static event OnEvent FireEvent;
	public bool playerTransformInchargeOfAim;

    public float CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }

        set
        {
            currentAmmo = value;
            currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
            if (OnAmmoLerpChangeEvent != null)
            {
                OnAmmoLerpChangeEvent(Mathf.InverseLerp(0, maxAmmo, currentAmmo));
            }
            if (currentAmmo <= 0)
            {
                canShoot = false;
				transform.parent.GetComponent<PlayerAnim> ().isSoggy = false;
				transform.parent.GetComponent<PlayerAimLine> ().isSoggy = false;
				transform.parent.GetComponent<PlayerMovements> ().isSoggy = false;
            }
            else
            {
                canShoot = true;
				transform.parent.GetComponent<PlayerAnim> ().isSoggy = true;
				transform.parent.GetComponent<PlayerAimLine> ().isSoggy = true;
				transform.parent.GetComponent<PlayerMovements> ().isSoggy = true;
            }
        }
    }

    //public bool inheritPlayerVelocity;
    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Start()
	{
        #region OldCode
        //      AffinityController.AffinityChange += ModifyFireSettings;
        if (playerTransformInchargeOfAim) {
            //	HARDBEHAVIOUR.TogglePlayerInchargeOfAim (true);
            //	SOFTBEHAVIOUR.TogglePlayerInchargeOfAim (true);
            NeutralFireBehaviour.TogglePlayerInchargeOfAim(true);
        }
        CurrentAmmo = maxAmmo;
        //if (inheritPlayerVelocity) {
        //	HARDBEHAVIOUR.ToggleInheritMovemement (true);
        //	SOFTBEHAVIOUR.ToggleInheritMovemement (true);
        //}

        #endregion
    }
    #region OldCode
    //void ModifyFireSettings(AffinityMode mode, int power)
    //{
    //    currentAffinity = mode;
    //    affinityPower = power;
    //} 
    #endregion
    void Update () {
        #region Countdown RoF
		if (canShoot) {
        	if (elaspedTime < RateOfFire)
        	{
        	    elaspedTime += Time.deltaTime;
        	}
        	else
        	{
        	    Fire();
        	    elaspedTime = 0;
        	}
        } 
        #endregion
    }
    void Fire()
    {
        CurrentAmmo -= ammoPerShot;
        NeutralFireBehaviour.FireBasedOnAffinity(0, aimDirectionTEST);
    }
    public void Reload()
    {
        CurrentAmmo = maxAmmo;
    }
    public void ToggleFire(bool isOn)
    {
        canShoot = isOn;
    }

    public void AddAmmo(float ammoAmount)
    {
        CurrentAmmo += ammoAmount;
    }
    #region OldCode
    // ------------------ I worked for 3 hours and in the end this gets scrapped
    //void Fire()
    //{
    //    switch (currentAffinity)
    //    {
    //        case AffinityMode.Hard:
    //            if (HARDBEHAVIOUR != null)
    //            {
    //                HARDBEHAVIOUR.FireBasedOnAffinity(affinityPower, aimDirectionTEST);
    //            }
    //            break;
    //        case AffinityMode.Soft:
    //            if (SOFTBEHAVIOUR != null)
    //            {
    //                SOFTBEHAVIOUR.FireBasedOnAffinity(affinityPower, aimDirectionTEST);
    //            }
    //            break;
    //    }
    //    if (FireEvent != null)
    //    {
    //        FireEvent();
    //    }
    //} 
    #endregion
}
