using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapMovement : MonoBehaviour
{

    //Main values.
    private float horizontal;
    private float vertical;
    public float speed = 5f;

    //Additional settings values.
    public float normalSpeed = 5f;
    public float sprintSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
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
        transform.position = new Vector3(horizontal,0,vertical) * speed * Time.deltaTime;
    }
}
