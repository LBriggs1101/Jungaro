using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerChallenge : LevelChallenge
{

    private bool timerGoing = true;
    private float currentTime;
    public TextMeshProUGUI timerItself;

    // Update is called once per frame
    void Update()
    {
        if(timerGoing == true && Time.timeScale != 0)
        {
            currentTime += Time.deltaTime * (1 / Time.timeScale);
        }
        TimeSpan timeItself = TimeSpan.FromSeconds(currentTime);
        timerItself.text = timeItself.ToString(@"mm\:ss\:fff");
    }

}