using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScottCamera : MonoBehaviour
{
    public float sensitivity;
    public Quaternion rotationy = Quaternion.identity;
    public Vector2 turn;


    void Update()
    {

        //Gets horizontal and vertical axis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        //Gets mouse input for camera
        turn.x = Input.GetAxis("Mouse X");
        turn.y = Input.GetAxis("Mouse Y");

        //Rotation for player and camera
        if (turn.x != 0 || turn.y != 0) 
        {
            //Calculates amount of turn needed
            rotationy.y += turn.y * sensitivity * Time.deltaTime;
            rotationy.x += turn.x * sensitivity * Time.deltaTime;

            //Prevents camera overcorrecting
            rotationy.y = Mathf.Clamp(rotationy.y, -35, 25);

            //Rotates player accordingly
            transform.Rotate(Vector3.up * turn.x * sensitivity * Time.deltaTime);

            //Rotate camera to match mouse
            transform.GetChild(0).rotation = Quaternion.Euler(rotationy.y * -1, rotationy.x, transform.GetChild(0).rotation.z);
        }
        
    }
}
