using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPool : ObjectPoolSpawn
{
    // Start is called before the first frame update
    
    void Start()
    {
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
            
            float randomY = Random.Range(spawnLoc.transform.position.y, spawnLoc.transform.position.y + 7);
            objects[spawnIndex].transform.position = new Vector2(spawnLoc.transform.position.x, randomY);
            spawnTimer = 0;
        }
        spawnIndex++;
        spawnTimer += Time.deltaTime;
    }
}
