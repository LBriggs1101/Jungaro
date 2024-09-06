using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    public TMP_Text coinText;
    public Sprite filledStar;
    public Image starBeatLevel;
    public Image starBeatNoDeath;
    public Image starBeatChallenge;
    public float starWaitTime = 1.5f;
    public GameObject nextButton;

    private LevelDataManager levelDataManager;

    private void Awake() 
    {
        levelDataManager = GameObject.Find("LevelDataManager").GetComponent<LevelDataManager>();
    }

    public void showStats()
    {
        StartCoroutine(showStatsStuff());
    }

    private IEnumerator showStatsStuff()
    {
        yield return new WaitForSeconds(starWaitTime);
        coinText.text = "Coins: " + levelDataManager.getAttemptCoins();
        starBeatLevel.sprite = filledStar;
        yield return new WaitForSeconds(starWaitTime);
        if(levelDataManager.getBeatChallenge())
        {
            starBeatChallenge.sprite = filledStar;
        }
        yield return new WaitForSeconds(starWaitTime);
        if(levelDataManager.getNoDeath())
        {
            starBeatNoDeath.sprite = filledStar;
        }
        yield return new WaitForSeconds(starWaitTime);
        nextButton.SetActive(true);
    }
}
