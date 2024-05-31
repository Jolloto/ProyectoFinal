using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";
    private const string COIN_TAG = "Coin";

    public float speed = 5f;
    public float jumpForce = 10f;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI coinsText;
    public GameObject winPanel;

    private int coinsCollected = 0;
    private Rigidbody rb;
    private bool isGrounded;

    [SerializeField] private Animator Corre;
    private bool isruning;

          

void Start()
    {

        rb = GetComponent<Rigidbody>();
        UpdateUI();
        isruning = false;
        Corre.SetBool("Corre", isruning) ; 

    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (moveVertical < -0.1f || moveVertical > 0.1f)
        {
            isruning = true;
            Corre.SetBool("Corre", isruning);
        }
        else
        {

            isruning = false;
            Corre.SetBool("Corre", isruning);
        }
    }

    void Rotate()
    {
        float turn = Input.GetAxis("Mouse X");
        transform.Rotate(0, turn, 0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        Vector3 playerPosition = transform.position;
        print("COLISION ENTRA");
        print(playerPosition);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            if(playerPosition.y < 2)
            {
                LoseLife();
                Respawn();
            }
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(COIN_TAG))
        {
            coinsCollected++;
            print("Coin colected trigger");
            UpdateUI();
            Destroy(collision.gameObject);
            // Play particle system (Implement your particle system logic here)
            // Check win condition
            if (coinsCollected >= 20)
            {
                WinGame();
            }
        }
    }

    void LoseLife()
    {
        lives--;
        //UpdateUI();
        if (lives <= 0)
        {
            print("No lives trigger:");
            GameOver();
        }
        print(lives);
    }

    void Respawn()
    {
        transform.position = new Vector3(0, 25, 7.7f); // Change to your respawn point
        rb.velocity = Vector3.zero;
    }

    void UpdateUI()
    {
        livesText.text = "Lives: " + lives;
        coinsText.text = "Coins: " + coinsCollected;
    }

    void GameOver()
    {
        print("Dead Trigger");
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 0f; // Stop the game
    }

    void WinGame()
    {
        SceneManager.LoadScene("WinPanel");
        Time.timeScale = 0f; // Stop the game
        // Play sound effect (Implement your sound effect logic here)
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
