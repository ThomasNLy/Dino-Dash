using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   
    protected GameObject [] objects;
    protected int numOfObjects = 6;
    public GameObject prefab;
    public GameObject spawnLoc;
    public GameObject outOfBoundsBarrier;
    protected int spawnIndex = 0;
    protected float spawnTimer = 0;
    public float spawnRate = 3;
    public float spawnRateMin = 1;
    public float spawnRateMax = 10;
    // Start is called before the first frame update
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
     * setupFunction is created as needed for inheritance as a parent class
     */
    public void SetUp()
    {
        outOfBoundsBarrier = GameController.Instance.outOfBoundsBarrier;
        spawnLoc = GameController.Instance.spawnLoc;

        objects = new GameObject[numOfObjects];
        for (int i = 0; i < numOfObjects; i++)
        {
            objects[i] = Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
    //need to add virtual so it can be inherited from 
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
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

        spawnIndex++;
        spawnTimer += Time.deltaTime;
    }
}


