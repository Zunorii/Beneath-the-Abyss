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

    private Rigidbody2D playerRb;
    

    // Start is called before the first frame update
    void Start()
    {
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 2;
    }

}

