using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DoubleJump doubleJumpScript;
    AttackPowerUp attackPowerUpScript;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       doubleJumpScript = this.gameObject.GetComponent<DoubleJump>();
        attackPowerUpScript = this.gameObject.GetComponent<AttackPowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.IsGameOver() == false && GameController.Instance.IsPaused() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                doubleJumpScript.SetJumping(true);
                attackPowerUpScript.SetAttacking(false);
                animator.SetBool("isJumping", true);
                animator.SetBool("isAttacking", false);
                
            }

            if (Input.GetKeyDown(KeyCode.F) && GameController.Instance.GetPowerUpPoints() >= 10)
            {
                
                attackPowerUpScript.SetAttacking(true);
                animator.SetBool("isAttacking", true);
                animator.SetBool("isJumping", false);
                GameController.Instance.ResetPowerUpPoints();
                
            }
        }
       
        if(!attackPowerUpScript.IsAttacking()) 
        {
            animator.SetBool("isAttacking", false);
        }
        
        
    }
}
