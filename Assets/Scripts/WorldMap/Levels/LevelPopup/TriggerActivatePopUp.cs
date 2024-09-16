using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerActivatePopUp : MonoBehaviour
{

    public GameObject popUp;
    public GameObject lockedPopUp;
    public bool isUnlocked = false;
    public LevelData levelData;

    private TMP_Text levelName;
    private TMP_Text levelChallenge;
    private TMP_Text coinCount;
    private TMP_Text lockedStatus;

    public Sprite star;
    public Sprite emptyStar;

    private Image beatLevel;
    private Image beatChallenge;
    private Image beatNoDeath;

    private FadeCanvasGroup fadeCanvas;

    void Start()
    {
        //Grab all the component references. 
        fadeCanvas = GameObject.Find("FadeCanvas").GetComponent<FadeCanvasGroup>();
        levelName = GameObject.Find("LevelName").GetComponent<TextMeshProUGUI>();
        levelChallenge = GameObject.Find("LevelChallenge").GetComponent<TextMeshProUGUI>();
        coinCount = GameObject.Find("CoinCounter").GetComponent<TextMeshProUGUI>();
        lockedStatus = GameObject.Find("Locked/Unlocked").GetComponent<TextMeshProUGUI>();
        beatLevel = GameObject.Find("BeatLevelStar").GetComponent<Image>();
        beatChallenge = GameObject.Find("BeatChallengeStar").GetComponent<Image>();
        beatNoDeath = GameObject.Find("BeatNoDeathStar").GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Fade the canvas in.
            fadeCanvas.Fade();

            //Apply the text elements.
            levelName.text = levelData.levelName;
            levelChallenge.text = levelData.bonusChallangeDesc;
            coinCount.text = "Coins: " + levelData.coinCount;
            lockedStatus.text = (isUnlocked ? "Unlocked" : "Locked");

            //Apply the image changes.
            beatLevel.sprite = (levelData.beatLevel ? star : emptyStar);
            beatChallenge.sprite = (levelData.bonusChallengeComplete ? star : emptyStar);
            beatNoDeath.sprite = (levelData.beatNoDeath ? star : emptyStar); 

            //Activate the correct popup depending on if it is locked or not.
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
            //Deactivate everything when the player is out of range.
            fadeCanvas.Fade();
            popUp.SetActive(false);
            lockedPopUp.SetActive(false);
        }
    }
}
