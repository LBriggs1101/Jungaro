using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLevelComplete : MonoBehaviour
{
    public GameObject levelCompleteScreen;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            levelCompleteScreen.SetActive(true);
        }
    }
}
