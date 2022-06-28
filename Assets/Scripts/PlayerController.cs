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

        if (doubleJumpScript.IsJumping())
        {
            Debug.Log("jumping");
            attackPowerUpScript.SetAttacking(false);
            animator.SetBool("isJumping", true);

        }
        //else 
        //{
        //    animator.SetBool("isJumping", false);
        //}
        if (attackPowerUpScript.IsAttacking())
        {
            doubleJumpScript.SetJumping(false);
            animator.SetBool("isAttacking", true);
            animator.SetBool("isJumping", false);

        }
        else 
        {
            animator.SetBool("isAttacking", false);
        }
        
        
    }
}
