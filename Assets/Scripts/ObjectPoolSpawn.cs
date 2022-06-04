using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject [] objects;
    int numOfObjects = 6;
    public GameObject prefab;
    public GameObject spawnLoc;
    public GameObject outOfBoundsBarrier;
    int spawnIndex = 0;
    float spawnTimer = 0;
    void Start()
    {
        outOfBoundsBarrier = GameObject.Find("OutOfBoundsBarrier");
        spawnLoc = GameObject.FindGameObjectWithTag("SpawnLoc");
        
        objects = new GameObject[numOfObjects];
        for (int i = 0; i < numOfObjects; i++)
        {
            objects[i] = Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (spawnIndex >= objects.Length)
        {
            spawnIndex = 0;
           
        }
  
        if (spawnTimer > 3 && objects[spawnIndex].transform.position.x <= outOfBoundsBarrier.transform.position.x)
        {
         
            objects[spawnIndex].transform.position = spawnLoc.transform.position;
            spawnTimer = 0;
        }

        spawnIndex++;
        spawnTimer += Time.deltaTime;

    }
}
