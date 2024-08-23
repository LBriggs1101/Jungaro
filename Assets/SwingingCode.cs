using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingCode : MonoBehaviour
{
    

    [Header("References")]
    public LineRenderer lr; //Line Renderer Variable
    public Transform gunTip, cam, player;
    public LayerMask whatIsGrappleable;

    [Header("Swinging")]
    private float maxSwingDistance = 25f;
    private Vector3 swingPoint;
    private SpringJoint joint;
    private Vector3 currentGrapplePosition; 

    [Header("Input")]
    public KeyCode swingKey = KeyCode.Mouse0; //Decides swing key (LMB for now)

    private void StartSwing()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxSwingDistance, whatIsGrappleable))
        {
            swingPoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = swingPoint;

            float distanceFromPoint = Vector3.Distance(player.position, swingPoint);

            //the distance grapple will try to keep from grapple point
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //customize these these are like joint physics bullshit
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    void StopSwing()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        //if not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, swingPoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, swingPoint);
    }

    void Update()
    {
        if (Input.GetKeyDown(swingKey)) StartSwing(); //If key down, swing
        if (Input.GetKeyUp(swingKey)) StopSwing(); //If key unpressed, don't swing
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        DrawRope();
    }

}


