using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement and such
    public float runSpeed = 20f;
    float horizontalMove = 0f;
    public float jumpForce = 1700f;
    int jumpCount = 2;
    public float dashForce = 800f;
    //health variable
    public int health = 1;
    //gameobjects and rigidbody
    public GameObject upAttackBox;
    public GameObject rightAttackBox;
    public GameObject leftAttackBox;
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    //player position
    public Vector3 playerPos;
    

    // Start is called before the first frame update
    void Start()
    {
        //Gets gameManager and the players rigidbody
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the players position
        playerPos = transform.position;
        //horizontal input
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
            gameManager.StartCoroutine("Death");
        }
        //attacks
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upAttackBox.SetActive(true);
            StartCoroutine("WaitForRetract", upAttackBox);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftAttackBox.SetActive(true);
            StartCoroutine("WaitForRetract", leftAttackBox);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightAttackBox.SetActive(true);
            StartCoroutine("WaitForRetract", rightAttackBox);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 2;

        if (collision.gameObject.tag == "Spikes")
        {
            health--;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
        if (collision.gameObject.tag == "Explosion")
        {
            health--;
        }
    }
    
    public IEnumerator WaitForRetract(GameObject attackBox)
    {
        yield return new WaitForSeconds(.1f);
        attackBox.SetActive(false);
    }

}

