using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimationController : MonoBehaviour
{
    public GameObject spawnLoc1;
    public GameObject spawnLoc2;
    public GameObject spawnLoc3;
    private GameObject[] spawnLocations;
    public GameObject runSpawnLoc1;
    public GameObject runSpawnLoc2;
    private GameObject[] runSpawnLocations;
    public GameObject outOfBoundsBarrier1;
    public GameObject outOfBoundsBarrier2;
    public GameObject parent;
    public Animator animatingDino;
    SpriteRenderer spriteRenderer;

  
    private float timer = 0f;
    private const int POPUPANIMDONE = 1;
    private const int RUNANIM = 2;
    private const int RUNANIMDONE = 3;
    private const int IDLE = 0;
    [SerializeField]
    private int animState = 0;
    [SerializeField]
    private bool animating = false;
    private bool faceRight = true;
    private int runSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new GameObject[3];
        spawnLocations[0] = spawnLoc1;
        spawnLocations[1] = spawnLoc2;
        spawnLocations[2] = spawnLoc3;
        parent.transform.position = spawnLocations[0].transform.position;

        runSpawnLocations = new GameObject[2];
        runSpawnLocations[0] = runSpawnLoc1;
        runSpawnLocations[1] = runSpawnLoc2;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 2f && animating == false)
        {

            int randomLoc = (int)Random.Range(0, 3);
            parent.transform.position = spawnLocations[randomLoc].transform.position; // a parent is needed to move the game object around as animating the position directly is based on world coordinates, not local coordinates. 
            gameObject.transform.localPosition = new Vector2(0, 0); //needed to reset it back to the center of the parent gameObject, the animation can cause the dino to sink into the ground
            animating = true;
            animatingDino.SetBool("popUp", true);
        }



        if (animState == POPUPANIMDONE)
        {
            animatingDino.SetBool("popUp", false);
            animatingDino.SetBool("isRunning", true);

            int randomRunSpawnLoc = (int)Random.Range(0, 2);
            parent.transform.position = runSpawnLocations[randomRunSpawnLoc].transform.position;
            if (randomRunSpawnLoc == 0)
            {
                faceRight = true;
            }
            else
            {
                faceRight = false;
            }
            animState = RUNANIM;

        }
        else if (animState == RUNANIM)
        {
            Move();
        }

        else if (animState == RUNANIMDONE)
        {
            animatingDino.SetBool("isRunning", false);
            timer = 0f;

            animating = false;
            animState = IDLE;
        }




    }

    /**
     * use late update to apply any tranformations to the sprite renderer as the animations that affect the sprite renderer with transformations take priority and will override any changes made by script
     * have it flip the direction of the sprite based on direction it is going
     */
    private void LateUpdate()
    {

        if (parent.GetComponent<Rigidbody2D>().velocity.x == runSpeed)
        {
            spriteRenderer.flipX = false;
        }
        else if (parent.GetComponent<Rigidbody2D>().velocity.x == -runSpeed)
        {
            spriteRenderer.flipX = true;
        }
    }



    /**
     * custom collision function as the parent object has the box collider instead of the child.
     */
    private void MyCollisionDetection2D(Collider2D collider)
    {
        if (parent.GetComponent<BoxCollider2D>().IsTouching(collider))
        {
            RunAnimDone();
            Vector3 moveBack;
            if (faceRight)
            {
                moveBack = new Vector3(-5, 0, 0);
            }
            else
            {
                moveBack = new Vector3(5, 0, 0) * Time.deltaTime;
            }
            parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            parent.transform.position += moveBack * Time.deltaTime;
        }
    }

    public void PopUpAnimDone()
    {
        animState = POPUPANIMDONE;
    }

    public void RunAnimDone()
    {
        animState = RUNANIMDONE;

    }

    public void RunAnim()
    {
        animState = RUNANIM;
    }

    private void Move()
    {
        if (faceRight)
        {
            parent.GetComponent<Rigidbody2D>().velocity = Vector2.right * runSpeed;
            MyCollisionDetection2D(outOfBoundsBarrier1.GetComponent<BoxCollider2D>());
        }
        else
        {
            parent.GetComponent<Rigidbody2D>().velocity = Vector2.left * runSpeed;
            MyCollisionDetection2D(outOfBoundsBarrier2.GetComponent<BoxCollider2D>());
        }

    }

}
