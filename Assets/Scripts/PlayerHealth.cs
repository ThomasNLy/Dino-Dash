using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    bool alive = true;
    // Start is called before the first frame update
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            alive = false;
            GameController.Instance.GameOver();
        }
    }

}
