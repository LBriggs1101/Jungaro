using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerActivatePopUp : MonoBehaviour
{

    public GameObject popUp;
    public GameObject lockedPopUp;
    public bool isUnlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(isUnlocked)
            {
                popUp.SetActive(true);
            }
            else
            {
                lockedPopUp.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            popUp.SetActive(false);
            lockedPopUp.SetActive(false);
        }
    }
}
