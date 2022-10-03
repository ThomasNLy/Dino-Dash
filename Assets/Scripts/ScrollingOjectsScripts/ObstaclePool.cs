using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : ObjectPool
{
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        spawnRateMax = GameController.Instance.GetObstacleSpawnRate();
    }

    // Update is called once per frame
    void Update()
    {
        
        SpawnObjects();
    }
}
