using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScottCamera : MonoBehaviour
{
    public float sensitivity;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        turn.x = Input.GetAxis("Mouse X");
        turn.y = Input.GetAxis("Mouse Y");

        if (turn.x != 0 || turn.y != 0) {

            rotationy.y += turn.y * sensitivity * Time.deltaTime;
            rotationy.x += turn.x * sensitivity * Time.deltaTime;

            rotationy.y = Mathf.Clamp(rotationy.y, -35, 25);

            transform.Rotate(Vector3.up * turn.x * sensitivity * Time.deltaTime);

            transform.GetChild(0).rotation = Quaternion.Euler(rotation.y * -1, rotationy.x, transform.GetChild(0).rotation.z);
        }
        
    }
}
