using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    [SerializeField] private float lateralspeed = 10f;

    private float horizontalInput;

    private float verticalInput;
    
    private Rigidbody playerRigidbody; // = null

    private float forceMagnitude = 200f;

    private bool isOnTheGround;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        transform.Rotate(Vector3.up, lateralspeed * Time.deltaTime * horizontalInput);


         if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            Jump();
        }      
    }

    private void Jump()
    {
        playerRigidbody.AddForce(Vector3.up * forceMagnitude, ForceMode.Impulse);
        isOnTheGround = false;
    }
}
