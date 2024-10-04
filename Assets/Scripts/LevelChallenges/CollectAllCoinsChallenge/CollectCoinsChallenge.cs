using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinsChallenge : LevelChallenge
{

    public int neededCoinCount;

    public override bool beatChallengeValue()
    {
        if(GameObject.Find("CoinManager").GetComponent<CoinManager>().getCoinCount() >= neededCoinCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
