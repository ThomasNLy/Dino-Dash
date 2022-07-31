using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObstacle : ScrollingObject
{
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

   


    private void FixedUpdate()
    {
        speed = GameController.Instance.GetScrollSpeed();
        Scroll();
    }
}
