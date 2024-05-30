using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lateralspeed = 5f;

    private float horizontalInput;

    private float verticalInput;

    private float rotMin; 
    
    private float rotMax;

    private float mouseX;

    private float mouseY;

    public Transform target;
    public Transform player;


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        transform.Rotate(Vector3.up, lateralspeed * Time.deltaTime * horizontalInput);

    }

    /*
    public void Cam()
    {
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Math.Clamp(mouseY, rotMin, rotMax);
    }
    */
}
