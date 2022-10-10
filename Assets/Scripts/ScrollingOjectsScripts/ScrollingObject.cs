using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void FixedUpdate()
    {
        Scroll();
    }

    protected virtual void SetUp()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    
    public virtual void Scroll()
    {
        if (GameController.Instance.IsGameOver() == false && GameController.Instance.IsPaused() == false)
        {
           
            rb.velocity = new Vector2(speed, 0);

        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
}
