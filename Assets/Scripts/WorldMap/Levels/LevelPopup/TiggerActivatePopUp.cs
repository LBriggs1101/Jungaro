using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerActivatePopUp : MonoBehaviour
{

    public GameObject popUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            popUp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            popUp.SetActive(false);
        }
    }
}
