using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePool : MonoBehaviour {

    public int bubbleCount;
    public float bubbleRespawnTime;

    public GameObject bubblePrefab;
    private GameObject[] bubbleArray;
    private List<Vector2> baseSpawnLocations;
    private System.Random randomizer;
    List<Vector2> temp;

    private Vector2 origPos;

    // Use this for initialization
    void Start()
    {
        randomizer = new System.Random();
        origPos = transform.localPosition;

        // init bubbles in pool
        bubbleArray = new GameObject[bubbleCount];
        for (int i = 0; i < bubbleCount; i++)
        {
            bubbleArray[i] = Instantiate(bubblePrefab, GetComponent<Transform>());
        }

        // hardcode baseSpawnLocations
        // coordinates are relative to BubblePool
        baseSpawnLocations = new List<Vector2>(6);
        baseSpawnLocations.Add(new Vector2(27.98f, 36.88f));
        baseSpawnLocations.Add(new Vector2(35.76f, 36.88f));
        baseSpawnLocations.Add(new Vector2(43.37f, 36.88f));
        baseSpawnLocations.Add(new Vector2(27.98f, 28.87f));
        baseSpawnLocations.Add(new Vector2(35.76f, 28.79f));
        baseSpawnLocations.Add(new Vector2(43.45f, 28.87f));

        temp = new List<Vector2>(baseSpawnLocations);

        spawnBubbles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void chooseSpawnLocations()
    {
        // choose 2 locations to not spawn
        for (int i = 0; i < (6 - bubbleCount); i++)
        {
            int n = randomizer.Next(0, temp.Count);
            temp.RemoveAt(n);
        }

        for (int i = 0; i < temp.Count; i++)
        {
            temp[i] = addVariationtoLocation(temp[i]);
        }
    }

    Vector2 addVariationtoLocation(Vector2 location)
    {
        Vector2 epsilon = new Vector2(UnityEngine.Random.Range(-2.39f, 2.39f), UnityEngine.Random.Range(-1.4f, 1.4f));
        return location + epsilon;
    }

    void spawnBubbles()
    {
        chooseSpawnLocations();
        for (int i = 0; i < bubbleArray.Length; i++)
        {
            bubbleArray[i].transform.localPosition = temp[i];
        }
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
