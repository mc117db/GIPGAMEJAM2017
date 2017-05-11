using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePool : MonoBehaviour {

    public int bubbleCount;
    public float bubbleRespawnTime;

    public GameObject bubblePrefab;
    private GameObject[] bubbleArray;
    private Vector2[] baseSpawnLocations;

    private Vector2 origPos;

    // Use this for initialization
    void Start()
    {
        origPos = transform.localPosition;

        bubbleArray = new GameObject[bubbleCount];
        for (int i = 0; i < bubbleCount; i++)
        {
            bubbleArray[i] = Instantiate(bubblePrefab, GetComponent<Transform>());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnBubbles()
    {

    }

    // call resetBubbles() everytime player touches a bubble
    void resetBubbles()
    {
        for (int i = 0; i < bubbleCount; i++)
        {
            bubbleArray[i].transform.localPosition = origPos;
        }
    }
}
