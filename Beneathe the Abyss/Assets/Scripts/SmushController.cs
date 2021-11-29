using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmushController : MonoBehaviour
{

    public int health = 1;
    public float speed = 5f;
    Rigidbody2D myRB;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }

        

    }
}
