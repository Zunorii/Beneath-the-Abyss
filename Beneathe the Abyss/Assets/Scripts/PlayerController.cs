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
    public bool isMoving = false;
    public Vector3 lastPos;
    //health variable
    public int health = 1;
    //gameobjects and rigidbody
    public GameObject upAttackBox;
    public GameObject rightAttackBox;
    public GameObject leftAttackBox;
    private Rigidbody2D playerRb;
    private Animator anim;
    private GameManager gameManager;
    //player position
    public Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        //Gets gameManager and the players rigidbody
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the players position
        playerPos = transform.position;
        //horizontal input
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        transform.Translate(Vector2.right * horizontalMove * Time.deltaTime);
        //Jump/Double Jump
        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount--;
        }
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerRb.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right * dashForce, ForceMode2D.Impulse);

        }
        //Death
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

        if (playerPos != lastPos)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(lastPos.x <= playerPos.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(lastPos.x > playerPos.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        lastPos = playerPos;
        //anim.SetBool("isMoving", isMoving);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "EndLevel")
        {
            gameManager.MainMenu();
        }
        if (collision.gameObject.tag == "ground")
        {
            jumpCount = 2;
        }
    }

}

