using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimationController : MonoBehaviour
{
    public GameObject spawnLoc1;
    public GameObject spawnLoc2;
    public GameObject spawnLoc3;
    public GameObject dino;
    GameObject [] spawnLocations;
    float timer = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new GameObject[3];
        spawnLocations[0] = spawnLoc1;
        spawnLocations[1] = spawnLoc2;
        spawnLocations[2] = spawnLoc3;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            int randomLoc = (int)Random.Range(0, 3);
            dino.transform.position = new Vector2(spawnLocations[randomLoc].transform.position.x, spawnLocations[randomLoc].transform.position.y);
            timer = 0f;
        }
    }
}
