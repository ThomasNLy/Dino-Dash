using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUp : MonoBehaviour
{
    public GameObject outOfBoundsBarrier;
    public Animator animator;
    [SerializeField]
    private float timer = 0;
    [SerializeField]
    private float timeLimit;
    [SerializeField]
    bool attacking = false;
    GameObject child;
 
    private void Awake()
    {
        timeLimit = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        outOfBoundsBarrier = GameController.Instance.outOfBoundsBarrier;
        child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        if (attacking)
        {
            child.SetActive(true);
            if (timer > timeLimit)
            {
                child.SetActive(false);
                attacking = false;
                // animator.SetBool("isAttacking", attacking);
                timer = 0f;
            }
            timer += Time.deltaTime;
        }
        else 
        {
            child.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pillar")
        {
            collision.transform.position = outOfBoundsBarrier.transform.position;
        }
    }

    public void SetAttacking(bool b)
    {
        attacking = b;
    }
    public bool IsAttacking()
    {
        return attacking;
    }
}
