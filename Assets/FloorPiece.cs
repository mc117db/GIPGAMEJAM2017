using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPiece : MonoBehaviour {

    public GameObject indicator;

    private int rankIndex;
    private bool isOpen = false;

    public delegate void OnIndicatorPress(int index);
    public event OnIndicatorPress OnIndicatorClickEvent;

    void Start()
    {
       OnIndicatorClickEvent += delegate { testMethod(); };
    }



    public int getRankIndex()
    {
        return this.rankIndex;
    }

    public void setRankIndex(int index)
    {
        this.rankIndex = index;
    }

    public void openIndicator()
    {
        if(!isOpen)
        {
            // open
            indicator.SetActive(true);
        }
    }

    public void closeIndicator()
    {
        if(isOpen)
        {
            // close
            indicator.SetActive(false);
        }
    }

    public void FireIndicatorClickEvent()
    {
        if(OnIndicatorClickEvent != null)
        {
            OnIndicatorClickEvent(this.rankIndex);
        }
        FloorManager.instance.closeAllIndicators();
    }

    public void testMethod()
    {
        print("event fired!!!!!!!!!!! Rank index clicked is: " + this.rankIndex);
    }
    void OnTriggerEnter(Collider hit)
    {
        
    }
}
