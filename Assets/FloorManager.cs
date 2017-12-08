using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour {

    public static FloorManager instance;
    public GameObject floorPrefab;
    public Vector3 floorOriginalPosition;
    public float floorLength = 1f;

    public Sprite defaultSprite;
    public int defaultFloorNumberPerSide = 5;

    private List<FloorPiece> floorPieceList;
    private int currentSizePerSide = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(instance != this)
        {
            Destroy(this);
        }
        createFloor(defaultFloorNumberPerSide, defaultSprite);  // for debugging nia...............................to be removed
    }


    public void createFloor(int numberOfFloorPerSide, Sprite sprite)
    {
        createOneFloorPiece(floorOriginalPosition, sprite, 0);
        if (numberOfFloorPerSide > 0)
        {
            for (int n = 0; n < numberOfFloorPerSide; n++)
            {
                float xPositionOffset = floorOriginalPosition.x + floorLength * (n + 1);
                Vector3 newPositionRight = new Vector3(xPositionOffset, floorOriginalPosition.y, floorOriginalPosition.z);
                Vector3 newPositionLeft = newPositionRight * -1;
                createOneFloorPiece(newPositionRight, sprite, n + 1);
                createOneFloorPiece(newPositionLeft, sprite, -1 * (n+1));
            }
        }
    }

    private void createOneFloorPiece(Vector3 position, Sprite sprite, int rankIndex)
    {
        GameObject floor = Instantiate(floorPrefab, position, Quaternion.identity) as GameObject;
        setFloorMaterial(floor, sprite);
        floor.transform.parent = this.gameObject.transform;
        floor.GetComponent<FloorPiece>().setRankIndex(rankIndex);
        floorPieceList.Add(floor.GetComponent<FloorPiece>());
    }

    public void closeAllIndicators()
    {
        foreach(FloorPiece grid in floorPieceList)
        {
            grid.closeIndicator();
        }
    }

    public void openAllIndicators()
    {
        foreach (FloorPiece grid in floorPieceList)
        {
            grid.openIndicator();
        }
    }

    public void openSomeIndicators(params int[] rankIndexArray)
    {
        foreach(int rankIndex in rankIndexArray)
        {
            foreach(FloorPiece piece in floorPieceList)
            {
                if (piece.getRankIndex() == rankIndex)
                    piece.openIndicator();
            }
        }
    }

    private void setFloorMaterial(GameObject floorChosen, Sprite sprite)
    {
        floorChosen.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    
    // for debugging nia...............................to be removed
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            openAllIndicators();
        }

    }
    
}
