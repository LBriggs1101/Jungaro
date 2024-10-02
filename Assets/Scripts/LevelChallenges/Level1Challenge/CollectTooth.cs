using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTooth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("LevelChallengeManager").GetComponent<Level1Challenge>().collectTooth();
            GameObject.Destroy(gameObject);
        }
    }
}
