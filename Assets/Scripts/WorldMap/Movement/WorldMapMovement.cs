using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapMovement : MonoBehaviour
{

    //Main values.
    private float horizontal;
    private float vertical;
    public float speed = 5f;
    public float gravity = -40f;
    public float jumpPower = 15f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask ground;

    //Additional settings values.
    public float normalSpeed = 5f;
    public float sprintSpeed = 10f;
    public bool canMove = true;
    private bool canJump = true;

    //random important values
    private Vector3 velocity = new Vector3(0,0,0);
    private bool isGrounded; 
    
    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            canJump = true;
        }

        if(Input.GetButtonDown("Jump") && canJump)
        {
            velocity.y = jumpPower;
            canJump = false;
        }

        //Get the input of the player.
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        //Start sprint
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        //Stop sprint
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }

        //Do the actual movement.
        transform.Translate(new Vector3(horizontal,0,vertical) * speed * Time.deltaTime);

        //Do gravity
        if(canMove)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        transform.Translate(velocity * Time.deltaTime);

    }
}
