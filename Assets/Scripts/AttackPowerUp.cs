using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUp : MonoBehaviour
{
    public GameObject outOfBoundsBarrier;
    [SerializeField]
    private float timer = 0;
    [SerializeField]
    private float timeLimit = 3;
    [SerializeField]
    bool attacking = false;
    GameObject child;
    // Start is called before the first frame update
    void Start()
    {

        child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            if (timer > timeLimit)
            {
                child.SetActive(false);
                attacking = false;
                timer = 0;
            }
            timer += Time.deltaTime;
        }
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("f");
            child.SetActive(true);
            attacking = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pillar")
        {
            collision.transform.position = outOfBoundsBarrier.transform.position;
        }
    }
}
