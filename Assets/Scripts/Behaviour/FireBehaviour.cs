using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour {
    public GameObject bulletPrefab;
    public void FireBasedOnAffinity(int affinityPower)
    {
        switch (affinityPower)
        {
            case 1:
                FireLevelOne();
                break;
            case 2:
                FireLevelTwo();
                break;
            case 3:
                FireLevelThree();
                break;
            case 4:
                FireLevelFour();
                break;
            case 5:
                FireLevelFive();
                break;
            default:
                break;
        }
    }
    #region Firing Implementations
    protected virtual void FireLevelOne()
    {

    }
    protected virtual void FireLevelTwo()
    {

    }
    protected virtual void FireLevelThree()
    {

    }
    protected virtual void FireLevelFour()
    {

    }
    protected virtual void FireLevelFive()
    {

    }
    #endregion
}
