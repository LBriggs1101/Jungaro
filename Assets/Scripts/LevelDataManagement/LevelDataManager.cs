using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    public LevelData levelData;
    private int currentAttemptCoins;
    private DeathManager deathManager;
    private LevelChallengeManager levelChallengeManager;

    public void updateCoins()
    {
        currentAttemptCoins = GameObject.Find("CoinManager").GetComponent<CoinManager>().getCoinCount();
    }

    public void levelBeaten()
    {
        deathManager = GameObject.Find("DeathManager").GetComponent<DeathManager>();
        levelChallengeManager = GameObject.Find("LevelChallengeManager").GetComponent<LevelChallengeManager>();
        levelData.beatLevel = true;
        updateCoins();
        if(currentAttemptCoins > levelData.coinCount)
        {
            levelData.coinCount = currentAttemptCoins;
        }
        //Add beating without death check from death manager.
        if(deathManager.beatNoDeath() && !levelData.beatNoDeath)
        {
            levelData.beatNoDeath = true;
        }
        //Add beating with challenge from challenge manager.
        if(levelChallengeManager.returnChallengeComplete() && !levelData.bonusChallengeComplete)
        {
            levelData.bonusChallengeComplete = true;
        }
        //Add an auto save here.
    }

    public bool getLevelBeat()
    {
        return levelData.beatLevel;
    }

    public bool getNoDeath()
    {
        return levelData.beatNoDeath;
    }

    public bool getBeatChallenge()
    {
        return levelData.bonusChallengeComplete;
    }

    public int getAttemptCoins()
    {
        return currentAttemptCoins;
    }
}
