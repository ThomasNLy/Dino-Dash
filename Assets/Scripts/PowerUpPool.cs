using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPool : ObjectPoolSpawn
{
    // Start is called before the first frame update
    
    void Start()
    {
        numOfObjects = 3;
        spawnRate = 10;
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObjects(); 
    }

    public override void SpawnObjects()
    {
        if (spawnIndex >= objects.Length)
        {
            spawnIndex = 0;
        }

        if (objects[spawnIndex].transform.position.x <= outOfBoundsBarrier.transform.position.x && spawnTimer > spawnRate)
        {
            
            float randomY = Random.Range(spawnLoc.transform.position.y - 1, spawnLoc.transform.position.y + 5);
            objects[spawnIndex].transform.position = new Vector2(spawnLoc.transform.position.x, randomY);
            spawnTimer = 0;
            spawnRate = Random.Range(8, 20);
        }
        spawnIndex++;
        spawnTimer += Time.deltaTime;
    }
}
