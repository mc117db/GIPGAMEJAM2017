using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToggleFire { void ToggleFire(bool isOn); }
public class FireController : MonoBehaviour,IToggleFire {
	public bool canShoot;
    public float RateOfFire;
    float elaspedTime;
    public Vector2 aimDirectionTEST;
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
	//public bool inheritPlayerVelocity;
	
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
        NeutralFireBehaviour.FireBasedOnAffinity(0, aimDirectionTEST);
    }
    public void ToggleFire(bool isOn)
    {
        canShoot = isOn;
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
