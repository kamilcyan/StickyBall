using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float runSpeed, jumpForce;
    [Range (0,1)]
    private float jumpHeight = 0.4f;
    private float moveInput;

    public float health = 100;
    private Rigidbody2D myBody;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Vector3 range;
    public Slider slider;
    public int coinCounter = 0;
    public Text text;
    public GameManager manager;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (slider.value > health)
        {
            slider.value -= 0.25f;
        }
        else
        {
            slider.value += 0.25f;
        }

        if(health < 1 || transform.position.y < -10)
        {
            StartCoroutine(PlayersDeath());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            manager.MainMenu();
        }

        Movement();
        CheckCollisionForJumping();
    }

    IEnumerator PlayersDeath()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Movement()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        myBody.velocity = new Vector2(moveInput, myBody.velocity.y);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(myBody.velocity.y > 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y * jumpHeight);
            }

        }
    }
    void CheckCollisionForJumping()
    {
        Collider2D bottomHit = Physics2D.OverlapBox(groundCheck.position, range, 0, groundLayer);

        if(bottomHit != null)
        {
            if(bottomHit.gameObject.tag == "Ground" && Input.GetKeyDown(KeyCode.Space))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(groundCheck.position, range);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Spike")
        {
            TakeDamage(20);
        }

        if(other.tag == "HealthPotion")
        {
            Destroy(other.gameObject);
            health += 30;
        }

        if(other.tag == "Coin")
        {
            Destroy(other.gameObject); 
            coinCounter++;
            text.text = "X" + coinCounter.ToString();
        }

        if (other.tag == "FinishSpot")
        {
            if(coinCounter == 12)
            {
                Destroy(other.gameObject);
                StartCoroutine(FinishGame());
            }
        }
    }

    void TakeDamage(int damage)
    {
        FindObjectOfType<CameraScript>().ShakeIt();
        health -= damage;
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
