using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public GameObject player;
    public GameObject deathScreen;
    public DeathData deathTracker;

    public void death()
    {
        player.SetActive(false);
        deathTracker.numOfDeaths++;
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public bool beatNoDeath()
    {
        if(deathTracker.numOfDeaths > 0)
        {
            resetDeaths();
            return false;
        }
        else
        {
            resetDeaths();
            return true;
        }

    }

    public void resetDeaths()
    {
        deathTracker.numOfDeaths = 0;
    }

}
