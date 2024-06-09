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
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateUI();
    }

    void Update()
    {
        Move();
        Jump();
        Rotate();
        
    }

    void Move()     //  El jugador se mueve en ambas direcciones en una velocidad
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void Rotate()
    {
        float turn = Input.GetAxis("Mouse X");
        transform.Rotate(0, turn, 0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)      // Al pulsar espacio el jugador salta con cierta fuerza
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
        if (collision.gameObject.CompareTag("Enemy"))       // Si el jugador colisiona con un enemigo se llama a la funcion LoseLife
        {
            LoseLife();
        }
        if (collision.gameObject.CompareTag(GROUND_TAG))    // Si el jugador colisiona con el suelo se llama a la funciones Respawn y LoseLife
        {
            if(playerPosition.y < 2)
            {
                LoseLife();
                Respawn();
            }
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(COIN_TAG))      // Cuando el jugador colisiona con una moneda se destruye y se le suma una moneda al llegar a 20 Ganas
        {
            coinsCollected++;
            print("Coin colected trigger");
            UpdateUI();
            Destroy(collision.gameObject);
            
            if (coinsCollected >= 20)
            {
                WinGame();
            }
        }
    }

    void LoseLife()     //Sistema de vidas si las pierdes Game Over
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
        transform.position = new Vector3(0, 25, 7.7f); // Punto de Respawn
        rb.velocity = Vector3.zero;
    }

    void UpdateUI()     //Texto muestra vidas y vidas
    {
        livesText.text = "Lives: " + lives;
        coinsText.text = "Coins: " + coinsCollected;
    }

    void GameOver()     //Muestra el panel Game Over al morir
    {
        print("Dead Trigger");
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 0f; // Para el juego
    }

    void WinGame()      //Muestra el panel Win al morir
    
    {
        SceneManager.LoadScene("WinPanel");
        Time.timeScale = 0f; // Para el juego
        // Play sound effect (Implement your sound effect logic here)
    }

    public void RestartGame()       //Funcion que hace que vuelva a empezar el juego 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");     //Carga la es escena del juego
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");      //Carga la es escena del MainMenu
    }
}
