using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    bool jumping = false;
    [SerializeField]
    float jumpForce = 14.5f;
    [SerializeField]
    int maxJumps = 2;
    [SerializeField]
    int numJumps;
    [SerializeField]
    float gravityJumping = 1.25f;
    [SerializeField]
    int gravityFalling = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        numJumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.IsGameOver() == false && GameController.Instance.IsPaused() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                jumping = true;
            }
            if (rb2d.velocity.y > 0)
            {
                rb2d.gravityScale = gravityJumping;

            }
            else if (rb2d.velocity.y < 0)
            {
                rb2d.gravityScale = gravityFalling;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (jumping && numJumps > 0)
        {
            Jump();
            jumping = false;
            numJumps--;
        }
    }

    void Jump()
    {

        rb2d.velocity = new Vector2(0, jumpForce);
        
       
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            numJumps = maxJumps;
        }
    }
}
