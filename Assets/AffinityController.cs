using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AffinityMode { Hard, Soft }
public class AffinityController : MonoBehaviour {
    public static AffinityController instance;
    public float inputScrollDelta;
    public float affinityScrollMult = 0.5f;

    private float currentAffinityPoint = 0;
    public float currentAffinityLerp01;
    private float rangeTowardsMaxAffinity;
    public float degradeRate = 2f;

    public int levelOneThreshold;
    [Header("Second threshold additive from the first one")]
    public int levelTwoAdditiveThreshold;
    public bool ultimateReady;
    public delegate void OnAffinityChange(AffinityMode mode, int power);
    public static event OnAffinityChange AffinityChange; //TODO: Deal with this when the scene change

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
            float currentAffinityAbs = Mathf.Abs(currentAffinityPoint);
            if (currentAffinityAbs < levelOneThreshold)
            {
                currentAffinityPower = 0;
            }
            else if (currentAffinityAbs > levelOneThreshold && currentAffinityAbs < rangeTowardsMaxAffinity)
            {
                currentAffinityPower = 1;
            }
            else if (currentAffinityAbs == rangeTowardsMaxAffinity)
            {
                currentAffinityPower = 2;
            }
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
        //DegradeAffinityOverTime();
        inputScrollDelta = Input.mouseScrollDelta.y;
        CurrentAffinityPoint += inputScrollDelta * affinityScrollMult;
        

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
        currentAffinityLerp01 = Mathf.InverseLerp(-rangeTowardsMaxAffinity, rangeTowardsMaxAffinity, CurrentAffinityPoint);
        if (AffinityChange != null)
        {
            AffinityChange(CurrentAffinity, currentAffinityPower);
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
