using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimationController : MonoBehaviour
{
    public GameObject spawnLoc1;
    public GameObject spawnLoc2;
    public GameObject spawnLoc3;
    public GameObject runSpawnLoc;
    public GameObject outOfBounds;
    public GameObject parent;
    public Animator animatingDino;
    GameObject[] spawnLocations;
    float timer = 0f;
    private const int POPUPANIMDONE = 1;
    private const int RUNANIM = 2;
    private const int RUNANIMDONE = 3;
    private const int IDLE = 0;
    [SerializeField]
    private int animState = 0;
    [SerializeField]
    bool animating = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new GameObject[3];
        spawnLocations[0] = spawnLoc1;
        spawnLocations[1] = spawnLoc2;
        spawnLocations[2] = spawnLoc3;
        parent.transform.position = spawnLocations[0].transform.position; 

    }

    // Update is called once per frame
    void Update()
    {
       
        timer += Time.deltaTime;
        if (timer > 10f && animating == false)
        {
            Debug.Log("random spawn");
            int randomLoc = (int)Random.Range(0, 3);
            parent.transform.position =  spawnLocations[randomLoc].transform.position; // a parent is needed to move the game object around as animating the position directly is based on world coordinates, not local coordinates. 
            gameObject.transform.localPosition = new Vector2(0, 0); //needed to reset it back to the center of the parent gameObject, the animation can cause the dino to sink into the ground
            animating = true;
            animatingDino.SetBool("popUp", true);
        }

       

        if (animState == POPUPANIMDONE)
        {
            animatingDino.SetBool("popUp", false);
            animatingDino.SetBool("isRunning", true);
            Debug.Log("Pop up done");
            parent.transform.position = runSpawnLoc.transform.position;
            animState = RUNANIM;

        }
        else if (animState == RUNANIM)
        {
            parent.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            
        }

        else if (animState == RUNANIMDONE)
        {
            animatingDino.SetBool("isRunning", false);
            timer = 0f;
            Debug.Log("run done");
            parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            animating = false;
            animState = IDLE;
        }

        MyCollisionDetection2D(outOfBounds.GetComponent<BoxCollider2D>());


    }



    private void MyCollisionDetection2D(Collider2D collider)
    {
        if (parent.GetComponent<BoxCollider2D>().IsTouching(collider))
        {
            RunAnimDone();
            parent.transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
        }
    }

    public void PopUpAnimDone()
    {
        animState = POPUPANIMDONE;
    }

    public void RunAnimDone()
    {
        animState = RUNANIMDONE;
        Debug.Log("done running");
    }

    public void RunAnim()
    {
        animState = RUNANIM;
    }

}
