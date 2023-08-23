using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Implimenting a jump function for practice
        
        if (Input.GetButtonDown("Jump") && isGrounded()) 
        { 
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            Debug.Log("jump");
        }
        /*
        // Impliment a directional walk movement connected to WASD
        if (Input.GetKey("w")) 
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movementSpeed);
            //Debug.Log("move up");
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -movementSpeed);
            //Debug.Log("move down");
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector3(movementSpeed, rb.velocity.y, rb.velocity.z);
            //Debug.Log("jump");
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector3(-movementSpeed, rb.velocity.y, rb.velocity.y);
            //Debug.Log("jump");
        }
         */
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
     
    }
    
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    
}
