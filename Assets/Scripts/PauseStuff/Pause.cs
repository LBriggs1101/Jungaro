using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pauseScreen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0)
            {
                pause();
            }
            else
            {
                unPause();
            }
            
        }
    }

    public void pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void unPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
