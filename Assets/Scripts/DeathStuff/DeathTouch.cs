using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : MonoBehaviour
{

    public DeathManager deathManager;

    private void Awake() 
    {
        deathManager = GameObject.Find("DeathManager").GetComponent<DeathManager>();    
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("wow");
        if(other.gameObject.tag == "Player")
        {
            deathManager.death();
        }
    }
}
