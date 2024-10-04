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
            other.gameObject.SetActive(false);
            GameObject.Find("LevelDataManager").GetComponent<LevelDataManager>().levelBeaten();
            levelCompleteScreen.SetActive(true);

            if(GameObject.Find("LevelChallengeManager").GetComponent<TimerChallenge>() != null)
            {
                GameObject.Find("LevelChallengeManager").GetComponent<TimerChallenge>().stopTheTimer();
            }
        }
    }
}
