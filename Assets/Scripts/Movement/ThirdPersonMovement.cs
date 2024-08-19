using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform player;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.6f;
    public LayerMask ground;
    public static bool isGrounded;
    bool isRunning = false;
    bool canMove = true;
    bool canCoyoteTime;
    bool isCoyoteRunning = false;
    bool canJump;
    public AudioSource WalkSound;

    public float speed = 6f;
    public float normalSpeed = 8f;
    public float runSpeed = 12f;
    public float originalGravity = -40f;
    public float gravity = -40f;
    public float jumpPower = 15;
    private Vector3 tempVelo;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public CinemachineFreeLook vcam;
    float originalFov;
    public float newFov = 60;

    public float tempSpeed = 0;
    public bool hasFinishedAccelerating = false;
    public float accelerationAmount = 10;
    public float decelerationAmount = 20;
    public Vector3 moveDir = new Vector3(0,0,0);
    public bool hasFinishedDecelerating = true;
    
    private void Start() 
    {
        vcam.m_CommonLens = true;
        originalFov = vcam.m_Lens.FieldOfView;
    }
    
    //Get the angle of target object.
    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) 
	{
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) 
		{
			return 1f;
		} 
		else if (dir < 0f) 
		{
			return -1f;
		}
		else 
		{
			return 0f;
		}
	}

    private IEnumerator coyoteTimeStuff()
    {
        isCoyoteRunning = true;
        yield return new WaitForSecondsRealtime(1f);
        canCoyoteTime = false;
        isCoyoteRunning = false;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        if((!isGrounded && canCoyoteTime))
        {
            canJump = true;
            if(!isCoyoteRunning)
            {
                StartCoroutine(coyoteTimeStuff());
            }
        }
        else if(!isGrounded && !canCoyoteTime)
        {
            canJump = false;
        }

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            canCoyoteTime = true;
            canJump = true;
        }

        //Start running when shift is pressed.
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
            hasFinishedAccelerating = false;
        }
        //Stop running when shift is let go.
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
            isRunning = false;
        }

        //Jump
        if(Input.GetButtonDown("Jump") && canJump && canMove)
        {
            isGrounded = false;
            canJump = false;
            canCoyoteTime = false;
            velocity.y = jumpPower;
            gravity = originalGravity;
        }

        if(isGrounded && isRunning)
        {
            WalkSound.Play();
        } else
        {
            WalkSound.Pause();
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(tempSpeed < speed && !hasFinishedAccelerating && (horizontal != 0 || vertical != 0))
        {
            hasFinishedDecelerating = false;
            if(tempSpeed + accelerationAmount * Time.deltaTime >= speed)
            {
                tempSpeed = speed;
                hasFinishedAccelerating = true;
            }
            else
            {
                tempSpeed += accelerationAmount * Time.deltaTime;
            }
                    
        }
        else if(!isRunning && tempSpeed > speed)
        {
            if(tempSpeed - decelerationAmount * Time.deltaTime <= speed)
            {
                hasFinishedAccelerating = false;
                hasFinishedDecelerating = true;
                tempSpeed = speed;
            }
            else
            {
                tempSpeed -= decelerationAmount * Time.deltaTime;
                hasFinishedAccelerating = false;
            }
        }
        else if(horizontal == 0 && vertical == 0 && speed > 0)
        {
            if(tempSpeed - decelerationAmount * Time.deltaTime <= 0)
            {
                hasFinishedAccelerating = false;
                hasFinishedDecelerating = true;
                tempSpeed = 0;
            }
            else
            {
                tempSpeed -= decelerationAmount * Time.deltaTime;
                hasFinishedAccelerating = false;
            }
            
        }

        if((direction.magnitude >= 0.1f || !hasFinishedDecelerating) && canMove ) //If the the player has any of the non jump movement buttons pressed then do the movment math.
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime * (1 / Time.timeScale));
            

            if(direction.magnitude >= 0.1f)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;   
            }
            if(Time.timeScale != 1 && Time.timeScale != 0)
            {
                controller.Move(moveDir.normalized * tempSpeed * Time.deltaTime * (1 / Time.timeScale));
            }
            else
            {
                controller.Move(moveDir.normalized * tempSpeed * Time.deltaTime);
            }
                
            
            
        }
        
        if(canMove)
        {
            if(Time.timeScale != 1 && Time.timeScale != 0)
            {
                //Gravity.
                velocity.y += gravity * Time.deltaTime * (1 / Time.timeScale);
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
            }
            
            if(Time.timeScale != 1 && Time.timeScale != 0)
            {
                //Do the vertical movement.
                controller.Move(velocity * Time.deltaTime * (1 / Time.timeScale));
            }
            else
            {
                controller.Move(velocity * Time.deltaTime);
            }
            
        }
    }

    //Disable and enable the controller to allow for the position of the controller to be updated because character controller is weird :(
    public void setNewPosition()
    {
        controller.enabled = false;
        controller.enabled = true;
    }


}
