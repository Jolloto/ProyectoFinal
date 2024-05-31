using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    [SerializeField] private Animator animatorJugador;
    private bool Corre = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animatorJugador.SetBool("Corre", Corre); 
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);



        rb.AddForce(movement * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        print(isGrounded);
    }

    void OnCollisionEnter(Collision collision)
    {
        print("colision entra");
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }
}