using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerActivatePopUp : MonoBehaviour
{

    public GameObject popUp;
    public GameObject lockedPopUp;
    public bool isUnlocked = false;
    public LevelData levelData;

    

    private FadeCanvasGroup fadeCanvas;

    void Start()
    {
        fadeCanvas = GameObject.Find("FadeCanvas").GetComponent<FadeCanvasGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            fadeCanvas.Fade();
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
            fadeCanvas.Fade();
            popUp.SetActive(false);
            lockedPopUp.SetActive(false);
        }
    }
}
