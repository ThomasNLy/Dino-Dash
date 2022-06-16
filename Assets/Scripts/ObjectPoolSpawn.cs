using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameObject [] objects;
    protected int numOfObjects = 6;
    public GameObject prefab;
    public GameObject spawnLoc;
    public GameObject outOfBoundsBarrier;
    protected int spawnIndex = 0;
    protected float spawnTimer = 0;
    public float spawnRate = 3;
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObjects();
    }

    /**
     * needed for inheritance as a parent class
     */
    public void SetUp()
    {
        outOfBoundsBarrier = GameObject.Find("OutOfBoundsBarrier");
        spawnLoc = GameObject.FindGameObjectWithTag("SpawnLoc");

        objects = new GameObject[numOfObjects];
        for (int i = 0; i < numOfObjects; i++)
        {
            objects[i] = Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
    public virtual void SpawnObjects()
    {
        if (spawnIndex >= objects.Length)
        {
            spawnIndex = 0;

        }

        if (spawnTimer > spawnRate && objects[spawnIndex].transform.position.x <= outOfBoundsBarrier.transform.position.x)
        {

            objects[spawnIndex].transform.position = spawnLoc.transform.position;
            spawnTimer = 0;
        }

        spawnIndex++;
        spawnTimer += Time.deltaTime;
    }
}


