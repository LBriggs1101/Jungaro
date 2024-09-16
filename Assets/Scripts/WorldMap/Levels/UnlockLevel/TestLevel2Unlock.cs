using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel2Unlock : MonoBehaviour
{
    public LevelData levelData;
    public TriggerActivatePopUp triggerActivatePopUp;
    public GameObject lockObject;

    private void Awake() 
    {
        if(levelData.beatLevel)
        {
            triggerActivatePopUp.isUnlocked = true;
            lockObject.SetActive(false);
        }    
    }

}
