using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteScrollingFloor : ScrollingScenery
{

    int tileMapSize;
    public GameObject otherFloor;
    int otherTileMapSize;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        otherTileMapSize = otherFloor.transform.GetChild(0).GetComponent<Tilemap>().size.x;
        tileMapSize = gameObject.transform.GetChild(0).GetComponent<Tilemap>().size.x;
        scrollSpeed = GameController.Instance.GetScrollSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        scrollSpeed = GameController.Instance.GetScrollSpeed();
        Scroll();
        
    }


    public override void wrapAround()
    {
        if (gameObject.transform.position.x + tileMapSize <= -9.5)
        {
            gameObject.transform.position = new Vector3(otherFloor.transform.position.x + otherTileMapSize - 1, otherFloor.transform.position.y);
        }
    }
}
