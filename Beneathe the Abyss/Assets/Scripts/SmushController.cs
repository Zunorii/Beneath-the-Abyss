using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmushController : MonoBehaviour
{

    public int health = 1;
    public float speed = 5f;
    Rigidbody2D myRB;
    public float maxDistance = 10f;

    Vector2 minPos;
    Vector2 maxPos;
    Vector2 origin;

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
