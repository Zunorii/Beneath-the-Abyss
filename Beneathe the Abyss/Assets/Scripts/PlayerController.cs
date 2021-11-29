using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed = 20f;
    float horizontalMove = 0f;
    public float jumpForce = 1700f;
    int jumpCount = 2;
    public float dashForce = 800f;
    public int health = 1;
    public GameObject attackBox;
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        transform.Translate(Vector2.right * horizontalMove * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount--;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerRb.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right * dashForce, ForceMode2D.Impulse);

        }

        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.StartCoroutine("Restart");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 2;

        if (collision.gameObject.tag == "Spikes")
        {
            health--;
        }
    }
}

