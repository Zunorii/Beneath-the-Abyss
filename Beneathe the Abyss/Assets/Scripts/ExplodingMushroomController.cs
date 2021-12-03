using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingMushroomController : MonoBehaviour
{
    private Collider2D trigger;
    private SpriteRenderer sprite;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<CircleCollider2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       trigger.enabled = true;
       sprite.enabled = false;
       Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
}
