using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWorldMapPlayer : MonoBehaviour
{
    public Vector3 respawnPoint;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = respawnPoint;
        }    
    }
}
