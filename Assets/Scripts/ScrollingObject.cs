using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.IsGameOver() == false)
        {
            rb.velocity = new Vector2(-2, 0);
        }
        else 
        {
            rb.velocity = Vector2.zero;
        }
           
    }
}