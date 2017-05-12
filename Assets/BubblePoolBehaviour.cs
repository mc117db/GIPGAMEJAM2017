using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePoolBehaviour : MonoBehaviour {

    private static BubblePoolBehaviour instance;
    public GameObject prefab;
    public float timeBetweenBubbleWaves = 3f;
    public int noOfBubbleToSpawn;
    public int minX,maxX,minY,maxY;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        transform.position = Vector3.zero;
        BubbleBehaviour.OnBubblePop += delegate { StartCoroutine(ResetBubble()); };
        SpawnBubble();
    }
	// Use this for initialization
	void SpawnBubble()
    {
        for (int i = 0; i < noOfBubbleToSpawn; i++)
        {
            GameObject bubble = GameObjectUtil.Instantiate(prefab,new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0));
            bubble.transform.parent = transform;
        }
    }
    IEnumerator ResetBubble()
    {
        foreach (Transform child in transform)
        {
            GameObjectUtil.Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(timeBetweenBubbleWaves);
        SpawnBubble();
    }
}
