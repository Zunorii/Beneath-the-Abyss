using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmushController : MonoBehaviour
{

    public int health = 1;
    public float speed = 5f;
    Rigidbody2D myRB;
    public float maxDistance = 10f;
    public bool startMovePos = true;

    Vector2 minPos;
    Vector2 maxPos;
    Vector2 origin;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

        origin = transform.position;
        
        maxPos = new Vector2(origin.x + maxDistance, origin.y);
        minPos = new Vector2(origin.x - maxDistance, origin.y);

        if (startMovePos)
            myRB.velocity = new Vector2(speed, 0);
        else
            myRB.velocity = new Vector2(-speed, 0);
    }


    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.x >= maxPos.x)
        {
            myRB.velocity = new Vector2(-speed, 0);
        }
        else if (transform.position.x <= minPos.x)
        {
            myRB.velocity = new Vector2(speed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attackBox")
        {
            health--;
        }
    }

}
