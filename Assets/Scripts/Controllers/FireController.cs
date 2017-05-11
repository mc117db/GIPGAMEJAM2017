using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireController : MonoBehaviour {

    public float RateOfFire;
    float elaspedTime;
    public Vector2 aimDirectionTEST;
    [Space(10)]
    public AffinityMode currentAffinity;
    public int affinityPower;
    [Space(10)]
    // In the future, can refactor this system into a Dictionary of <Key,FireBehaviour>
    public FireBehaviour HARDBEHAVIOUR;
    public FireBehaviour SOFTBEHAVIOUR;
    public delegate void OnEvent();
    public static event OnEvent FireEvent;
	
	// Update is called once per frame
	void Update () {
        #region Countdown RoF
        if (elaspedTime < RateOfFire)
        {
            elaspedTime += Time.deltaTime;
        }
        else
        {
            Fire();
            elaspedTime = 0;
        } 
        #endregion
    }
    void Fire()
    {
        switch (currentAffinity)
        {
            case AffinityMode.Hard:
                if (HARDBEHAVIOUR != null)
                {
                    HARDBEHAVIOUR.FireBasedOnAffinity(affinityPower, aimDirectionTEST);
                }
                break;
            case AffinityMode.Soft:
                if (SOFTBEHAVIOUR != null)
                {
                    SOFTBEHAVIOUR.FireBasedOnAffinity(affinityPower, aimDirectionTEST);
                }
                break;
        }
        if (FireEvent != null)
        {
            FireEvent();
        }
    }
}
