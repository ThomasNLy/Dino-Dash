using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrollingScenery : MonoBehaviour
{
    [SerializeField]
    protected float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
       
        scrollSpeed = -3.25f;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
           
    }

    public void Scroll()
    {
        if (GameController.Instance.IsGameOver() == false && GameController.Instance.IsPaused() == false)
        {
            gameObject.transform.Translate(new Vector3(scrollSpeed, 0) * Time.deltaTime);
            wrapAround();
        }
        else
        {
            gameObject.transform.Translate(new Vector3(0, 0));
        }
    }

    public  virtual void wrapAround()
    {
        if (gameObject.transform.position.x <= GameController.Instance.outOfBoundsBarrier.transform.position.x)
        {
            gameObject.transform.position = new Vector3(GameController.Instance.spawnLoc.transform.position.x, GameController.Instance.spawnLoc.transform.position.y);
        }
    }
}
