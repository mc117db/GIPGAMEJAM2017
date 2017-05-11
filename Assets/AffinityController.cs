using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AffinityMode { Hard, Soft }
public class AffinityController : MonoBehaviour {
    public static AffinityController instance;

    private float currentAffinityPoint = 0;
    private float rangeTowardsMaxAffinity;
    public float degradeRate = 2f;

    public int levelOneThreshold;
    [Header("Second threshold additive from the first one")]
    public int levelTwoAdditiveThreshold;
    public bool ultimateReady;

    private AffinityMode currentAffinity;
    public AffinityMode CurrentAffinity
    {
        get
        {
            return currentAffinity;
        }

        set
        {
            currentAffinity = value;
        }
    }
    public float CurrentAffinityPoint
    {
        get
        {
            return currentAffinityPoint;
        }

        set
        {
            currentAffinityPoint = value;
        }
    }

    public int currentAffinityPower;

    #region MonoBehaviour
    private void Awake()
    {
        AffinityController.instance = this;
    }
    private void Start()
    {
        if (instance != this)
        {
            Destroy(this);
        }
        rangeTowardsMaxAffinity = levelOneThreshold + levelTwoAdditiveThreshold;
    }
    private void Update()
    {
        DegradeAffinityOverTime();
        CurrentAffinityPoint = Mathf.Clamp(CurrentAffinityPoint,
            -rangeTowardsMaxAffinity,
            rangeTowardsMaxAffinity); // Clamp within the range
        if (CurrentAffinityPoint < 0)
        {
            CurrentAffinity = AffinityMode.Hard;
        }
        else
        {
            CurrentAffinity = AffinityMode.Soft;
        }
    }
    #endregion

    void DegradeAffinityOverTime()
    {
        if (currentAffinityPoint != 0)
        {
            currentAffinityPoint -= Time.deltaTime * degradeRate;
        }
    }
    private void AddPointTowardsAffinity(AffinityMode mode, float point)
    {
        if (CurrentAffinity != mode)
        {
            CurrentAffinityPoint = Mathf.MoveTowards(currentAffinityPoint, 0, point);
        }
        else
        {
            CurrentAffinityPoint = Mathf.MoveTowards(currentAffinityPoint, 0, -point);
        }
    }
}
