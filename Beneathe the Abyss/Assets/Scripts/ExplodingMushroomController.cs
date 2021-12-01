using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingMushroomController : MonoBehaviour
{
    private Collider2D trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       trigger.enabled = true; 
    }
}
